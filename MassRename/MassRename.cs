﻿using System;
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

                    foreach (string filename in files)
                    {
                        listBox1.Items.Add(filename);
                        listView1.Items.Add(filename);
                    }
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
            //MessageBox.Show(listBox1.Items[listBox1.SelectedIndex].ToString());
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

            }
            object selectedItem = listBox1.SelectedItem;
            listBox1.Items.Remove(selectedItem);
        }

        private void listBox1_DragLeave(object sender, EventArgs e)
        {

        }


    }

}

