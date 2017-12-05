using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVM
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public bool save_flag = false;
        public string filename;
        private void button1_Click(object sender, EventArgs e)
        {
            save_flag = true;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Texture Image";
            //sfd.ShowDialog();
            sfd.Filter = "PNG Image|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                       (System.IO.FileStream)sfd.OpenFile();
                    // Saves the Image in the appropriate ImageFormat based upon the
                    // File type selected in the dialog box.
                    // NOTE that the FilterIndex property is one-based.                 
                    this.pictureBox1.Image.Save(fs,System.Drawing.Imaging.ImageFormat.Png);                
                    
                    fs.Close();
                }

            }


            string[] bits = sfd.FileName.Split('\\');
            filename = bits[bits.Length-1];
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save_flag = false;
            filename = null;
            this.Close();
        }

    }
}
