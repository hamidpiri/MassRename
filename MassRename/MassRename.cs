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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MassRename
{
    public partial class MassRename : Form
    {
        public string[] files;
        public string filesPath;
        public MassRename()
        {
            InitializeComponent();
            pictureBox1.Hide();
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    listBox1.Items.Clear();
                    files = Directory.GetFiles(fbd.SelectedPath);
                    try
                    {
                        filesPath = Path.GetDirectoryName(files[0]);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    foreach (string path in files)
                    {
                        string fileName = Path.GetFileName(path);
                        listBox1.Items.Add(fileName);
                    }
                    SaveBtn.Enabled = true;
                }

            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // If drag start point was location of an item
            if (GetItemIndex(e.Location) != -1)
            {
                listBox1.DoDragDrop(listBox1, DragDropEffects.Move);
            }
        }

        public int GetItemIndex(Point point)
        {
            int itemIndex = 0;
            for (int index = 0; index < listBox1.Items.Count - 1; index++)
            {
                if (listBox1.GetItemRectangle(index).Contains(point))
                {
                    itemIndex = index;
                    break;
                }
            }
            return itemIndex;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            Point mouseLocation = listBox1.PointToClient(new Point(e.X, e.Y));
            if (GetItemIndex(mouseLocation) == listBox1.SelectedIndex)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void listBox1_DragOver(object sender, DragEventArgs e)
        {

        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            int dropIndex = GetItemIndex(listBox1.PointToClient(new Point(e.X, e.Y)));
            if (dropIndex > selectedIndex)
            {
                dropIndex -= 1;
            }
            object selectedItem = listBox1.SelectedItem;
            listBox1.Items.Remove(selectedItem);
            if (dropIndex == -1)
            {
                listBox1.Items.Add(selectedItem);
            }
            else
            {
                listBox1.Items.Insert(dropIndex, selectedItem);
            }
        }

        private void listBox1_DragLeave(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            int index = 1;
            foreach (object item in listBox1.Items)
            {
                File.Move(filesPath + "\\" + item.ToString(), filesPath + "\\" + index + "-" + item.ToString());
                index++;
            }
            listBox1.Items.Clear();

            showSuccessIcon();
            Timer timer = new Timer
            {
                Interval = 4000
            };
            timer.Enabled = true;
            timer.Tick += new System.EventHandler(OnTimerEvent);
            SaveBtn.Enabled = false;

        }
        private void OnTimerEvent(object sender, EventArgs e)
        {
            pictureBox1.Hide();
        }

        private void showSuccessIcon()
        {
            pictureBox1.Enabled = true;
            pictureBox1.Image = Image.FromFile("Resources\\success.png");
            pictureBox1.Show();
        }
    }

}

