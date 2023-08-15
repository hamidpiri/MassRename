
namespace MassRename
{
    partial class MassRename
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BrowseBtn = new System.Windows.Forms.Button();
            listBox1 = new System.Windows.Forms.ListBox();
            SaveBtn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // BrowseBtn
            // 
            BrowseBtn.Location = new System.Drawing.Point(13, 13);
            BrowseBtn.Name = "BrowseBtn";
            BrowseBtn.Size = new System.Drawing.Size(179, 23);
            BrowseBtn.TabIndex = 0;
            BrowseBtn.Text = "Browse for a directory...";
            BrowseBtn.UseVisualStyleBackColor = true;
            BrowseBtn.Click += BrowseBtn_Click;
            // 
            // listBox1
            // 
            listBox1.AllowDrop = true;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new System.Drawing.Point(12, 44);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(495, 334);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox1.DragDrop += listBox1_DragDrop;
            listBox1.DragEnter += listBox1_DragEnter;
            listBox1.MouseDown += listBox1_MouseDown;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new System.Drawing.Point(351, 11);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new System.Drawing.Size(89, 23);
            SaveBtn.TabIndex = 3;
            SaveBtn.Text = "Save Changes";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // MassRename
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(520, 392);
            Controls.Add(SaveBtn);
            Controls.Add(listBox1);
            Controls.Add(BrowseBtn);
            Name = "MassRename";
            Text = "MassRename";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button SaveBtn;
    }
}

