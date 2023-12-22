using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Take_notes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dr = new SaveFileDialog();
            dr.Filter = "Doc File|*.docx";
            if (dr.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SaveFile(dr.FileName);
                MessageBox.Show("Saved successfully!", "Address File : " + dr.FileName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void changeColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();   
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.ForeColor = colorDialog.Color;
            }
        }

        private void changeFontButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();  
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.Font = fontDialog.Font;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.Text.Length > 0)
            {
                
                if (MessageBox.Show("Are you sure? You have got text written in text box.", "Cleaning text box ..", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    richTextBox.Clear();
                }
            }    
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open a Text File";
            ofd.Filter = "Doc Files | *.docx"; 
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                richTextBox.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
    }
}
