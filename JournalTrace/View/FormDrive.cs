using JournalTrace.Language;
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

namespace JournalTrace.View
{
    public partial class FormDrive : Form
    {
        FormMain parentForm;
        public FormDrive(FormMain parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
        }

        DriveInfo[] selectableVolumes;
        DriveInfo clickedVolume;
        private void FormDrive_Load(object sender, EventArgs e)
        {
            DriveInfo[] volumes = DriveInfo.GetDrives();
            List<DriveInfo> filteredVolumes = new List<DriveInfo>();
            foreach (DriveInfo di in volumes)
            {
                if (di.IsReady && 0 == string.Compare(di.DriveFormat, "ntfs", true))
                {
                    filteredVolumes.Add(di);
                }
            }

            selectableVolumes = filteredVolumes.ToArray();
            listbDrives.Items.AddRange(selectableVolumes);

            LanguageManager.INSTANCE.AddLocalizableControls(this);

        }

        private void listbDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbDrives.SelectedIndex == -1) { return;  }

            clickedVolume = selectableVolumes[listbDrives.SelectedIndex];

            lbNameV.Text = clickedVolume.Name;
            lbFormatV.Text = clickedVolume.DriveFormat;
            lbRootV.Text = clickedVolume.RootDirectory.ToString();
            lbTotalFreeV.Text = clickedVolume.TotalFreeSpace / 1000000000 + "GB";
            lbTotalSizeV.Text = clickedVolume.TotalSize / 1000000000 + "GB";
            lbTypeV.Text = clickedVolume.DriveType.ToString();

            pnlDriveInfo.Visible = true;
        }

        private void btSelect_Click(object sender, EventArgs e)
        {          
            parentForm.ChangeVolume(clickedVolume);
            Close();
        }
    }
}
