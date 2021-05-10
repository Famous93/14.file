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

namespace _15_file
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private String EditorFileName = "Untitled";
        private void SetFormTitleText()
        {
            // Tiedoston nimi formiin. 
            FileInfo fileinfo = new FileInfo(EditorFileName);
            base.Text = fileinfo.Name + " - Editor";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorFileName = "Untitled";
            Muisti.Clear();
            SetFormTitleText();
        }
        private void Readfile()
        {
            try
            {
                // Luodaan StreamReader objekti ja luetaan tiedosto. 
                using (StreamReader Reader = new StreamReader(EditorFileName))
                {
                    // Luku 
                    Muisti.Clear();
                    Muisti.Text = Reader.ReadToEnd();
                }
            }
            catch (IOException ex)

            {
                MessageBox.Show("Error: " + ex.Message, "Open File",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Savefile()
        {
            try
            {
                // Luodaan SteramWriter objekti ja kirjoitetaan teksti tiedostoon. 
                using (StreamWriter StrWriter = new StreamWriter(EditorFileName))
                {
                    // Kirjoitus 
                    StrWriter.Write(Muisti.Text);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Save File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDlg = new OpenFileDialog();
            OpenFileDlg.Title = "Open";
            OpenFileDlg.ShowReadOnly = true;
            OpenFileDlg.Filter = "Text documents (*.txt)|*.txt|All files|*.*";
            // Avataan windowsin standardi avausdialogi. 
            if (OpenFileDlg.ShowDialog() == DialogResult.OK)
            {
                // Talletetaan tiedoston nimi ja polku lukemista varten. 
                EditorFileName = OpenFileDlg.FileName;
                // Luetaan tiedosotn sisältö ja tuodaan se näytölle. 
                Readfile();
                SetFormTitleText();

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EditorFileName == "Untitled")
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                Savefile();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Luodaan standardi talletusdialogiobjekti ja alustetaan se. 
            SaveFileDialog SaveFileDlg = new SaveFileDialog();
            SaveFileDlg.Filter = "Text documents (*.txt)|*.txt|All files|*.*";
            // Avataan windowsin standardi talletusdialogi. 
            if (SaveFileDlg.ShowDialog() == DialogResult.OK)
            {
                // Talletetaan tiedoston nimi ja polku talletusta varten. 
                EditorFileName = SaveFileDlg.FileName;
                Savefile();
                SetFormTitleText();

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
 }
