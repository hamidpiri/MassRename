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

namespace MassRename
{
    public partial class MassRename : Form
    {
        public MassRename()
        {
            InitializeComponent();

        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    foreach(string filename in files)
                    
                        listBox1.Items.Add(filename);
                    }

                }
            }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(listBox1.Items[listBox1.SelectedIndex].ToString());
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show(listBox1.Items[listBox1.SelectedIndex].ToString());
        }

        private void listBox1_DragOver(object sender, DragEventArgs e)
        {

        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show(listBox1.Items[listBox1.SelectedIndex].ToString());
        }

        private void listBox1_DragLeave(object sender, EventArgs e)
        {
            MessageBox.Show(listBox1.Items[listBox1.SelectedIndex].ToString());

        }
    }

}

