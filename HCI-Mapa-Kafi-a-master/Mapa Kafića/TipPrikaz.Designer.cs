namespace Mapa_Kafića
{
    partial class TipPrikaz
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
            this.deleteEntery = new System.Windows.Forms.Button();
            this.enterEntery = new System.Windows.Forms.Button();
            this.tipoviListView = new System.Windows.Forms.ListView();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.icoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelrrrr = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.opisLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ImeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IzmeniButton = new System.Windows.Forms.Button();
            this.previewComboBox = new System.Windows.Forms.ComboBox();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteEntery
            // 
            this.deleteEntery.Location = new System.Drawing.Point(12, 285);
            this.deleteEntery.Name = "deleteEntery";
            this.deleteEntery.Size = new System.Drawing.Size(75, 23);
            this.deleteEntery.TabIndex = 1;
            this.deleteEntery.Text = "Obriši";
            this.deleteEntery.UseVisualStyleBackColor = true;
            this.deleteEntery.Click += new System.EventHandler(this.deleteEntery_Click);
            // 
            // enterEntery
            // 
            this.enterEntery.Location = new System.Drawing.Point(499, 285);
            this.enterEntery.Name = "enterEntery";
            this.enterEntery.Size = new System.Drawing.Size(75, 23);
            this.enterEntery.TabIndex = 2;
            this.enterEntery.Text = "Dodaj";
            this.enterEntery.UseVisualStyleBackColor = true;
            this.enterEntery.Click += new System.EventHandler(this.enterEntery_Click);
            // 
            // tipoviListView
            // 
            this.tipoviListView.Location = new System.Drawing.Point(12, 64);
            this.tipoviListView.Name = "tipoviListView";
            this.tipoviListView.Size = new System.Drawing.Size(283, 187);
            this.tipoviListView.TabIndex = 3;
            this.tipoviListView.UseCompatibleStateImageBehavior = false;
            this.tipoviListView.SelectedIndexChanged += new System.EventHandler(this.tipoviListView_SelectedIndexChanged_1);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(12, 38);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(129, 20);
            this.filterTextBox.TabIndex = 14;
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Items.AddRange(new object[] {
            "Ime",
            "Opis",
            "Ikona",
            "Prikaži sve"});
            this.FilterComboBox.Location = new System.Drawing.Point(147, 37);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(67, 21);
            this.FilterComboBox.TabIndex = 20;
            this.FilterComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterComboBox_SelectedIndexChanged);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(220, 37);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 30;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // InfoPanel
            // 
            this.InfoPanel.Controls.Add(this.icoPictureBox);
            this.InfoPanel.Controls.Add(this.labelrrrr);
            this.InfoPanel.Controls.Add(this.label32);
            this.InfoPanel.Controls.Add(this.opisLabel);
            this.InfoPanel.Controls.Add(this.label3);
            this.InfoPanel.Controls.Add(this.ImeLabel);
            this.InfoPanel.Controls.Add(this.label1);
            this.InfoPanel.Location = new System.Drawing.Point(337, 38);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(237, 216);
            this.InfoPanel.TabIndex = 15;
            // 
            // icoPictureBox
            // 
            this.icoPictureBox.Image = global::Mapa_Kafića.Properties.Resources._null;
            this.icoPictureBox.InitialImage = global::Mapa_Kafića.Properties.Resources._null;
            this.icoPictureBox.Location = new System.Drawing.Point(46, 125);
            this.icoPictureBox.Name = "icoPictureBox";
            this.icoPictureBox.Size = new System.Drawing.Size(32, 32);
            this.icoPictureBox.TabIndex = 19;
            this.icoPictureBox.TabStop = false;
            // 
            // labelrrrr
            // 
            this.labelrrrr.AutoSize = true;
            this.labelrrrr.Location = new System.Drawing.Point(3, 125);
            this.labelrrrr.Name = "labelrrrr";
            this.labelrrrr.Size = new System.Drawing.Size(37, 13);
            this.labelrrrr.TabIndex = 18;
            this.labelrrrr.Text = "Ikona:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(3, 85);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(31, 13);
            this.label32.TabIndex = 16;
            this.label32.Text = "Opis:";
            // 
            // opisLabel
            // 
            this.opisLabel.AutoSize = true;
            this.opisLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opisLabel.Location = new System.Drawing.Point(36, 85);
            this.opisLabel.Name = "opisLabel";
            this.opisLabel.Size = new System.Drawing.Size(160, 13);
            this.opisLabel.TabIndex = 15;
            this.opisLabel.Text = "nije selektovan ni jedan tip";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ime:";
            // 
            // ImeLabel
            // 
            this.ImeLabel.AutoSize = true;
            this.ImeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImeLabel.Location = new System.Drawing.Point(36, 41);
            this.ImeLabel.Name = "ImeLabel";
            this.ImeLabel.Size = new System.Drawing.Size(160, 13);
            this.ImeLabel.TabIndex = 13;
            this.ImeLabel.Text = "nije selektovan ni jedan tip";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Opis selektovanog tipa";
            // 
            // IzmeniButton
            // 
            this.IzmeniButton.Location = new System.Drawing.Point(220, 285);
            this.IzmeniButton.Name = "IzmeniButton";
            this.IzmeniButton.Size = new System.Drawing.Size(75, 23);
            this.IzmeniButton.TabIndex = 16;
            this.IzmeniButton.Text = "Izmeni";
            this.IzmeniButton.UseVisualStyleBackColor = true;
            this.IzmeniButton.Click += new System.EventHandler(this.IzmeniButton_Click);
            // 
            // previewComboBox
            // 
            this.previewComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.previewComboBox.FormattingEnabled = true;
            this.previewComboBox.Location = new System.Drawing.Point(12, 39);
            this.previewComboBox.Name = "previewComboBox";
            this.previewComboBox.Size = new System.Drawing.Size(85, 21);
            this.previewComboBox.TabIndex = 17;
            this.previewComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.Location = new System.Drawing.Point(103, 28);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(32, 32);
            this.previewPictureBox.TabIndex = 18;
            this.previewPictureBox.TabStop = false;
            // 
            // TipPrikaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 320);
            this.Controls.Add(this.previewPictureBox);
            this.Controls.Add(this.previewComboBox);
            this.Controls.Add(this.IzmeniButton);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.FilterComboBox);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.tipoviListView);
            this.Controls.Add(this.enterEntery);
            this.Controls.Add(this.deleteEntery);
            this.Name = "TipPrikaz";
            this.Text = "Prikaz Tipova";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TipPrikaz_FormClosed);
            this.Load += new System.EventHandler(this.TipPrikaz_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TipPrikaz_KeyDown);
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteEntery;
        private System.Windows.Forms.Button enterEntery;
        private System.Windows.Forms.ListView tipoviListView;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.ComboBox FilterComboBox;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label labelrrrr;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label opisLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ImeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox icoPictureBox;
        private System.Windows.Forms.Button IzmeniButton;
        private System.Windows.Forms.ComboBox previewComboBox;
        private System.Windows.Forms.PictureBox previewPictureBox;
       // private GListBox gListBox1;

    }
}