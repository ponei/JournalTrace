using JournalTrace.Language;
using JournalTrace.Native;
using JournalTrace.Entry;
using JournalTrace.View;
using JournalTrace.View.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JournalTrace.View.Util;
using System.Diagnostics;
using JournalTrace.View.Info;

namespace JournalTrace
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            entryManager.NextStatusUpdate += EntryManager_NextStatusUpdate;
            entryManager.WorkEnded += EntryManager_WorkEnded;
            progbarStatus.Maximum = statusLenght * 10;

        }

        #region entrymanager status update
        private void EntryManager_WorkEnded(object sender, EventArgs e)
        {
            ShowLayoutOption(true);
            ShowJournalInfo(true);
        }

        private void EntryManager_NextStatusUpdate(object sender, bool e)
        {
            if (e)
            {
                statusPhase++;
            }
            else
            {
                statusPhase = -statusPhase;
            }
            NextStatus();
        }

        const int statusLenght = 6;
        int statusPhase = 1;

        private void NextStatus()
        {
            LanguageManager.INSTANCE.UpdateLocalizableControlText(lbStatusMain, $"statustitle{statusPhase}");
            LanguageManager.INSTANCE.UpdateLocalizableControlText(lbStatusDesc, $"statusdesc{statusPhase}");

            if (statusPhase > 0)
            {
                progbarStatus.PerformStep();
            }
            else
            {
                ShowLayoutOption(true);
                progbarStatus.Value = 0;
            }
        }
        #endregion

        private EntryManager entryManager = new EntryManager();

        public void ChangeVolume(DriveInfo newVolume)
        {
            entryManager.ChangeVolume(newVolume);
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            LanguageManager.INSTANCE.AddLocalizableControls(this);
            LanguageManager.INSTANCE.AddLocalizableControls(cmsEntryInfo);
            ContextMenuHelper.INSTANCE.SetDependencies(cmsEntryInfo, entryManager);
            RelocateStatusMessage();
        }


        #region drive (menu)
        FormDrive frmDrive;
        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDrive != null)
            {
                if (!frmDrive.IsDisposed) { return; }

            }
            frmDrive = new FormDrive(this);
            frmDrive.Show();
        }

        private async void scanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progbarStatus.Value = 0;
            ShowLayoutOption(false);
            ShowJournalInfo(false);
            StatusVisibility(true);
            if (layoutType != null)
            {
                Controls.Remove(layoutType as UserControl);
            }

            statusPhase = 1;
            NextStatus();
            

            await Task.Run(() =>
            {
                entryManager.BeginScan();
            });
        }
        #endregion

        public void ShowLayoutOption(bool v)
        {
            driveToolStripMenuItem.Enabled = v;
            layoutToolStripMenuItem.Enabled = v;

        }

        public void ShowJournalInfo(bool v)
        {
            if (v)
            {
                lbCountFirstV.Text = entryManager.USNEntries[entryManager.OldestUSN].Time;
                lbCountAllV.Text = entryManager.USNEntries.Count.ToString();
                lbCountFilesV.Text = entryManager.fileReferenceIndetifiersSize.ToString();
                lbCountDirectoriesV.Text = entryManager.parentFileReferenceIdentifiers.Count.ToString();
            }
            else
            {
                lbCountFirstV.Text = "...";
                lbCountAllV.Text = "...";
                lbCountFilesV.Text = "...";
                lbCountDirectoriesV.Text = "...";
            }
        }


        bool lastVisibility = true;
        private void StatusVisibility(bool v)
        {
            lastVisibility = v;
            lbStatusMain.Visible = v;
            lbStatusDesc.Visible = v;
            progbarStatus.Visible = v;
        }

        private void RelocateStatusMessage()
        {
            lbStatusMain.Location = new Point(0, ((Height - 24) / 2) - lbStatusMain.Height * 2);
            lbStatusDesc.Location = new Point((Width / 2) - ((lbStatusDesc.Width + 16) / 2), lbStatusMain.Location.Y + lbStatusMain.Height);
            progbarStatus.Location = new Point((Width / 2) - ((progbarStatus.Width + 16) / 2), lbStatusDesc.Location.Y + lbStatusDesc.Height);

        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (lastVisibility)
            {
                RelocateStatusMessage();
            }
            
        }


        #region language (menu)
        bool ignoreLanguageChange = false;
        private void englishToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (ignoreLanguageChange)
            {
                ignoreLanguageChange = false;
                return;
            }
            ChangeLanguage("en");
            UncheckOtherLanguages(sender);
        }

        private void portuguêsToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (ignoreLanguageChange)
            {
                ignoreLanguageChange = false;
                return;
            }
            ChangeLanguage("pt");
            UncheckOtherLanguages(sender);
        }

        private void UncheckOtherLanguages(object sender)
        {
            ignoreLanguageChange = true;
            foreach (ToolStripMenuItem item in languageToolStripMenuItem.DropDownItems)
            {

                if (item == sender as ToolStripMenuItem)
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        private void ChangeLanguage(string name)
        {
            LanguageManager.INSTANCE.SwitchLanguage(name);
            LanguageManager.INSTANCE.UpdateControls();
        }
        #endregion language

        #region layout (menu)
        bool ignoreLayoutChange = false;
        private void directoryTreeToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (ignoreLayoutChange)
            {
                ignoreLayoutChange = false;
                return;
            }
            UncheckOtherLayouts(sender);
        }

        private void dataGridToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (ignoreLayoutChange)
            {
                ignoreLayoutChange = false;
                return;
            }
            UncheckOtherLayouts(sender);
        }

        private void UncheckOtherLayouts(object sender)
        {
            ignoreLayoutChange = true;
            foreach (ToolStripMenuItem item in layoutToolStripMenuItem.DropDownItems)
            {
                if (item == sender as ToolStripMenuItem)
                {
                    if (OnlyOneLayoutChecked())
                    {
                        ignoreLayoutChange = false;
                    }
                    else
                    {
                        item.Checked = true;
                    }

                }
                else
                {
                    item.Checked = false;
                }
            }
            ShowLayoutOption(false);
            LoadLayout();
            layoutType.LoadData(this);

        }

        private bool OnlyOneLayoutChecked()
        {
            int i = 0;
            foreach (ToolStripMenuItem item in layoutToolStripMenuItem.DropDownItems)
            {
                if (item.Checked) i++;
            }
            return i == 1;
        }


        ILayout layoutType;
        private void LoadLayout()
        {
            if (layoutType != null)
            {
                layoutType.Clean();
                (layoutType as UserControl).Dispose();
            }
            foreach (ToolStripMenuItem item in layoutToolStripMenuItem.DropDownItems)
            {
                if (item.Checked)
                {
                    if (item == dataGridToolStripMenuItem)
                    {
                        layoutType = new GridLayout(entryManager);
                    }
                    if (item == directoryTreeToolStripMenuItem)
                    {
                        layoutType = new TreeLayout(entryManager);
                    }

                    break;
                }
            }

            UserControl layoutControl = layoutType as UserControl;

            LanguageManager.INSTANCE.AddLocalizableControls(layoutControl);

            layoutControl.Location = new Point(0, 24);
            layoutControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            layoutControl.Size = new Size(Width - 16, Height - 80);

            StatusVisibility(false);
            Controls.Add(layoutControl);

        }

        #endregion

        #region grid contextmenu
        private void entryInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEntryInfo frmInfo = new FormEntryInfo(entryManager, ContextMenuHelper.INSTANCE.GetCellUSN());
            LanguageManager.INSTANCE.AddLocalizableControls(frmInfo);
            frmInfo.Show();
            frmInfo.LoadData();
        }

        private void copyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ContextMenuHelper.INSTANCE.GetCellValue());
        }

        private void enterDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", ContextMenuHelper.INSTANCE.GetCellDirectory());
        }
        #endregion

        #region information (menu)
        FormInfo frmInfo;
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (frmInfo != null)
            {
                if (!frmInfo.IsDisposed) { return; }

            }
            frmInfo = new FormInfo();
            LanguageManager.INSTANCE.AddLocalizableControls(frmInfo);
            frmInfo.Show();
        }
        #endregion
    }
}
