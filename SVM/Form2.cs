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
    public partial class Form2 : Form
    {
        Form1 ownerForm = null;
        public Form2(Form1 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ownerForm.passValue(textBox1.Text, textBox2.Text,textBox3.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            this.ownerForm.passValue(textBox1.Text, textBox2.Text,textBox3.Text);
            this.Close();
        }
    }
}
