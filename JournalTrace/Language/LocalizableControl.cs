using System.Windows.Forms;

namespace JournalTrace.Language
{
    internal class LocalizableControl
    {
        public int ControlType { get; }
        public Control ControlToLocalize { get; set; }
        public ToolStripMenuItem MenuItemToLocalize { get; set; }
        public DataGridView DataGridViewToLocalize { get; set; }
        public ComboBox ComboBoxToLocalize { get; set; }
        public string TextToLocalize { get; set; }
        public string[] TextArrayToLocalize { get; set; }

        public LocalizableControl(Control controlToLocalize, string textToLocalize)
        {
            ControlToLocalize = controlToLocalize;
            TextToLocalize = textToLocalize;
            ControlType = 0;
        }

        public LocalizableControl(ToolStripMenuItem menuItemToLocalize, string textToLocalize)
        {
            MenuItemToLocalize = menuItemToLocalize;
            TextToLocalize = textToLocalize;
            ControlType = 1;
        }

        public LocalizableControl(DataGridView dataGridViewToLocalize, string[] textArrayToLocalize)
        {
            DataGridViewToLocalize = dataGridViewToLocalize;
            TextArrayToLocalize = textArrayToLocalize;
            ControlType = 2;
        }

        public LocalizableControl(ComboBox comboBoxToLocalize, string[] textArrayToLocalize)
        {
            ComboBoxToLocalize = comboBoxToLocalize;
            TextArrayToLocalize = textArrayToLocalize;
            ControlType = 3;
        }
    }
}