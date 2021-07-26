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
    public delegate void FindWordDelegate(string Source);
    public partial class Form2 : Form
    {
        public event FindWordDelegate Find;

        public Form2()
        {
            InitializeComponent();
            if (this.ForeColor == Color.Black)
            {
                label1.ForeColor = Color.White;
            }
            else if(this.ForeColor == Color.White)
            {
                label1.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            Find?.Invoke(str);
            //MessageBox.Show(str);

        }
    }
}
