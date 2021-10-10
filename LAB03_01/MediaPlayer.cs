using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB03_01
{
    public partial class MediaPlayer : Form
    {
        public MediaPlayer()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "AVI file | *.avi | MPEG File | *.mpeg | Wav File | *.Wav | Midi File | *.midi | Mp4 File | *.mp4 | MP3 | *.mp3 | WEBM | *.webm";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer1.URL = openFile.FileName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
        }
    }
}
