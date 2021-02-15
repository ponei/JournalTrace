using JournalTrace.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JournalTrace.View.Info
{
    public partial class FormInfo : Form
    {
        public FormInfo()
        {
            InitializeComponent();
            string[,] people = new string[,] { { "ponei", "poneidesc", null, "ponei", "channel/UC8XWpvtxj23ks_qdtXx_y4g" }, 
                { "Lordyzagat", "lordyzagatdesc", null, null, "c/Lordyzagat" },
                { "nolanblew", "nolandesc", null, "nolanblew/", null},
                { "StCroixSkipper", "skipperdesc", "forums/blog/1017-stcroixskippers", null, null} };
          
            for (int i = 0; i < people.GetLength(0); i++)
            {
                UserSocialMedia socials = new UserSocialMedia(people[i, 0], people[i, 1], people[i, 2], people[i, 3], people[i, 4]);
                socials.Location = new Point((Width / 2) - (socials.Width / 2) - 10, 50 + i * 50);
                LanguageManager.INSTANCE.AddLocalizableControls(socials);
                Controls.Add(socials);
                Height += 50;
            }
        }

        private void lbURL_Click(object sender, EventArgs e)
        {
            Process.Start(lbURL.Text);
        }
    }
}
