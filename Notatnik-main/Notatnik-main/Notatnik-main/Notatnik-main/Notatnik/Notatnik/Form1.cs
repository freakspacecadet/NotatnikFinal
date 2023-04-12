using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notatnik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool zapisany;
        string name;
        private void Form1_Load(object sender, EventArgs e)
        {
            zapisany = true;
            name = "Untitled";
            richTextBox1.Font = new Font(richTextBox1.Font.Name, 10,
                richTextBox1.Font.Style, richTextBox1.Font.Unit);
        }

        private void finishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zapisany == true)
            {
                Application.Exit();
            }
            else
            {
                ;

                if (MessageBox.Show("Czy na pewno chcesz odrzucić wszystkie zmiany?", "Ostrzeżenie", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    Application.Exit();
                }


            }
            
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notes. Scalable window. .rtf format. (c) 2023", "Notatnik");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zapisany == true)
            {
                saveToolStripMenuItem_Click(sender, e);
                richTextBox1.Text = "";
                zapisany = true;
                label1.Text = "saved";
            }
            else
            {
                //MessageBox.Show("Czy chcesz zapisać zmiany?", "Ostrzeżenie", MessageBoxButtons.YesNoCancel);
                var result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Ostrzeżenie", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                    if (zapisany == true)
                    {
                        richTextBox1.Text = "";
                        zapisany = true;
                        label1.Text = "saved";
                    }
                    
                }
                else if (result == DialogResult.No)
                {
                    richTextBox1.Text = "";
                    zapisany = true;
                    label1.Text = "saved";
                }
                
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zapisany == true)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //openFileDialog1.ShowDialog();
                    if (openFileDialog1.DefaultExt == ".rtx")
                    {
                        richTextBox1.LoadFile(openFileDialog1.FileName);
                        name = openFileDialog1.FileName;
                    }
                    else
                    {
                        MessageBox.Show("Niepoprawny format", "Błąd", MessageBoxButtons.OK);
                    }
                    //richTextBox1.LoadFile(openFileDialog1.FileName);
                   // name = openFileDialog1.FileName;
                }
            }
            else
            {
                
                
                if (MessageBox.Show("Czy na pewno chcesz odrzucić wszystkie zmiany?", "Ostrzeżenie", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //openFileDialog1.ShowDialog();
                        if (openFileDialog1.DefaultExt == ".rtx")
                        {
                            richTextBox1.LoadFile(openFileDialog1.FileName);
                            name = openFileDialog1.FileName;
                        }
                        else
                        {
                            MessageBox.Show("Niepoprawny format", "Błąd", MessageBoxButtons.OK);
                        }
                        
                    }
                }
                

            }
            
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //saveFileDialog1.ShowDialog();
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                saveFileDialog1.DefaultExt = ".rtx";
                name = saveFileDialog1.FileName;
                //label1.Text = name;
                zapisany = true;
                label1.Text = "saved";
            }
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            zapisany = false;
            label1.Text = "unsaved changes";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                // string pom = Convert.ToString(comboBox1.SelectedItem);
                //richTextBox1.Font = new Font(pom, richTextBox1.Font.Size,
                //richTextBox1.Font.Style, richTextBox1.Font.Unit);
                //richTextBox1.Font = "Microfsoft Sans Serif";
            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string pom = Convert.ToString(numericUpDown1.Value);
            float currentSize = float.Parse(pom);
            //currentSize ;
            richTextBox1.Font = new Font(richTextBox1.Font.Name, currentSize,
                richTextBox1.Font.Style, richTextBox1.Font.Unit);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (name == "Untitled")
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else {
                richTextBox1.SaveFile(name);
            }

            //richTextBox1.SaveFile(name);

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
            
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == true)
            {
                wordWrapToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
