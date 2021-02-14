using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JournalTrace.Entry;
using JournalTrace.Language;
using JournalTrace.View.Util;

namespace JournalTrace.View.Layout
{
    public partial class TreeLayout : UserControl, ILayout
    {
        EntryManager entryManager;
        public TreeLayout(EntryManager mngr)
        {
            this.entryManager = mngr;
            InitializeComponent();
            //campos de tradução
            datagDirectoryChanges.Tag = new string[] { null, "name", "date", "reason" }; ;
        }

        public void Clean()
        {
            treeUSNDirectories.Nodes.Clear();
            treeUSNDirectories.Dispose();
            if (dataSourceTreeEntries != null)
            {
                datagDirectoryChanges.DataSource = null;
                dataSourceTreeEntries.Clear();
                dataSourceTreeEntries.Dispose();
                datagDirectoryChanges.Rows.Clear();
                datagDirectoryChanges.Dispose();
            }
            GC.Collect();
        }

        public Control GetControl()
        {
            return this;
        }

        public DataTable dataSourceTreeEntries;
        public async void LoadData(FormMain frm)
        {
            treeUSNDirectories.Nodes.Clear();


            //datasource setup
            dataSourceTreeEntries = new DataTable();

            dataSourceTreeEntries.Columns.Add("USN", typeof(long));
            dataSourceTreeEntries.Columns.Add("name", typeof(string));
            dataSourceTreeEntries.Columns.Add("date", typeof(string));
            dataSourceTreeEntries.Columns.Add("reason", typeof(string));

            TreeNode[] dirTree = null;

            await Task.Run(() =>
            {
               dirTree = entryManager.BakeTree();
            });

            treeUSNDirectories.Nodes.AddRange(dirTree);

            frm.ShowLayoutOption(true);
        }


        private void treeUSNDirectories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            datagDirectoryChanges.DataSource = null;
            dataSourceTreeEntries.Rows.Clear();

            TreeNode CurrentNode = e.Node;
            string fullpath = CurrentNode.FullPath;
            if (fullpath.EndsWith(":"))
            {
                fullpath += "\\";
            }

            List<long> dirUSNS = entryManager.GetChangesOfDirectory(fullpath);
            if (dirUSNS != null)
            {
                foreach (var usn in dirUSNS)
                {
                    USNEntry entry = entryManager.USNEntries[usn];
                    dataSourceTreeEntries.Rows.Add(entry.USN, entry.Name, entry.Time, entry.Reason);
                }

                datagDirectoryChanges.DataSource = dataSourceTreeEntries;

                //tamanho das colunas
                int[] widthColumns = new int[] { 88, 200, 115, 300 };

                for (int i = 0; i < widthColumns.Length; i++)
                {
                    datagDirectoryChanges.Columns[i].Width = widthColumns[i];
                }

                LanguageManager.INSTANCE.UpdateControl(datagDirectoryChanges);
            }

        }

        private void datagDirectoryChanges_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            ContextMenuHelper.INSTANCE.ShowContext(datagDirectoryChanges, e);
        }
    }
}
