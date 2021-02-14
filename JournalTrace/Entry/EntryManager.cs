using JournalTrace.Entry;
using JournalTrace.Language;
using JournalTrace.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace JournalTrace.Entry
{
    public class EntryManager
    {
        #region events

        public event EventHandler<float> StatusProgressUpdate;

        public event EventHandler<bool> NextStatusUpdate;

        public event EventHandler WorkEnded;

        protected virtual void OnStatusProgressUpdate()
        {
            StatusProgressUpdate?.Invoke(this, 1f);
        }

        protected virtual void OnEntryAmountUpdate(bool completed)
        {
            NextStatusUpdate?.Invoke(this, completed);
        }

        protected virtual void OnWorkEnded()
        {
            WorkEnded?.Invoke(this, null);
        }

        #endregion events

        private DriveInfo selectedVolume;

        public void ChangeVolume(DriveInfo newVolume)
        {
            this.selectedVolume = newVolume;
        }

        //used for datagrid cell selection
        public long SelectedUSN;





        //used for getting the oldest usn date, shows on main form
        public long OldestUSN;

        public Win32Api.USN_JOURNAL_DATA usnCurrentJournalState;
        private NtfsUsnJournal usnJournal = null;

        public void BeginScan()
        {
            //clear
            parentFileReferenceIdentifiers.Clear();
            USNEntries.Clear();
            USNDirectories.Clear();

            usnCurrentJournalState = new Win32Api.USN_JOURNAL_DATA();
            //1 phase; handle
            try
            {
                usnJournal = new NtfsUsnJournal(selectedVolume);
                OnEntryAmountUpdate(true);
            }
            catch (Exception)
            {
                OnEntryAmountUpdate(false);
                return;
            }

            //2 phase; current state
            Win32Api.USN_JOURNAL_DATA journalState = new Win32Api.USN_JOURNAL_DATA();
            NtfsUsnJournal.UsnJournalReturnCode rtn = usnJournal.GetUsnJournalState(ref journalState);
            if (rtn == NtfsUsnJournal.UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
            {
                usnCurrentJournalState = journalState;
                OnEntryAmountUpdate(true);
            }
            else
            {
                OnEntryAmountUpdate(false);
                return;
            }

            //3 phase; query
            uint reasonMask = Win32Api.USN_REASON_DATA_OVERWRITE |
                    Win32Api.USN_REASON_DATA_EXTEND |
                    Win32Api.USN_REASON_NAMED_DATA_OVERWRITE |
                    Win32Api.USN_REASON_NAMED_DATA_TRUNCATION |
                    Win32Api.USN_REASON_FILE_CREATE |
                    Win32Api.USN_REASON_FILE_DELETE |
                    Win32Api.USN_REASON_EA_CHANGE |
                    Win32Api.USN_REASON_SECURITY_CHANGE |
                    Win32Api.USN_REASON_RENAME_OLD_NAME |
                    Win32Api.USN_REASON_RENAME_NEW_NAME |
                    Win32Api.USN_REASON_INDEXABLE_CHANGE |
                    Win32Api.USN_REASON_BASIC_INFO_CHANGE |
                    Win32Api.USN_REASON_HARD_LINK_CHANGE |
                    Win32Api.USN_REASON_COMPRESSION_CHANGE |
                    Win32Api.USN_REASON_ENCRYPTION_CHANGE |
                    Win32Api.USN_REASON_OBJECT_ID_CHANGE |
                    Win32Api.USN_REASON_REPARSE_POINT_CHANGE |
                    Win32Api.USN_REASON_STREAM_CHANGE |
                    Win32Api.USN_REASON_CLOSE;

            OldestUSN = usnCurrentJournalState.FirstUsn;
            NtfsUsnJournal.UsnJournalReturnCode rtnCode = usnJournal.GetUsnJournalEntries(usnCurrentJournalState, reasonMask, out List<Win32Api.UsnEntry> usnEntries, out usnCurrentJournalState);

            if (rtnCode == NtfsUsnJournal.UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
            {
                OnEntryAmountUpdate(true);

                //4 phase
                ResolveIdentifiers(usnEntries);
                OnEntryAmountUpdate(true);

                //5 phase
                AddEntries(usnEntries);
                OnEntryAmountUpdate(true);

                OnWorkEnded();
            }
            else
            {
                OnEntryAmountUpdate(false);
                return;
            }
        }

        public IDictionary<long, USNEntry> USNEntries = new Dictionary<long, USNEntry>(); //usn
        public IDictionary<ulong, USNCollection> USNDirectories = new Dictionary<ulong, USNCollection>(); //parentfilereference
        public IDictionary<ulong, USNCollection> USNFiles = new Dictionary<ulong, USNCollection>(); //filereference

        private void AddEntries(List<Win32Api.UsnEntry> usnEntries)
        {
            foreach (var entry in usnEntries)
            {
                ulong parentFileReference = entry.ParentFileReferenceNumber;
                ulong fileReference = entry.FileReferenceNumber;
                USNEntries.Add(entry.USN, new USNEntry(entry.USN, entry.Name, entry.FileReferenceNumber, entry.ParentFileReferenceNumber, entry.TimeStamp, entry.Reason));
                //diretorios
                if (!USNDirectories.TryGetValue(parentFileReference, out USNCollection foundDir))
                {
                    USNDirectories.Add(parentFileReference, new USNCollection(parentFileReference, entry.USN));
                }
                else
                {
                    foundDir.USNList.Add(entry.USN);
                }
                //arquivos
                if (!USNFiles.TryGetValue(fileReference, out USNCollection foundFile))
                {
                    USNFiles.Add(fileReference, new USNCollection(fileReference, entry.USN));
                }
                else
                {
                    foundFile.USNList.Add(entry.USN);
                }
            }


            string usnReasonsRaw = LanguageManager.INSTANCE.GetString("usnreasons");
            string[] usnReasonsList = usnReasonsRaw.Split(new string[] { "," }, StringSplitOptions.None);
            foreach (var entry in USNEntries)
            {
                entry.Value.ResolveInfo(usnReasonsList);
            }

            //MessageBox.Show("c");
        }

        public IDictionary<ulong, ResolvableIdentifier> parentFileReferenceIdentifiers = new Dictionary<ulong, ResolvableIdentifier>();
        public int fileReferenceIndetifiersSize = 0;

        private void ResolveIdentifiers(List<Win32Api.UsnEntry> usnEntries)
        {
            //coloca todos os ids de diretorios parentes em um hashset
            //hashset não aceita itens duplicados e é mais rápido que usar uma lista normal
            //o resultado é uma lista com ids unicos
            HashSet<ulong> fileReference = new HashSet<ulong>(), parentFileReference = new HashSet<ulong>();

            foreach (var entry in usnEntries)
            {
                fileReference.Add(entry.FileReferenceNumber);
                parentFileReference.Add(entry.ParentFileReferenceNumber);
            }

            fileReferenceIndetifiersSize = fileReference.Count;

            //cu
            foreach (var id in parentFileReference)
            {
                parentFileReferenceIdentifiers.Add(id, new ResolvableIdentifier(id));
            }

            //dictionary
            foreach (var item in parentFileReferenceIdentifiers)
            {
                item.Value.Resolve();
            }

        }

        //procura nos nodes do parametro um node com o nome do parametro
        //serve caso "ContainsKey" retornar verdadeiro e precisamos pegar o node especifico
        private TreeNode GetNodeOfName(TreeNode nodeToSearch, string name)
        {
            foreach (TreeNode node in nodeToSearch.Nodes)
            {
                if (node.Name.Equals(name))
                {
                    return node;
                }
            }
            return null;
        }

        //a arvore não tem uma referencia pro id de cada diretorio individual
        //pra pegar as mudanças de um diretorio, procuramos pelo nome completo
        public List<long> GetChangesOfDirectory(string path)
        {
            USNCollection foundEntry = null;
            foreach (var usndir in USNDirectories)
            {
                if (parentFileReferenceIdentifiers[usndir.Key].ResolvedID.Equals(path))
                {
                    foundEntry = usndir.Value;
                    break;
                }
            }
            if (foundEntry != null)
            {
                return foundEntry.USNList;
            }
            else
            {
                return null;
            }
        }

        public TreeNode[] BakeTree()
        {
            List<TreeNode> rootDirNodes = new List<TreeNode>();
            //criamos uma arvore pra cada diretorio, para uso mais conveniente
            foreach (var usndir in USNDirectories)
            {
                //separamos a string do caminho pelo determinante de diretorios (barra ao contrario) em um array
                //cada index contem cada diretorio separadamente
                //exemplo: "C:\Users\Computador\Downloads\" -> "C:", "Users", "Computador", "Downloads"
                //isso serve pra checar se certo diretorio já existe na arvore
                string parentFilePath = parentFileReferenceIdentifiers[usndir.Key].ResolvedID;
                string[] individualDirs = parentFilePath.Split('\\');
                if (individualDirs.Length == 2)
                {
                    if (individualDirs[1].Equals(""))
                    {
                        individualDirs = new string[] { individualDirs[0] };
                    }
                }

                TreeNode lastNode = new TreeNode();

                //pra cada diretorio separado, precisamos atualizar a arvore (caso necessario)
                //caso o diretorio separado nao exista, criamos um node correspondente (se for o primeiro index, é um diretorio raiz na arvore)
                //caso exista, checamos se o index do loop não é o ultimo
                //ser o ultimo index indica que o diretorio contem mudanças e devemos destinguir ele dos demais
                for (int i = 0; i < individualDirs.Length; i++)
                {
                    string individualDir = individualDirs[i];
                    if (i == 0)
                    {
                        //primeiro index, precisa de logica diferente pra colocar uma raiz
                        bool found = false;
                        foreach (var rootDirNode in rootDirNodes)
                        {
                            if (rootDirNode.Name.Equals(individualDir))
                            {
                                lastNode = rootDirNode;
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            TreeNode newRootNode = new TreeNode
                            {
                                Name = individualDir,
                                Text = individualDir,
                                ForeColor = Color.Gray
                            };

                            rootDirNodes.Add(newRootNode);
                            lastNode = newRootNode;
                        }
                    }
                    else
                    {
                        //não é o primeiro index
                        if (!lastNode.Nodes.ContainsKey(individualDir))
                        {
                            TreeNode newNode = new TreeNode
                            {
                                Name = individualDir,
                                Text = individualDir,
                                ForeColor = Color.Gray
                            };

                            lastNode.Nodes.Add(newNode);
                            lastNode = newNode;
                        }
                        else
                        {
                            lastNode = GetNodeOfName(lastNode, individualDir);
                        }
                    }

                    //diferenciamos o node caso o index for o ultimo
                    if (i == individualDirs.Length - 1)
                    {
                        lastNode.ForeColor = Color.Black;
                    }
                }
            }

            //ordenação por string pro disco sempre aparecer em cima
            rootDirNodes.Sort((x, y) => y.Text.CompareTo(x.Text));

            return rootDirNodes.ToArray();
        }
    }
}