using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad__
{
  
    
    public partial class Form1 : Form
    {
       
        string pat = null;
        Encoding encoding = Encoding.GetEncoding(1251);
        string str = "";
        bool sav = false;
        int countTab = 0;
        public Form1() { }
        public Form1(string fileName)
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(CheckName);
            timer1.Interval = 100;
            timer1.Start();
        }
       
        void SaveAs()
        {
            saveFileDialog1.Title = "Save";
            saveFileDialog1.Filter = "Text Files|*.txt";
            saveFileDialog1.FilterIndex = 3;
            //saveFileDialog1.CheckFileExists = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                File.WriteAllText(saveFileDialog1.FileName, this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First().Text, encoding);
                
                MessageBox.Show(saveFileDialog1.FileName + " \nSuccessful saved");
                sav = true;
                this.pat = saveFileDialog1.FileName;
                toolStripStatusLabel2.Text = Path.GetFileName(saveFileDialog1.FileName);
                toolStripStatusLabel3.Text = encoding.BodyName;
            }
            encoding = Encoding.GetEncoding(1251);

        }
        void Save()
        {
            File.WriteAllText(pat, this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First().Text, encoding);
            MessageBox.Show("Successful saved");
           
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Black;

            menuStrip1.BackColor = System.Drawing.Color.White;
            menuStrip1.ForeColor = System.Drawing.Color.Black;
            groupBox1.ForeColor = System.Drawing.Color.White;
            toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            toolStripStatusLabel1.BackColor = System.Drawing.Color.Black;           
            toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
            toolStripStatusLabel2.BackColor = System.Drawing.Color.Black;
            newToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            newToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            openToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            toolStripMenuItem2.BackColor = System.Drawing.Color.Black;
            toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            saveAsToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            exitToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            styleToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            styleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            fontsToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            fontsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            aToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            aToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            defaultToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            defaultToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            encodingToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            encodingToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            toolStripStatusLabel3.ForeColor = System.Drawing.Color.White;
            toolStripStatusLabel3.BackColor = System.Drawing.Color.Black;
        }

        private void lightModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            menuStrip1.BackColor = System.Drawing.Color.YellowGreen;
            menuStrip1.ForeColor = System.Drawing.Color.Black;
            groupBox1.ForeColor = System.Drawing.Color.Black;
            toolStripStatusLabel1.BackColor = System.Drawing.Color.White;
            toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;          
            toolStripStatusLabel2.BackColor = System.Drawing.Color.White;
            toolStripStatusLabel2.ForeColor = System.Drawing.Color.Black;
            newToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            newToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            openToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            openToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            toolStripMenuItem2.BackColor = System.Drawing.Color.YellowGreen;
            toolStripMenuItem2.ForeColor = System.Drawing.Color.Black;
            saveAsToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            exitToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            exitToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            styleToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            styleToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            fontsToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            fontsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            aToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            aToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            defaultToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            defaultToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            encodingToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            encodingToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            toolStripStatusLabel3.BackColor = System.Drawing.Color.White;
            toolStripStatusLabel3.ForeColor = System.Drawing.Color.Black;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open";

            // Фильтры файлов в диалоге
            openFileDialog1.Filter = "Text files|*.txt";

            // Номер выбранного по умолчанию фильтра
            openFileDialog1.FilterIndex = 1;

            // Проверка существования выбранного файла
            openFileDialog1.CheckFileExists = true;

            // Разрешить выбор нескольких файлов
            openFileDialog1.Multiselect = false;

            // Открытие диалога
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (countTab>=0)
                {
                    TabPage page = new TabPage(Path.GetFileName(openFileDialog1.FileName));
                    TextBox textBoxInTab = new TextBox();
                    textBoxInTab.Dock = DockStyle.Fill;
                    textBoxInTab.Multiline = true;
                    textBoxInTab.ScrollBars = ScrollBars.Both;
                    encoding = Encoding.GetEncoding(1251);
                    str = File.ReadAllText(openFileDialog1.FileName, encoding);
                    //textBox1.Text = str;
                    textBoxInTab.Text = str;
                    textBoxInTab.Parent = page;
                    toolStripStatusLabel2.Text = Path.GetFileName(openFileDialog1.FileName);
                    //this.tabPage1.Text = Path.GetFileName(openFileDialog1.FileName);
                    this.pat = openFileDialog1.FileName;
                    toolStripStatusLabel3.Text = encoding.BodyName;
                    tabControl1.TabPages.Add(page);
                    tabControl1.SelectedTab = page;
                    countTab++;
                }
                else
                {
                    //TabPage page = new TabPage(Path.GetFileName(openFileDialog1.FileName));
                    //TextBox textBoxInTab = new TextBox();
                    this.textBox1.Dock = DockStyle.Fill;
                    this.textBox1.Multiline = true;
                    this.textBox1.ScrollBars = ScrollBars.Both;
                    encoding = Encoding.GetEncoding(1251);
                    str = File.ReadAllText(openFileDialog1.FileName, encoding);
                    //textBox1.Text = str;
                    this.textBox1.Text = str;
                    this.textBox1.Parent = this.tabPage1;
                    toolStripStatusLabel2.Text = Path.GetFileName(openFileDialog1.FileName);
                    this.tabPage1.Text = Path.GetFileName(openFileDialog1.FileName);
                    this.pat = openFileDialog1.FileName;
                    toolStripStatusLabel3.Text = encoding.BodyName;
                    countTab++;
                    tabControl1.SelectedTab = this.tabPage1;
                    //tabControl1.TabPages.Add(page);
                }
               

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           SaveAs();
            
        }

        void CheckName(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = this.tabControl1.SelectedTab.Text;
            TextBox text =  this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First();           
            this.toolStripStatusLabel1.Text = Convert.ToString(text.SelectionStart);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
           TextBox text =  this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First();
           text.Clear();
           tabControl1.SelectedTab.Text = "new";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (pat == null)
            {
                SaveAs();
            }
            else
            {
                Save();
            }
            
        }

        

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = "X: " + e.X.ToString() + "  Y: " + e.Y.ToString();
        }

        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fn = new FontDialog();
            if (fn.ShowDialog() == DialogResult.OK)
            {
                this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First().Font = fn.Font;
            }
            //fontDialog1.ShowEffects = true;
            //fontDialog1.ShowColor = true;            
            //fontDialog1.MinSize = 8;
            //fontDialog1.MaxSize = 30;


        }


        private void UTF_8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox text = this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First();
            str = text.Text;
            byte[] conv = encoding.GetBytes(str);
            text.Text = Encoding.UTF8.GetString(conv);
            encoding = Encoding.UTF8;
            toolStripStatusLabel3.Text = encoding.BodyName;

        }
            
        private void WINDOS1251ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TextBox text = this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First();
            str = text.Text;
            byte[] conv = encoding.GetBytes(str);
            text.Text = Encoding.GetEncoding(1251).GetString(conv);
            encoding = Encoding.GetEncoding(1251);
            toolStripStatusLabel3.Text = encoding.BodyName;

        }

        private void addNewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage page = new TabPage("new");

            // создание текстового поля внутри вкладки
            TextBox textBox = new TextBox();            
            textBox.Dock = DockStyle.Fill;
            textBox.Multiline = true;      
            textBox.Parent = page;
            textBox.ScrollBars = ScrollBars.Both;
            tabControl1.TabPages.Add(page);
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage item in tabControl1.TabPages)
            {
                saveFileDialog1.Title = "Save";
                saveFileDialog1.Filter = "Text Files|*.txt";
                saveFileDialog1.FilterIndex = 3;
                //saveFileDialog1.CheckFileExists = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    File.WriteAllText(saveFileDialog1.FileName, item.Controls.OfType<TextBox>().First().Text, encoding);

                    MessageBox.Show(saveFileDialog1.FileName + " \nSuccessful saved");
                    sav = true;
                    this.pat = saveFileDialog1.FileName;
                    toolStripStatusLabel2.Text = Path.GetFileName(saveFileDialog1.FileName);
                    toolStripStatusLabel3.Text = encoding.BodyName;
                }
                encoding = Encoding.GetEncoding(1251);
            }
        }
       
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
                     
           
        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.TabPages.Count>1)
            {
                this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
            }
            
        }

       
    }
}
