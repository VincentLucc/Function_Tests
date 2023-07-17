using DevExpress.XtraEditors;
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

namespace TextConvert
{
    public partial class Form1 : Form
    {

        int ilineCountLimit = 20;
        int iMaxCharPerLine = 5000;
        int iIgnoreLines = 0;
        List<string> Lines = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            buttonEdit1.Click += ButtonEdit1_Click;
        }

        private void ButtonEdit1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.Text = fileDialog.FileName;
            }
        }

        private void buttonEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void COnvertButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(buttonEdit1.Text))
            {
                MessageBox.Show("Please select a text file.");
                return;
            }


            using (FileStream stream = File.OpenRead(buttonEdit1.Text))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    int iIndex = 0;
                    string sLine = "";
                    Lines.Clear();
                    while ((sLine = reader.ReadLine()) != null)
                    {
                        iIndex++;
                        if (iIndex > ilineCountLimit) break;
                        if (iIndex < iIgnoreLines + 1) continue;
                        if (sLine.Length > iMaxCharPerLine)
                        {
                            sLine = sLine.Substring(0, iMaxCharPerLine);
                        }
                        Lines.Add(sLine);
                    }

                    //Save file
                    SaveFileDialog fileDialog = new SaveFileDialog();
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllLines(fileDialog.FileName, Lines);
                        Lines.Clear();
                    }
                }
            }
        }

        private void LineCountSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            ilineCountLimit = (int)LineCountSpinEdit.Value;
        }

        private void MaxCharPerLineSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            iMaxCharPerLine = (int)MaxCharPerLineSpinEdit.Value;
        }

        private void IgnoreLinesSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            iIgnoreLines = (int)IgnoreLinesSpinEdit.Value;
        }
    }
}
