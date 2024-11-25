namespace Stephanie_Maru_A3
{
    partial class Form1
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
            listBoxPlayers = new ListBox();
            panelCard = new Panel();
            pictureBoxPhoto = new PictureBox();
            label11 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            btnAddPlayer = new Button();
            btnRemovePlayer = new Button();
            btnUpdate = new Button();
            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // listBoxPlayers
            // 
            listBoxPlayers.FormattingEnabled = true;
            listBoxPlayers.ItemHeight = 25;
            listBoxPlayers.Location = new Point(31, 60);
            listBoxPlayers.Name = "listBoxPlayers";
            listBoxPlayers.Size = new Size(360, 129);
            listBoxPlayers.TabIndex = 0;
            // 
            // panelCard
            // 
            panelCard.Controls.Add(pictureBoxPhoto);
            panelCard.Location = new Point(451, 32);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(511, 647);
            panelCard.TabIndex = 1;
            // 
            // pictureBoxPhoto
            // 
            pictureBoxPhoto.Location = new Point(29, 28);
            pictureBoxPhoto.Name = "pictureBoxPhoto";
            pictureBoxPhoto.Size = new Size(451, 594);
            pictureBoxPhoto.TabIndex = 8;
            pictureBoxPhoto.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(31, 32);
            label11.Name = "label11";
            label11.Size = new Size(129, 25);
            label11.TabIndex = 2;
            label11.Text = "Select a player:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 726);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(931, 123);
            dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 698);
            label1.Name = "label1";
            label1.Size = new Size(121, 25);
            label1.TabIndex = 4;
            label1.Text = "Player Details:";
            // 
            // btnAddPlayer
            // 
            btnAddPlayer.Location = new Point(34, 210);
            btnAddPlayer.Name = "btnAddPlayer";
            btnAddPlayer.Size = new Size(112, 34);
            btnAddPlayer.TabIndex = 5;
            btnAddPlayer.Text = "Add";
            btnAddPlayer.UseVisualStyleBackColor = true;
            btnAddPlayer.Click += buttonAddPlayer_Click;
            // 
            // btnRemovePlayer
            // 
            btnRemovePlayer.Location = new Point(270, 210);
            btnRemovePlayer.Name = "btnRemovePlayer";
            btnRemovePlayer.Size = new Size(112, 34);
            btnRemovePlayer.TabIndex = 6;
            btnRemovePlayer.Text = "Remove";
            btnRemovePlayer.UseVisualStyleBackColor = true;
            btnRemovePlayer.Click += buttonRemovePlayer_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(152, 210);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 879);
            Controls.Add(btnUpdate);
            Controls.Add(btnRemovePlayer);
            Controls.Add(btnAddPlayer);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(label11);
            Controls.Add(panelCard);
            Controls.Add(listBoxPlayers);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NBA Trading Cards";
            panelCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxPlayers;
        private Panel panelCard;
        private PictureBox pictureBoxPhoto;
        private Label label11;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView dataGridView1;
        private Label label1;
        private Button btnAddPlayer;
        private Button btnRemovePlayer;
        private Button btnUpdate;
    }
}
