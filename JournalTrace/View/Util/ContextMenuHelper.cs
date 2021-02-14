using JournalTrace.Entry;
using JournalTrace.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JournalTrace.View.Util
{
    public class ContextMenuHelper
    {
        public static ContextMenuHelper INSTANCE;

        private LanguageManager languageManager = LanguageManager.INSTANCE;
        private ContextMenuStrip menuStrip;
        private EntryManager entryManager;

        public ContextMenuHelper()
        {
            INSTANCE = this;
        }

        public void SetDependencies(ContextMenuStrip menu, EntryManager manager)
        {
            menuStrip = menu;
            entryManager = manager;
        }

        private bool ValidColumnEvent(DataGridView sender, DataGridViewCellMouseEventArgs e, out DataGridViewRow row)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridViewRow selectedRow = sender.Rows[e.RowIndex];
                if (selectedRow != null)
                {
                    row = selectedRow;
                    return true;
                }
            }
            row = null;
            return false;
        }

        public void ShowContext(DataGridView datag, DataGridViewCellMouseEventArgs columnEvent, bool fileInfo = true)
        {
            DataGridView datagrid = datag;
            if (!ValidColumnEvent(datagrid, columnEvent, out DataGridViewRow selectedRow))
            {
                return;
            }
            menuStrip.Items[1].Enabled = fileInfo;
            menuStrip.Items[2].Enabled = false;

            //seleciona a fileira toda
            selectedRow.DataGridView.ClearSelection();
            selectedRow.Selected = true;

            //nome pra copiar valor da coluna
            string columnName = datagrid.Columns[columnEvent.ColumnIndex].HeaderText;
            string copyText = $"{languageManager.GetString("copy")} \"{columnName}\"";
            menuStrip.Items[0].Text = copyText;

            //valor da coluna selecionada
            cellValue = selectedRow.Cells[columnEvent.ColumnIndex].Value.ToString();
            cellUSN = (long)selectedRow.Cells[0].Value; //primeira coluna é sempre o usn

            //diretorio
            string fileDirectory = entryManager.parentFileReferenceIdentifiers[entryManager.USNEntries[cellUSN].ParentFileReference].ResolvedID;
            if (fileDirectory.Contains(':')) //se nao tiver dois pontos o dir nao existe
            {
                cellDirectory = fileDirectory;
                menuStrip.Items[2].Enabled = true;
            }

            //show context
            var relativeMousePosition = datagrid.PointToClient(Cursor.Position);
            menuStrip.Show(datagrid, relativeMousePosition);

        }

        private string cellValue;
        public string GetCellValue()
        {
            return cellValue;
        }

        private long cellUSN;
        public long GetCellUSN()
        {
            return cellUSN;
        }

        private string cellDirectory;
        public string GetCellDirectory()
        {
            return cellDirectory;
        }
    }
}
