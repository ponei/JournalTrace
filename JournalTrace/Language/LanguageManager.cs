using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace JournalTrace.Language
{
    public class LanguageManager
    {
        public static LanguageManager INSTANCE;
        public ResourceManager textManager;
        private List<LocalizableControl> controlList = new List<LocalizableControl>();

        public LanguageManager()
        {
            INSTANCE = this;
            SwitchLanguage("en");
        }

        public void SwitchLanguage(string name)
        {
            textManager = new ResourceManager($"JournalTrace.Language.Localization.{name}", Assembly.GetExecutingAssembly());
        }

        public string GetString(string text)
        {
            return textManager.GetString(text);
        }

        public void UpdateControls()
        {
            //contagem reversa pra nao ter problema de exception na hora do loop
            for (int i = controlList.Count - 1; i >= 0; i--)
            {
                //checa se o controle já foi removido
                //se já, tira da lista; nao tem motivo pra ficar atualizando
                //pula a iteração do loop quando deletar
                LocalizableControl temp = controlList[i];
                switch (temp.ControlType)
                {
                    case 0:
                        if (temp.ControlToLocalize.IsDisposed)
                        {
                            controlList.RemoveAt(i);
                            continue;
                        }
                        break;

                    case 1:
                        if (temp.MenuItemToLocalize.IsDisposed)
                        {
                            controlList.RemoveAt(i);
                            continue;
                        }
                        break;

                    case 2:
                        if (temp.DataGridViewToLocalize.IsDisposed)
                        {
                            controlList.RemoveAt(i);
                            continue;
                        }
                        break;
                    case 3:
                        if (temp.ComboBoxToLocalize.IsDisposed)
                        {
                            controlList.RemoveAt(i);
                            continue;
                        }
                        break;
                }

                UpdateLocalizableControl(temp);
            }
        }

        public void UpdateControl(object ctrl)
        {
            foreach (var control in controlList)
            {
                switch (control.ControlType)
                {
                    case 0:
                        if (control.ControlToLocalize == ctrl)
                        {
                            UpdateLocalizableControl(control);
                            break;
                        }
                        break;

                    case 1:
                        if (control.MenuItemToLocalize == ctrl)
                        {
                            UpdateLocalizableControl(control);
                            break;
                        }
                        break;

                    case 2:
                        if (control.DataGridViewToLocalize == ctrl)
                        {
                            UpdateLocalizableControl(control);
                            break;
                        }
                        break;
                    case 3:
                        if (control.ComboBoxToLocalize == ctrl)
                        {
                            UpdateLocalizableControl(control);
                            break;
                        }
                        break;
                }
            }
        }

        public void UpdateLocalizableControlText(object control, string newText)
        {
            foreach (var item in controlList)
            {
                if (item.ControlToLocalize == control || item.MenuItemToLocalize == control)
                {
                    switch (item.ControlType)
                    {
                        case 0:
                            (control as Control).Tag = newText;
                            break;

                        case 1:
                            (control as ToolStripMenuItem).Tag = newText;
                            break;
                    }
                    item.TextToLocalize = newText;
                    UpdateLocalizableControl(item);
                }
            }
        }

        public void AddLocalizableControls(object ctrl)
        {
            if (ctrl is ToolStrip)
            {
                GetChildrenOfMenu(ctrl as ToolStrip);
            }
            else
            {
                AddObjectIfPossible(ctrl);
                if (ctrl is Control)
                {
                    Control cControl = ctrl as Control;
                    foreach (Control child in cControl.Controls)
                    {
                        if (child is ToolStrip)
                        {
                            GetChildrenOfMenu(child as ToolStrip);
                        }
                        else
                        {
                            AddLocalizableControls(child);
                        }
                    }
                }
            }
        }

        private void UpdateLocalizableControl(LocalizableControl item)
        {
            switch (item.ControlType)
            {
                case 0:
                    item.ControlToLocalize.Text = textManager.GetString(item.TextToLocalize);
                    break;

                case 1:
                    item.MenuItemToLocalize.Text = textManager.GetString(item.TextToLocalize);
                    break;

                case 2:
                    for (int i = 0; i < item.DataGridViewToLocalize.Columns.Count; i++)
                    {
                        if (item.TextArrayToLocalize[i] != null)
                        {
                            item.DataGridViewToLocalize.Columns[i].HeaderText = textManager.GetString(item.TextArrayToLocalize[i]);
                        }
                    }
                    break;
                case 3:
                    int oldIndex = item.ComboBoxToLocalize.SelectedIndex;
                    var newItems = new string[item.ComboBoxToLocalize.Items.Count];
                    for (int i = 0; i < item.TextArrayToLocalize.Length; i++)
                    {
                        if (item.TextArrayToLocalize[i] != null)
                        {
                            newItems[i] = textManager.GetString(item.TextArrayToLocalize[i]);
                        }
                        else
                        {
                            newItems[i] = item.ComboBoxToLocalize.Items[i].ToString();
                        }
                    }
                    item.ComboBoxToLocalize.Items.Clear();
                    item.ComboBoxToLocalize.Items.AddRange(newItems);
                    item.ComboBoxToLocalize.SelectedIndex = oldIndex;
                    break;
            }
        }

        private void GetChildrenOfMenu(ToolStrip strip)
        {
            foreach (ToolStripMenuItem item in strip.Items)
            {
                AddObjectIfPossible(item);
                GetChildrenOfMenuItem(item);
            }
        }

        private void GetChildrenOfMenuItem(ToolStripMenuItem menuitem)
        {
            foreach (ToolStripMenuItem item in menuitem.DropDownItems)
            {
                AddObjectIfPossible(item);
                GetChildrenOfMenuItem(item);
            }
        }

        private void AddObjectIfPossible(object item)
        {
            if (item is DataGridView)
            {
                DataGridView dItem = item as DataGridView;
                if (dItem.Tag != null)
                {
                    LocalizableControl localizable = new LocalizableControl(dItem, (string[])dItem.Tag);
                    controlList.Add(localizable);
                    UpdateLocalizableControl(localizable);
                }
            }
            else if (item is ComboBox)
            {
                ComboBox cItem = item as ComboBox;
                if (cItem.Tag != null)
                {
                    LocalizableControl localizable = new LocalizableControl(cItem, (string[])cItem.Tag);
                    controlList.Add(localizable);
                    UpdateLocalizableControl(localizable);
                }
            }
            else if (item is Control)
            {
                Control cItem = item as Control;
                if (cItem.Tag != null)
                {
                    LocalizableControl localizable = new LocalizableControl(cItem, (string)cItem.Tag);
                    controlList.Add(localizable);
                    UpdateLocalizableControl(localizable);
                }
            }
            else if (item is ToolStripMenuItem)
            {
                ToolStripMenuItem tItem = item as ToolStripMenuItem;
                if (tItem.Tag != null)
                {
                    LocalizableControl localizable = new LocalizableControl(tItem, (string)tItem.Tag);
                    controlList.Add(localizable);
                    UpdateLocalizableControl(localizable);
                }
            }
        }
    }
}