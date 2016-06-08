using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Super_Compilation_CS
{
    public partial class Form1 : Form
    {
        bool marg = false;
        string file = "";
        public SaveFileDialog save = new SaveFileDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void пускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe", save.FileName);
            string[] s = save.FileName.Split(Convert.ToChar("\\"));
            string[] file_name = s[s.Length - 1].Split('.');

            Process.Start(file_name[0] + ".exe");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            scintilla1.ConfigurationManager.Language = "cs";
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file += " /t:exe";


            save.Filter = "cs file (*.cs)|*.cs";
            if (save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, scintilla1.Text);



            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Visible = false;
            scintilla1.Text = " ";
        }


        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "cs file(*.cs)|*.cs";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                scintilla1.Text = File.ReadAllText(open.FileName);
            }
            scintilla1.Visible = true;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Visible = true;
            scintilla1.Text = " ";

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scintilla1.Visible == false)
            {
                сохранитьToolStripMenuItem.Enabled = false;
                закрытьToolStripMenuItem.Enabled = false;
            }
            else
            {
                сохранитьToolStripMenuItem.Enabled = true;
                закрытьToolStripMenuItem.Enabled = true;
            }
        }
    }
}