namespace Mapa_Kafića
{
    partial class Tip
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
            this.components = new System.ComponentModel.Container();
            this.dodajTipButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tipoviTextBox = new System.Windows.Forms.TextBox();
            this.tipToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.opisTipaTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ikonaComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.izmenaButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dodajTipButton
            // 
            this.dodajTipButton.Location = new System.Drawing.Point(186, 226);
            this.dodajTipButton.Name = "dodajTipButton";
            this.dodajTipButton.Size = new System.Drawing.Size(75, 23);
            this.dodajTipButton.TabIndex = 0;
            this.dodajTipButton.Text = "Dodaj";
            this.dodajTipButton.UseVisualStyleBackColor = true;
            this.dodajTipButton.Click += new System.EventHandler(this.dodajTipButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.MaximumSize = new System.Drawing.Size(267, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unesi tip lokala";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tipoviTextBox
            // 
            this.tipoviTextBox.Location = new System.Drawing.Point(12, 39);
            this.tipoviTextBox.Multiline = true;
            this.tipoviTextBox.Name = "tipoviTextBox";
            this.tipoviTextBox.Size = new System.Drawing.Size(249, 27);
            this.tipoviTextBox.TabIndex = 2;
            this.tipoviTextBox.TextChanged += new System.EventHandler(this.tipoviTextBox_TextChanged);
            this.tipoviTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tipoviTextBox_KeyDown);
            this.tipoviTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoviTextBox_KeyPress);
            // 
            // tipToolTip
            // 
            this.tipToolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.tipToolTip_Popup);
            // 
            // opisTipaTextBox
            // 
            this.opisTipaTextBox.Location = new System.Drawing.Point(12, 99);
            this.opisTipaTextBox.Multiline = true;
            this.opisTipaTextBox.Name = "opisTipaTextBox";
            this.opisTipaTextBox.Size = new System.Drawing.Size(249, 27);
            this.opisTipaTextBox.TabIndex = 4;
            this.opisTipaTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.opisTipaTextBox_KeyDown);
            this.opisTipaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.opisTipaTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 83);
            this.label2.MaximumSize = new System.Drawing.Size(267, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Unesi opis tipa";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ikonaComboBox
            // 
            this.ikonaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ikonaComboBox.FormattingEnabled = true;
            this.ikonaComboBox.Location = new System.Drawing.Point(15, 164);
            this.ikonaComboBox.Name = "ikonaComboBox";
            this.ikonaComboBox.Size = new System.Drawing.Size(147, 21);
            this.ikonaComboBox.TabIndex = 5;
            this.ikonaComboBox.SelectedIndexChanged += new System.EventHandler(this.ikonaComboBox_SelectedIndexChanged);
            this.ikonaComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ikonaComboBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 146);
            this.label3.MaximumSize = new System.Drawing.Size(267, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Izaberi ikonu tipa";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(178, 146);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 50);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // izmenaButton
            // 
            this.izmenaButton.Location = new System.Drawing.Point(186, 226);
            this.izmenaButton.Name = "izmenaButton";
            this.izmenaButton.Size = new System.Drawing.Size(75, 23);
            this.izmenaButton.TabIndex = 8;
            this.izmenaButton.Text = "Izmeni";
            this.izmenaButton.UseVisualStyleBackColor = true;
            this.izmenaButton.Click += new System.EventHandler(this.izmenaButton_Click);
            // 
            // Tip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.izmenaButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ikonaComboBox);
            this.Controls.Add(this.opisTipaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tipoviTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dodajTipButton);
            this.Name = "Tip";
            this.Text = "Dodaj tip";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tip_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tip_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dodajTipButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tipoviTextBox;
        private System.Windows.Forms.ToolTip tipToolTip;
        private System.Windows.Forms.TextBox opisTipaTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox ikonaComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button izmenaButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}