namespace Mapa_Kafića
{
    partial class DodajEtiketu
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
            this.tipoviTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dodajTipButton = new System.Windows.Forms.Button();
            this.tipToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.etiketaErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.opisErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.colorErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelPrimer = new System.Windows.Forms.Label();
            this.izmenaButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.etiketaErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opisErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoviTextBox
            // 
            this.tipoviTextBox.Location = new System.Drawing.Point(15, 44);
            this.tipoviTextBox.Multiline = true;
            this.tipoviTextBox.Name = "tipoviTextBox";
            this.tipoviTextBox.Size = new System.Drawing.Size(190, 23);
            this.tipoviTextBox.TabIndex = 5;
            this.tipoviTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tipoviTextBox_KeyDown);
            this.tipoviTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoviTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.MaximumSize = new System.Drawing.Size(267, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dodaj oznaku etikete";
            // 
            // dodajTipButton
            // 
            this.dodajTipButton.Location = new System.Drawing.Point(197, 227);
            this.dodajTipButton.Name = "dodajTipButton";
            this.dodajTipButton.Size = new System.Drawing.Size(75, 23);
            this.dodajTipButton.TabIndex = 3;
            this.dodajTipButton.Text = "Dodaj";
            this.dodajTipButton.UseVisualStyleBackColor = true;
            this.dodajTipButton.Click += new System.EventHandler(this.dodajTipButton_Click);
            // 
            // tipToolTip
            // 
            this.tipToolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.tipToolTip_Popup);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 108);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 23);
            this.textBox1.TabIndex = 7;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.MaximumSize = new System.Drawing.Size(267, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Unesi opis etikete";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 151);
            this.label3.MaximumSize = new System.Drawing.Size(267, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Izaberi boju etikete";
            // 
            // colorComboBox
            // 
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Location = new System.Drawing.Point(15, 177);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(190, 21);
            this.colorComboBox.TabIndex = 10;
            this.colorComboBox.SelectedIndexChanged += new System.EventHandler(this.colorComboBox_SelectedIndexChanged);
            this.colorComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.colorComboBox_KeyDown);
            // 
            // etiketaErrorProvider
            // 
            this.etiketaErrorProvider.ContainerControl = this;
            // 
            // opisErrorProvider
            // 
            this.opisErrorProvider.ContainerControl = this;
            // 
            // colorErrorProvider
            // 
            this.colorErrorProvider.ContainerControl = this;
            // 
            // labelPrimer
            // 
            this.labelPrimer.AutoSize = true;
            this.labelPrimer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrimer.Location = new System.Drawing.Point(219, 179);
            this.labelPrimer.MaximumSize = new System.Drawing.Size(267, 0);
            this.labelPrimer.Name = "labelPrimer";
            this.labelPrimer.Size = new System.Drawing.Size(53, 15);
            this.labelPrimer.TabIndex = 11;
            this.labelPrimer.Text = "PRIMER";
            // 
            // izmenaButton
            // 
            this.izmenaButton.Location = new System.Drawing.Point(197, 227);
            this.izmenaButton.Name = "izmenaButton";
            this.izmenaButton.Size = new System.Drawing.Size(75, 23);
            this.izmenaButton.TabIndex = 12;
            this.izmenaButton.Text = "Izmeni";
            this.izmenaButton.UseVisualStyleBackColor = true;
            this.izmenaButton.Click += new System.EventHandler(this.izmenaButton_Click);
            // 
            // DodajEtiketu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.izmenaButton);
            this.Controls.Add(this.labelPrimer);
            this.Controls.Add(this.colorComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tipoviTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dodajTipButton);
            this.Name = "DodajEtiketu";
            this.Text = "Dodaj Etiketu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DodajEtiketu_FormClosed);
            this.Load += new System.EventHandler(this.DodajEtiketu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DodajEtiketu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.etiketaErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opisErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tipoviTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button dodajTipButton;
        private System.Windows.Forms.ToolTip tipToolTip;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.ErrorProvider etiketaErrorProvider;
        private System.Windows.Forms.ErrorProvider opisErrorProvider;
        private System.Windows.Forms.ErrorProvider colorErrorProvider;
        private System.Windows.Forms.Label labelPrimer;
        private System.Windows.Forms.Button izmenaButton;
    }
}