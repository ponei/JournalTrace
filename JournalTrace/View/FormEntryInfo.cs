using JournalTrace.Entry;
using JournalTrace.Language;
using JournalTrace.View.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JournalTrace.View
{
    public partial class FormEntryInfo : Form
    {
        private EntryManager entryManager;
        private long USN;
        public FormEntryInfo(EntryManager mngr, long usn)
        {
            InitializeComponent();

            entryManager = mngr;
            USN = usn;

            datagFileIdentifiers.Tag = new string[] { null, "name", "date", "reason", "directory" };
        }

        public async void LoadData()
        {
            USNEntry entry = entryManager.USNEntries[USN];
            ResolvableIdentifier currentFile = new ResolvableIdentifier(entry.FileReference);
            currentFile.Resolve();

            lbUSNV.Text = USN.ToString();
            lbNameV.Text = entry.Name;
            lbFileIDV.Text = entry.FileReference.ToString();
            if (currentFile.ID.ToString().Equals(currentFile.ResolvedID))
            {
                //id de identificacao nao reconhece arquivo, quer dizer que foi deletado
                lbFileDeleted.Visible = true;
            } else
            {
                lbCurrentFileV.Text = currentFile.ResolvedID;
                lbCurrentFileV.Visible = true;
            }
            lbParentIDV.Text = entryManager.parentFileReferenceIdentifiers[entry.ParentFileReference].ResolvedID;
            lbReasonV.Text = entry.Reason;
            lbDateV.Text = entry.Time;

            DataTable dataSourceEntries = new DataTable();

            dataSourceEntries.Columns.Add("USN", typeof(long));
            dataSourceEntries.Columns.Add("name", typeof(string));
            dataSourceEntries.Columns.Add("date", typeof(string));
            dataSourceEntries.Columns.Add("reason", typeof(string));
            dataSourceEntries.Columns.Add("directory", typeof(string));

            await Task.Run(() =>
            {
                USNCollection usnCol = entryManager.USNFiles[entry.FileReference];
                foreach (long usnFile in usnCol.USNList)
                {
                    USNEntry fileEntry = entryManager.USNEntries[usnFile];
                    dataSourceEntries.Rows.Add(fileEntry.USN, fileEntry.Name, fileEntry.Time, fileEntry.Reason, entryManager.parentFileReferenceIdentifiers[fileEntry.ParentFileReference].ResolvedID);
                }
            });

            datagFileIdentifiers.DataSource = dataSourceEntries;

            //tamanho das colunas
            int[] widthColumns = new int[] { 88, 200, 115, 300, 500 };

            for (int i = 0; i < widthColumns.Length; i++)
            {
                datagFileIdentifiers.Columns[i].Width = widthColumns[i];
            }

            LanguageManager.INSTANCE.UpdateControl(datagFileIdentifiers);
        }

        private void datagFileIdentifiers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            ContextMenuHelper.INSTANCE.ShowContext(datagFileIdentifiers, e, false);
        }
    }
}
