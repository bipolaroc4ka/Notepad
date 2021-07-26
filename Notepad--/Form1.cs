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
        List<string> pat = new List<string>();
        //string pat = null;
        Encoding encoding = Encoding.GetEncoding(1251);
        string str = "";
        bool sav = false;
        int countTab = 0;
        public Form1() { }
        public Form1(string fileName)
        {
            InitializeComponent();
            if (fileName.Length > 0)
            {
                this.tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Text = File.ReadAllText(fileName, encoding);
                pat.Add(fileName);
                this.tabControl1.SelectedTab.Text = Path.GetFileName(fileName);
                //toolStripStatusLabel2.Text = Path.GetFileName(fileName);
            }
            timer1.Tick += new EventHandler(CheckName);
            timer1.Interval = 100;
            timer1.Start();
        }

        void SaveAs()
        {
            saveFileDialog1.Title = "Save";
            saveFileDialog1.Filter = "Text files|*.txt|All files|*";
            saveFileDialog1.FilterIndex = 1;
            //saveFileDialog1.CheckFileExists = true;
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (this.tabControl1.Visible == true)
                    {
                        if (Convert.ToString(this.tabControl1.SelectedTab.Controls[0].GetType()) == "System.Windows.Forms.TextBox")
                        {
                            File.WriteAllText(saveFileDialog1.FileName, this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First().Text, encoding);

                            MessageBox.Show(saveFileDialog1.FileName + " \nSuccessful saved");
                            sav = true;
                            pat.Add(saveFileDialog1.FileName);
                            toolStripStatusLabel2.Text = Path.GetFileName(saveFileDialog1.FileName);
                            toolStripStatusLabel3.Text = encoding.BodyName;
                        }
                        else if (Convert.ToString(this.tabControl1.SelectedTab.Controls[0].GetType()) == "System.Windows.Forms.RichTextBox")
                        {
                            File.WriteAllText(saveFileDialog1.FileName, this.tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Text, encoding);

                            MessageBox.Show(saveFileDialog1.FileName + " \nSuccessful saved");
                            sav = true;
                            pat.Add(saveFileDialog1.FileName);
                            toolStripStatusLabel2.Text = Path.GetFileName(saveFileDialog1.FileName);
                            toolStripStatusLabel3.Text = encoding.BodyName;
                        }

                    }
                    else if (this.tabControl1.Visible == false)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, this.ActiveMdiChild.Controls.OfType<RichTextBox>().First().Text, encoding);

                        MessageBox.Show(saveFileDialog1.FileName + " \nSuccessful saved");
                        sav = true;
                        pat.Add(saveFileDialog1.FileName);
                        this.ActiveMdiChild.Text = Path.GetFileName(saveFileDialog1.FileName);
                        toolStripStatusLabel2.Text = Path.GetFileName(saveFileDialog1.FileName);
                        toolStripStatusLabel3.Text = encoding.BodyName;
                    }
                }

                encoding = Encoding.GetEncoding(1251);
            }
            catch (Exception)
            {

                MessageBox.Show("Can`t save");
            }
            

        }
       
        void Save()
        {

            if (this.tabControl1.Visible == true)
            {
                foreach (var item in pat)
                {
                    if (Convert.ToString(this.tabControl1.SelectedTab.Controls[0].GetType()) == "System.Windows.Forms.TextBox")
                    {
                        if (item.Contains(this.tabControl1.SelectedTab.Text))
                        {
                            File.WriteAllText(item, this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First().Text, encoding);
                            MessageBox.Show("Successful saved");
                        }
                    }
                    else if (Convert.ToString(this.tabControl1.SelectedTab.Controls[0].GetType()) == "System.Windows.Forms.RichTextBox")
                    {
                        if (item.Contains(this.tabControl1.SelectedTab.Text))
                        {
                            File.WriteAllText(item, this.tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Text, encoding);
                            MessageBox.Show("Successful saved");
                        }
                    }

                }

            }
            else if(this.tabControl1.Visible == false)
            {
                foreach (var item in pat)
                {
                   if (item.Contains(this.ActiveMdiChild.Text))
                   {
                       File.WriteAllText(item, this.ActiveMdiChild.Controls.OfType<RichTextBox>().First().Text, encoding);
                       MessageBox.Show("Successful saved");
                   }
                  


                }
            }
            


        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Black;

            menuStrip1.BackColor = System.Drawing.Color.Black;
            menuStrip1.ForeColor = System.Drawing.Color.White;
            groupBox1.ForeColor = System.Drawing.Color.White;
            saveAllToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            saveAllToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            addNewTabToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            addNewTabToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            addNewWindowToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            addNewWindowToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            closeTabToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            closeTabToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            toolStripStatusLabel1.BackColor = System.Drawing.Color.Black;
            toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
            toolStripStatusLabel2.BackColor = System.Drawing.Color.Black;
            newToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            newToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            openToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            openInTabToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            openInTabToolStripMenuItem.ForeColor = System.Drawing.Color.White;
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
            addNewTabToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            addNewTabToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            addNewWindowToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            addNewWindowToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            closeTabToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            closeTabToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            saveAllToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            saveAllToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
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
            openInTabToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            openInTabToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
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
            openFileDialog1.Filter = "Text files|*.txt|All files|*";

            // Номер выбранного по умолчанию фильтра
            openFileDialog1.FilterIndex = 1;

            // Проверка существования выбранного файла
            openFileDialog1.CheckFileExists = true;

            // Разрешить выбор нескольких файлов
            openFileDialog1.Multiselect = false;

            // Открытие диалога
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (this.tabControl1.Visible == true)
                {
                    if (countTab >= 0)
                    {
                        TabPage page = new TabPage(Path.GetFileName(openFileDialog1.FileName));
                        RichTextBox textBoxInTab = new RichTextBox();
                        textBoxInTab.Dock = DockStyle.Fill;
                        textBoxInTab.Multiline = true;
                        textBoxInTab.Font = this.richTextBox1.Font;
                        encoding = Encoding.GetEncoding(1251);
                        str = File.ReadAllText(openFileDialog1.FileName, encoding);
                        //textBox1.Text = str;
                        textBoxInTab.Text = str;
                        textBoxInTab.Parent = page;
                        toolStripStatusLabel2.Text = Path.GetFileName(openFileDialog1.FileName);
                        //this.tabPage1.Text = Path.GetFileName(openFileDialog1.FileName);
                        pat.Add(openFileDialog1.FileName);
                        toolStripStatusLabel3.Text = encoding.BodyName;
                        tabControl1.TabPages.Add(page);
                        tabControl1.SelectedTab = page;
                        countTab++;
                    }
                    else
                    {
                        //TabPage page = new TabPage(Path.GetFileName(openFileDialog1.FileName));
                        //TextBox textBoxInTab = new TextBox();
                        this.richTextBox1.Dock = DockStyle.Fill;
                        this.richTextBox1.Multiline = true;                        
                        encoding = Encoding.GetEncoding(1251);
                        str = File.ReadAllText(openFileDialog1.FileName, encoding);
                        //textBox1.Text = str;
                        this.richTextBox1.Text = str;
                        this.richTextBox1.Parent = this.tabPage1;
                        toolStripStatusLabel2.Text = Path.GetFileName(openFileDialog1.FileName);
                        this.tabPage1.Text = Path.GetFileName(openFileDialog1.FileName);
                        pat.Add(openFileDialog1.FileName);
                        toolStripStatusLabel3.Text = encoding.BodyName;
                        countTab++;
                        tabControl1.SelectedTab = this.tabPage1;
                        //tabControl1.TabPages.Add(page);
                    }
                }
                else if(this.tabControl1.Visible == false)
                {
                    ChildForm f2 = new ChildForm();
                    f2.MdiParent = this;
                    f2.Icon = this.Icon;
                    f2.Text = Path.GetFileName(openFileDialog1.FileName);
                    RichTextBox rich = new RichTextBox();
                    str = File.ReadAllText(openFileDialog1.FileName, encoding);
                    rich.Text = str;
                    rich.Dock = DockStyle.Fill;
                    rich.Multiline = true;
                    f2.Controls.Add(rich);
                    f2.FormClosing += F2_FormClosing;
                    // показ дочернего MDI-окна
                    f2.Show();
                   
                }
                


            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();

        }

        void CheckName(object sender, EventArgs e)
        {
            try
            {
                if (this.tabControl1.Visible == false)
                {
                    if (this.MdiChildren == null)
                    {
                        this.toolStripStatusLabel2.Text = "new";

                    }
                    if (this.ActiveMdiChild.Controls[0] is TextBox)
                    {
                        TextBox t = this.ActiveMdiChild.Controls.OfType<TextBox>().First();
                        this.toolStripStatusLabel1.Text = Convert.ToString(t.SelectionStart) + "/" + Convert.ToString(t.Text.Length);
                        this.toolStripStatusLabel2.Text = this.ActiveMdiChild.Text;
                    }
                    else if (this.ActiveMdiChild.Controls[0] is RichTextBox)
                    {
                        RichTextBox t = this.ActiveMdiChild.Controls.OfType<RichTextBox>().First();
                        this.toolStripStatusLabel1.Text = Convert.ToString(t.SelectionStart) + "/" + Convert.ToString(t.Text.Length);
                        this.toolStripStatusLabel2.Text = this.ActiveMdiChild.Text;
                    }

                }
                else if (this.tabControl1.Visible == true)
                {
                    this.toolStripStatusLabel2.Text = this.tabControl1.SelectedTab.Text;
                    if (this.tabControl1.SelectedTab.Controls[0] is TextBox)
                    {
                        TextBox text = this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First();
                        this.toolStripStatusLabel1.Text = Convert.ToString(text.SelectionStart) + "/" + Convert.ToString(text.Text.Length);
                    }
                    else if (this.tabControl1.SelectedTab.Controls[0] is RichTextBox)
                    {
                        RichTextBox text = this.tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First();
                        this.toolStripStatusLabel1.Text = Convert.ToString(text.SelectionStart) + "/" + Convert.ToString(text.Text.Length);
                    }

                }
            }
            catch (Exception)
            {

            }
            



        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.Visible == true)
            {
                if (this.tabControl1.SelectedTab.Controls[0] is TextBox)
                {
                    TextBox text = this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First();
                    text.Clear();
                    tabControl1.SelectedTab.Text = "new";
                }
                else if (this.tabControl1.SelectedTab.Controls[0] is RichTextBox)
                {
                    RichTextBox text = this.tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First();
                    text.Clear();
                    tabControl1.SelectedTab.Text = "new";
                }
            }
            else if(this.tabControl1.Visible == false)
            {
                this.ActiveMdiChild.Controls.OfType<RichTextBox>().First().Clear();
                this.ActiveMdiChild.Text = "new";
            }
            
           
        }
        private void SaveClose(object sender, EventArgs e)
        {
            saveAllToolStripMenuItem_Click(sender, e);
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.Visible == true)
            {
                if (this.tabControl1.SelectedTab.Text == "new")
                {
                    SaveAs();
                }
                else
                {
                    Save();

                }
            }
            else if(this.tabControl1.Visible == false)
            {
                if (this.ActiveMdiChild.Text == "new")
                {
                    SaveAs();
                }
                else
                {
                    Save();

                }
            }
            

        }

        
      
        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fn = new FontDialog();
            if (fn.ShowDialog() == DialogResult.OK)
            {
                if (this.tabControl1.Visible == true)
                {
                    if (this.tabControl1.SelectedTab.Controls[0] is TextBox)
                    {
                        
                        this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First().Font = fn.Font;
                    }
                    else if(this.tabControl1.SelectedTab.Controls[0] is RichTextBox)
                    {
                       
                        this.tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Font = fn.Font;
                    }

                }
                else if(this.tabControl1.Visible == false)
                {
                    if (this.ActiveMdiChild.Controls[0] is TextBox)
                    {
                        this.ActiveMdiChild.Controls.OfType<TextBox>().First().Font = fn.Font;
                    }
                    else if (this.ActiveMdiChild.Controls[0] is RichTextBox)
                    {
                        this.ActiveMdiChild.Controls.OfType<RichTextBox>().First().Font = fn.Font;
                    }
                }
                
            }
            
           
        }


        private void UTF_8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabControl1.Visible == true)
                {
                    if (this.tabControl1.SelectedTab.Controls[0] is TextBox)
                    {
                        TextBox text = this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First();
                        str = text.Text;
                        byte[] conv = encoding.GetBytes(str);
                        text.Text = Encoding.UTF8.GetString(conv);
                        encoding = Encoding.UTF8;
                        toolStripStatusLabel3.Text = encoding.BodyName;
                    }
                    else if (this.tabControl1.SelectedTab.Controls[0] is RichTextBox)
                    {
                        RichTextBox text = this.tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First();
                        str = text.Text;
                        byte[] conv = encoding.GetBytes(str);
                        text.Text = Encoding.UTF8.GetString(conv);
                        encoding = Encoding.UTF8;
                        toolStripStatusLabel3.Text = encoding.BodyName;
                    }
                }
                else if (this.tabControl1.Visible == false)
                {
                    RichTextBox text = this.ActiveMdiChild.Controls.OfType<RichTextBox>().First();
                    str = text.Text;
                    byte[] conv = encoding.GetBytes(str);
                    text.Text = Encoding.UTF8.GetString(conv);
                    encoding = Encoding.UTF8;
                    toolStripStatusLabel3.Text = encoding.BodyName;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Fail!");
            }
            
            
            

        }
            
        private void WINDOS1251ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabControl1.Visible == true)
                {
                    if (this.tabControl1.SelectedTab.Controls[0] is TextBox)
                    {
                        TextBox text = this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First();
                        str = text.Text;
                        byte[] conv = encoding.GetBytes(str);
                        text.Text = Encoding.GetEncoding(1251).GetString(conv);
                        encoding = Encoding.GetEncoding(1251);
                        toolStripStatusLabel3.Text = encoding.BodyName;
                    }
                    else if (this.tabControl1.SelectedTab.Controls[0] is RichTextBox)
                    {
                        RichTextBox text = this.tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First();
                        str = text.Text;
                        byte[] conv = encoding.GetBytes(str);
                        text.Text = Encoding.GetEncoding(1251).GetString(conv);
                        encoding = Encoding.GetEncoding(1251);
                        toolStripStatusLabel3.Text = encoding.BodyName;
                    }
                }
                else if (this.tabControl1.Visible == false)
                {
                    RichTextBox text = this.ActiveMdiChild.Controls.OfType<RichTextBox>().First();
                    str = text.Text;
                    byte[] conv = encoding.GetBytes(str);
                    text.Text = Encoding.GetEncoding(1251).GetString(conv);
                    encoding = Encoding.GetEncoding(1251);
                    toolStripStatusLabel3.Text = encoding.BodyName;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Fail");
            }
            
            

        }

        private void addNewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage page = new TabPage("new");

            // создание текстового поля внутри вкладки
            RichTextBox textBox = new RichTextBox();            
            textBox.Dock = DockStyle.Fill;
            textBox.Font = this.richTextBox1.Font;
            textBox.Multiline = true;      
            textBox.Parent = page;            
            tabControl1.TabPages.Add(page);
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.Visible == true)
            {
                foreach (TabPage item in tabControl1.TabPages)
                {
                    saveFileDialog1.Title = "Save";
                    saveFileDialog1.Filter = "Text files|*.txt|All files|*";
                    saveFileDialog1.FilterIndex = 1;
                    //saveFileDialog1.CheckFileExists = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (this.tabControl1.SelectedTab.Controls[0] is TextBox)
                        {
                            File.WriteAllText(saveFileDialog1.FileName, item.Controls.OfType<TextBox>().First().Text, encoding);

                            MessageBox.Show(saveFileDialog1.FileName + " \nSuccessful saved");
                            sav = true;
                            toolStripStatusLabel2.Text = Path.GetFileName(saveFileDialog1.FileName);
                            toolStripStatusLabel3.Text = encoding.BodyName;
                        }
                        else if (this.tabControl1.SelectedTab.Controls[0] is RichTextBox)
                        {
                            File.WriteAllText(saveFileDialog1.FileName, item.Controls.OfType<RichTextBox>().First().Text, encoding);

                            MessageBox.Show(saveFileDialog1.FileName + " \nSuccessful saved");
                            sav = true;
                            toolStripStatusLabel2.Text = Path.GetFileName(saveFileDialog1.FileName);
                            toolStripStatusLabel3.Text = encoding.BodyName;
                        }

                    }
                    encoding = Encoding.GetEncoding(1251);
                }
            }
            else if(this.tabControl1.Visible == false)
            {
                foreach (Form item in this.MdiChildren)
                {
                    saveFileDialog1.Title = "Save";
                    saveFileDialog1.Filter = "Text files|*.txt|All files|*";
                    saveFileDialog1.FilterIndex = 1;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        
                        File.WriteAllText(saveFileDialog1.FileName, item.Controls.OfType<RichTextBox>().First().Text, encoding);

                        MessageBox.Show(saveFileDialog1.FileName + " \nSuccessful saved");
                        sav = true;
                        toolStripStatusLabel2.Text = Path.GetFileName(saveFileDialog1.FileName);
                        toolStripStatusLabel3.Text = encoding.BodyName;
                    }
                    
                }
                encoding = Encoding.GetEncoding(1251);
            }
            
        }
        Form2 findDialog = null;
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (findDialog == null)
            {
                findDialog = new Form2();
                findDialog.Find += FindWord;
                findDialog.Icon = this.Icon;
                
            }
            else
            {
                findDialog = null;
                findDialog = new Form2();
                findDialog.Find += FindWord;
                findDialog.Icon = this.Icon;
                
            }

            findDialog.Show();
            //Form2 form2 = new Form2();
            //replaceDialog.PerformReplace += ReplaceDialog_PerformReplace;
            //form2.BackColor = Color.Gray;
            //form2.Icon = this.Icon;
            //form2.BackColor = this.BackColor;
            //form2.Show(this);


        }
        //hi hi hi hi hi        
        public static void Find(RichTextBox rtb, String word, Color color)
        {
            int pos = 0;
            string s = rtb.Text;
            if (word == "" || word == " " || word == "." || word == ",")
            {
                return;
            }
            for (int i = 0; ;)
            {
                int j = s.IndexOf(word, i);
                if (j < 0) break;
                rtb.SelectionStart = j;
                rtb.SelectionLength = word.Length;
                rtb.SelectionColor = color;
                i = j + 1;
            }
            rtb.SelectionStart = pos;
            rtb.SelectionLength = 0;
        }
        private void FindWord(string Source)
        {
            try
            {
                if (this.tabControl1.Visible == true)
                {
                    if (this.tabControl1.SelectedTab.Controls[0] is TextBox)
                    {
                        TextBox mainTextBox = tabControl1.SelectedTab.Controls[0] as TextBox;
                        RichTextBox temp = new RichTextBox();
                        temp.Text = mainTextBox.Text;
                        this.tabControl1.SelectedTab.Controls.Remove(this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First());
                        temp.Dock = DockStyle.Fill;
                        temp.Multiline = true;
                        temp.Parent = this.tabControl1.SelectedTab;
                        Find(temp, Source, Color.Red);

                    }
                    else if (this.tabControl1.SelectedTab.Controls[0] is RichTextBox)
                    {
                        Find(this.tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First(), Source, Color.Red);

                    }
                }
                else if (this.tabControl1.Visible == false)
                {
                    Find(this.ActiveMdiChild.Controls.OfType<RichTextBox>().First(), Source, Color.Red);
                }
            }
            catch (Exception)
            {

               
            }
            
            
           
            
           

        }
        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.TabPages.Count>1)
            {
                this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
            }
            
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.Visible == false)
            {
                this.tabControl1.Visible = true;
            }
            TabPage page = new TabPage("new");

            // создание текстового поля внутри вкладки
            TextBox textBox = new TextBox();
            textBox.Dock = DockStyle.Fill;
            textBox.Multiline = true;
            textBox.Parent = page;
            textBox.ScrollBars = ScrollBars.Both;           
            tabControl1.TabPages.Add(page);
        }

        private void closeTabToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.TabPages.Count > 1)
            {
                this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
            }
        }

        private void deselectWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabControl1.Visible == true)
                {
                    if (this.tabControl1.SelectedTab.Controls[0] is TextBox)
                    {
                        TextBox textbox = this.tabControl1.SelectedTab.Controls.OfType<TextBox>().First();
                        textbox.ForeColor = Color.Black;

                    }
                    else if (this.tabControl1.SelectedTab.Controls[0] is RichTextBox)
                    {
                        RichTextBox textbox = this.tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First();

                        textbox.Select(textbox.SelectionStart, textbox.Text.Length);
                        textbox.SelectionColor = Color.Black;

                    }
                }
                else if (this.tabControl1.Visible == false)
                {
                    RichTextBox textbox = this.ActiveMdiChild.Controls.OfType<RichTextBox>().First();

                    textbox.Select(textbox.SelectionStart, textbox.Text.Length);
                    textbox.SelectionColor = Color.Black;
                }
            }
            catch (Exception)
            {

                
            }
            
            

        }
        Form3 replaceDialog = null;
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (replaceDialog == null)
            {
                replaceDialog = new Form3();
                replaceDialog.Replace += ReplaceDialog_PerformReplace;
                replaceDialog.Icon = this.Icon;
                
            }
            else
            {
                replaceDialog = null;
                replaceDialog = new Form3();
                replaceDialog.Replace += ReplaceDialog_PerformReplace;
                replaceDialog.Icon = this.Icon;
                
            }

            replaceDialog.Show();
        }
        private void ReplaceDialog_PerformReplace(string Source, string ReplaceStr)
        {
            try
            {
                if (this.tabControl1.Visible == true)
                {
                    if (tabControl1.SelectedTab.Controls[0] is TextBox)
                    {
                        TextBox mainTextBox = tabControl1.SelectedTab.Controls[0] as TextBox;
                        string doc = mainTextBox.Text;
                        string newDoc = doc.Replace(Source, ReplaceStr);
                        mainTextBox.Text = newDoc;
                    }
                    else if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
                    {
                        RichTextBox mainTextBox = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                        string doc = mainTextBox.Text;
                        string newDoc = doc.Replace(Source, ReplaceStr);
                        mainTextBox.Text = newDoc;
                    }
                }
                else if (this.tabControl1.Visible == false)
                {
                    RichTextBox mainTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
                    string doc = mainTextBox.Text;
                    string newDoc = doc.Replace(Source, ReplaceStr);
                    mainTextBox.Text = newDoc;
                }
            }
            catch (Exception)
            {

                
            }
            
            
        }

        private void addNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] form = this.MdiChildren;
            if (form.Length==0)
            {
                this.newTabToolStripMenuItem.Visible = false;
                this.closeTabToolStripMenuItem.Visible = false;
                this.addNewTabToolStripMenuItem.Visible = false;
                this.closeTabToolStripMenuItem1.Visible = false;
                this.newWindowToolStripMenuItem.Visible = true;
                this.openInTabToolStripMenuItem.Visible = true;
                this.addNewWindowToolStripMenuItem.Visible = false;
                foreach (TabPage item in this.tabControl1.TabPages)
                {
                    ChildForm f2 = new ChildForm();
                    //RichTextBox text = new RichTextBox();

                    if (item.Controls[0] is TextBox)
                    {
                        TextBox text = new TextBox();
                        text.Dock = DockStyle.Fill;
                        text.Multiline = true;
                        text.ScrollBars = ScrollBars.Both;
                        text.Text = item.Controls.OfType<TextBox>().First().Text;
                        f2.Controls.Add(text);
                    }
                    else if (item.Controls[0] is RichTextBox)
                    {
                        RichTextBox text = new RichTextBox();
                        text.Dock = DockStyle.Fill;
                        text.Multiline = true;
                        text.Text = item.Controls.OfType<RichTextBox>().First().Text;
                        f2.Controls.Add(text);
                    }
                    this.tabControl1.TabPages.Remove(item);

                    f2.MdiParent = this;
                    f2.Icon = this.Icon;
                    f2.Text = item.Text;
                    f2.FormClosing += F2_FormClosing;
                    // показ дочернего MDI-окна
                    f2.Show();
                }
                this.tabControl1.Visible = false;
            }
            
            //foreach (Control item in this.Controls)
            //{
            //    item.Dispose();
            //}
            //ChildForm f2 = new ChildForm();
            
            //f2.MdiParent = this;
            //f2.Icon = this.Icon;
            //f2.Text = this.Text;
            
            //// показ дочернего MDI-окна
            //f2.Show();
        }

        private void F2_FormClosing(object sender, FormClosingEventArgs e)
        {           
                
            if (e.CloseReason == CloseReason.MdiFormClosing)
            {
                e.Cancel = false;
                this.Form1_FormClosing(sender, e);
            }
            else
            {
                string so = e.CloseReason.ToString();
                string s1 = so.Replace(so, "Сохранить документ перед выходом?");
                DialogResult result = MessageBox.Show(s1, "Выход", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                if (result == DialogResult.No)
                {
                    e.Cancel = false;
                }
                if (result == DialogResult.Yes)
                {
                    toolStripMenuItem2_Click(sender, e);
                    if (sav == true)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }

                }
            }
                // если пользователь нажал на кнопку 'No'

               
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm f2 = new ChildForm();
            f2.MdiParent = this;
            f2.Icon = this.Icon;
            f2.Text = "new";
            RichTextBox text = new RichTextBox();
            text.Dock = DockStyle.Fill;
            text.Multiline = true;            
            f2.Controls.Add(text);
            f2.FormClosing += F2_FormClosing;
            // показ дочернего MDI-окна
            f2.Show();
        }

        private void openInTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] form = this.MdiChildren;
            this.newTabToolStripMenuItem.Visible = true;
            this.closeTabToolStripMenuItem.Visible = true;
            this.addNewTabToolStripMenuItem.Visible = true;
            this.closeTabToolStripMenuItem1.Visible = true;
            this.newWindowToolStripMenuItem.Visible = false;
            this.openInTabToolStripMenuItem.Visible = false;
            this.addNewWindowToolStripMenuItem.Visible = true;
            foreach (Form item in form)
            {
                TabPage page = new TabPage("new");

                // создание текстового поля внутри вкладки
               
                
                if (item.Controls[0] is RichTextBox)
                {
                    RichTextBox textBox = new RichTextBox();
                    textBox.Dock = DockStyle.Fill;
                    textBox.Multiline = true;
                    textBox.Parent = page;
                    RichTextBox text = item.Controls.OfType<RichTextBox>().First();
                    textBox.Text = text.Text;
                    this.tabControl1.TabPages.Add(page);
                    this.tabControl1.Visible = true;
                    
                }
                else if(item.Controls[0] is TextBox)
                {
                    TextBox textBox = new TextBox();
                    textBox.Dock = DockStyle.Fill;
                    textBox.Multiline = true;
                    textBox.Parent = page;
                    TextBox text = item.Controls.OfType<TextBox>().First();
                    textBox.Text = text.Text;
                    this.tabControl1.TabPages.Add(page);
                    this.tabControl1.Visible = true;
                    
                }
                item.Dispose();


            }
            
        }
    }
}
