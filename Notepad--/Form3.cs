using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad__
{
    public delegate void ReplaceDelegate(string Source, string ReplaceStr);
    public partial class Form3 : Form
    {
        public event ReplaceDelegate Replace;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Replace?.Invoke(textBox1.Text, textBox2.Text);
        }
    }
}
