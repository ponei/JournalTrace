using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace JournalTrace.View.Info
{
    public partial class UserSocialMedia : UserControl
    {
        private const int picWidth = 55;
        public UserSocialMedia(string user, string desc, string dreamincode, string github, string youtube)
        {
            InitializeComponent();
            lbName.Text = user;
            lbDesc.Tag = desc;
            if (dreamincode != null)
            {
                dreamincodeURL += dreamincode;
                picDreamInCode.Visible = true;
            }
            else
            {
                Width -= picWidth;
            }
            if (github != null)
            {
                githubURL += github;
                picGithub.Visible = true;
            }
            else
            {
                Width -= picWidth;
            }
            if (youtube != null)
            {
                youtubeURL += youtube;
                picYoutube.Visible = true;

            }
            else
            {
                Width -= picWidth;
            }
        }

        string dreamincodeURL = "https://www.dreamincode.net/";
        private void picDreamInCode_Click(object sender, EventArgs e)
        {
            Process.Start(dreamincodeURL);
        }

        string githubURL = "https://github.com/";
        private void picGithub_Click(object sender, EventArgs e)
        {
            Process.Start(githubURL);
        }

        string youtubeURL = "https://www.youtube.com/";
        private void picYoutube_Click(object sender, EventArgs e)
        {
            Process.Start(youtubeURL);
        }
    }
}
