namespace RSSReader
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.linkBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.selectedLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.linkLabel = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.newNameLabel = new System.Windows.Forms.Label();
            this.newNameBox = new System.Windows.Forms.TextBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(175, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(497, 362);
            this.tabControl1.TabIndex = 1;
            // 
            // linkBox
            // 
            this.linkBox.Location = new System.Drawing.Point(15, 77);
            this.linkBox.Name = "linkBox";
            this.linkBox.Size = new System.Drawing.Size(136, 20);
            this.linkBox.TabIndex = 2;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(15, 113);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(136, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(15, 254);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(60, 23);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // selectedLabel
            // 
            this.selectedLabel.AutoSize = true;
            this.selectedLabel.Location = new System.Drawing.Point(12, 226);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(104, 13);
            this.selectedLabel.TabIndex = 5;
            this.selectedLabel.Text = "Selected RSS Feed:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(63, 13);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "Feed name:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(15, 30);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(137, 20);
            this.nameBox.TabIndex = 7;
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(12, 59);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(53, 13);
            this.linkLabel.TabIndex = 8;
            this.linkLabel.Text = "Feed link:";
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(13, 338);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(139, 23);
            this.editButton.TabIndex = 9;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // newNameLabel
            // 
            this.newNameLabel.AutoSize = true;
            this.newNameLabel.Location = new System.Drawing.Point(12, 294);
            this.newNameLabel.Name = "newNameLabel";
            this.newNameLabel.Size = new System.Drawing.Size(87, 13);
            this.newNameLabel.TabIndex = 10;
            this.newNameLabel.Text = "Enter new name:";
            // 
            // newNameBox
            // 
            this.newNameBox.Location = new System.Drawing.Point(13, 311);
            this.newNameBox.Name = "newNameBox";
            this.newNameBox.Size = new System.Drawing.Size(138, 20);
            this.newNameBox.TabIndex = 11;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(92, 254);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(60, 23);
            this.refreshButton.TabIndex = 12;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 387);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.newNameBox);
            this.Controls.Add(this.newNameLabel);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.selectedLabel);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.linkBox);
            this.Controls.Add(this.tabControl1);
            this.Name = "GUI";
            this.Text = "RSS Reader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox linkBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label selectedLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label linkLabel;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label newNameLabel;
        private System.Windows.Forms.TextBox newNameBox;
        private System.Windows.Forms.Button refreshButton;
    }
}

