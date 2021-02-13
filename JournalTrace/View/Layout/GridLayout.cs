using JournalTrace.Language;
using JournalTrace.Entry;
using System;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace JournalTrace.View.Layout
{
    public partial class GridLayout : UserControl, ILayout
    {
        private EntryManager entryManager;

        public GridLayout(EntryManager mngr)
        {
            this.entryManager = mngr;
            
            InitializeComponent();

            comboSearch.SelectedIndex = 1;
            //campos de tradução
            datagJournalEntries.Tag = new string[] { null, "name", "date", "reason", "directory" };
            comboSearch.Tag = new string[] { null, "name", "date", "reason", "directory" };
        }
        public void Clean()
        {
            datagJournalEntries.DataSource = null;
            dataSourceEntries.Clear();
            dataSourceEntries.Dispose();
            datagJournalEntries.Rows.Clear();
            datagJournalEntries.Dispose();
            GC.Collect();
        }

        public Control GetControl()
        {
            return this;
        }

        public DataTable dataSourceEntries;

        public async void LoadData(FormMain frm)
        {
            dataSourceEntries = new DataTable();

            dataSourceEntries.Columns.Add("USN", typeof(long));
            dataSourceEntries.Columns.Add("name", typeof(string));
            dataSourceEntries.Columns.Add("date", typeof(string));
            dataSourceEntries.Columns.Add("reason", typeof(string));
            dataSourceEntries.Columns.Add("directory", typeof(string));

            await Task.Run(() =>
            {
                foreach (var item in entryManager.USNEntries)
                {
                    USNEntry entry = item.Value;
                    dataSourceEntries.Rows.Add(entry.USN, entry.Name, entry.Time, entry.Reason, entryManager.parentFileReferenceIdentifiers[entry.ParentFileReference].ResolvedID);
                }
            });

            datagJournalEntries.DataSource = dataSourceEntries;

            LanguageManager.INSTANCE.UpdateControl(datagJournalEntries);

            //tamanho das colunas
            int[] widthColumns = new int[] { 88, 200, 115, 300, 500 };

            for (int i = 0; i < widthColumns.Length; i++)
            {
                datagJournalEntries.Columns[i].Width = widthColumns[i];
            }

            ShowGrid(true);
            frm.ShowLayoutOption(true);
        }

        private int OverallLenght()
        {
            int i = 0;
            //foreach (var dir in dirManager.USNDirectories)
            //{
            //    foreach (var change in dir.Changes)
            //    {
            //        i++;
            //    }
            //}
            return i;
        }

        private void ShowGrid(bool v)
        {
            //lbStatusGrid.Visible = !v;
            //progbarRows.Visible = !v;
            //progbarAction.Visible = !v;
            datagJournalEntries.Visible = v;
        }

        private void GridLayout_Resize(object sender, EventArgs e)
        {
            //progbarAction.Location = new Point((Width / 2) - (progbarAction.Width / 2), ((Height) / 2) - progbarAction.Height / 2);
            //progbarRows.Location = new Point(progbarAction.Location.X, progbarAction.Location.Y + progbarRows.Height + 3);
            //lbStatusGrid.Location = new Point(0, progbarAction.Location.Y - lbStatusGrid.Height - 3);
        }
        private void datagJournalEntries_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            dataSourceEntries.DefaultView.RowFilter = dataSourceEntries.Columns[comboSearch.SelectedIndex].ColumnName + " LIKE '%" + txtSearch.Text +"%'";
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch_Click(this, null);
            }
        }

        private void btSearchClear_Click(object sender, EventArgs e)
        {
            dataSourceEntries.DefaultView.RowFilter = "";
        }
    }
}