using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB03_02
{
    public partial class Word : Form
    {
        private string filePath = "Untitled";
        public Word()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFonts();
            LoadSizes();
            cmbFonts.Text = "Consolas";
            cmbSizes.Text = "20";

            rtxtForm.SelectionFont = new Font(cmbFonts.Text, float.Parse(cmbSizes.Text));
        }

        private void LoadFonts()
        {
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                cmbFonts.Items.Add(font.Name);
            }
        }

        private void LoadSizes()
        {
            List<int> sizes = new List<int>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var item in sizes) 
            {
                cmbSizes.Items.Add(item);
            }
        }

        private void cmbFontsAndSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFonts.Text != "" && cmbSizes.Text != "")
            {
                rtxtForm.SelectionFont = new Font(cmbFonts.Text, float.Parse(cmbSizes.Text));
            }
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            Font oldFont = rtxtForm.SelectionFont;
            FontStyle fontStyle = rtxtForm.SelectionFont.Style;

            /**Regular Style**/
            if (fontStyle == FontStyle.Regular)
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Bold);
            }
            /**Bold Style**/
            else if (fontStyle == FontStyle.Bold)
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Regular);
            }
            /**Italic Style**/
            else if (fontStyle == FontStyle.Italic)
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Bold ^ FontStyle.Italic);
            }
            /**Underline Style**/
            else if (fontStyle == FontStyle.Underline)
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Bold ^ FontStyle.Underline);
            }
            /**Bold feat Italic Style**/
            else if (fontStyle == (FontStyle.Bold ^ FontStyle.Italic))
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Italic);
            }
            /**Bold feat Underline Style**/
            else if (fontStyle == (FontStyle.Bold ^ FontStyle.Underline))
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Underline);
            }
            /**Italic feat Underline Style**/
            else if (fontStyle == (FontStyle.Italic ^ FontStyle.Underline))
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Bold ^ FontStyle.Italic ^ FontStyle.Underline);
            }
            /**Bold feat Italic feat Underline Style**/
            else if (fontStyle == (FontStyle.Bold ^ FontStyle.Italic ^ FontStyle.Underline))
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Italic ^ FontStyle.Underline);
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            Font oldFont = rtxtForm.SelectionFont;
            FontStyle fontStyle = rtxtForm.SelectionFont.Style;

            /**Regular Style**/
            if (fontStyle == FontStyle.Regular)
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Italic);
            }
            /**Bold Style**/
            else if (fontStyle == FontStyle.Bold)
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Bold ^ FontStyle.Italic);
            }
            /**Italic Style**/
            else if (fontStyle == FontStyle.Italic)
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Regular);
            }
            /**Underline Style**/
            else if (fontStyle == FontStyle.Underline)
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Italic ^ FontStyle.Underline);
            }
            /**Bold feat Italic Style**/
            else if (fontStyle == (FontStyle.Bold ^ FontStyle.Italic))
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Bold);
            }
            /**Bold feat Underline Style**/
            else if (fontStyle == (FontStyle.Bold ^ FontStyle.Underline))
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Bold ^ FontStyle.Italic ^ FontStyle.Underline);
            }
            /**Italic feat Underline Style**/
            else if (fontStyle == (FontStyle.Italic ^ FontStyle.Underline))
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Underline);
            }
            /**Bold feat Italic feat Underline Style**/
            else if (fontStyle == (FontStyle.Bold ^ FontStyle.Italic ^ FontStyle.Underline))
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Bold ^ FontStyle.Underline);
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            Font oldFont = rtxtForm.SelectionFont;
            FontStyle fontStyle = rtxtForm.SelectionFont.Style;

            /**Regular Style**/
            if (fontStyle == FontStyle.Regular)
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Underline);
            }
            /**Bold Style**/
            else if (fontStyle == FontStyle.Bold)
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Bold ^ FontStyle.Underline);
            }
            /**Italic Style**/
            else if (fontStyle == FontStyle.Italic)
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Italic ^ FontStyle.Underline);
            }
            /**Underline Style**/
            else if (fontStyle == FontStyle.Underline)
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Regular);
            }
            /**Bold feat Italic Style**/
            else if (fontStyle == (FontStyle.Bold ^ FontStyle.Italic))
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Bold ^ FontStyle.Italic ^ FontStyle.Underline);
            }
            /**Bold feat Underline Style**/
            else if (fontStyle == (FontStyle.Bold ^ FontStyle.Underline))
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Bold);
            }
            /**Italic feat Underline Style**/
            else if (fontStyle == (FontStyle.Italic ^ FontStyle.Underline))
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Italic);
            }
            /**Bold feat Italic feat Underline Style**/
            else if (fontStyle == (FontStyle.Bold ^ FontStyle.Italic ^ FontStyle.Underline))
            {
                rtxtForm.SelectionFont = new Font(oldFont, FontStyle.Bold ^ FontStyle.Italic);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            rtxtForm.Text = "";
            cmbFonts.Text = "Consolas";
            cmbSizes.Text = "20";
            filePath = "Untitled";
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát?", "Exit", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                this.Close();
            } 
            else
            {
                return;
            }
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (filePath == "Untitled")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = "*.docx";
                save.Filter = "Microsoft Office Word | *.docx";
                if (save.ShowDialog() == DialogResult.OK && save.FileName.Length > 0)
                {
                    rtxtForm.SaveFile(save.FileName, RichTextBoxStreamType.RichText);
                }
            }
            else
            {
                MessageBox.Show("Lưu thành công", "Success", MessageBoxButtons.OK);
                rtxtForm.SaveFile(filePath, RichTextBoxStreamType.RichText);
            }
        }

        private void tsOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Microsoft Office Word | *.docx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rtxtForm.LoadFile(openFileDialog.FileName);
            }
            filePath = openFileDialog.FileName;
        }
    }
}