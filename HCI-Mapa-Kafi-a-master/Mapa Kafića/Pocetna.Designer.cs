namespace Mapa_Kafića
{
    partial class Pocetna
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lokaliListView = new System.Windows.Forms.ListView();
            this.mapPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(600, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Rad sa lokalima";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(600, 270);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Rad sa tipovima";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(600, 356);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Tutorijal";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(600, 311);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Rad sa etiketama";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Svi Lokali:";
            // 
            // lokaliListView
            // 
            this.lokaliListView.Location = new System.Drawing.Point(12, 38);
            this.lokaliListView.MultiSelect = false;
            this.lokaliListView.Name = "lokaliListView";
            this.lokaliListView.Size = new System.Drawing.Size(74, 341);
            this.lokaliListView.TabIndex = 7;
            this.lokaliListView.TileSize = new System.Drawing.Size(32, 52);
            this.lokaliListView.UseCompatibleStateImageBehavior = false;
            this.lokaliListView.SelectedIndexChanged += new System.EventHandler(this.lokaliListView_SelectedIndexChanged);
            this.lokaliListView.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.lokaliListView_GiveFeedback);
            this.lokaliListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lokaliListView_MouseDown);
            // 
            // mapPicture
            // 
            this.mapPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mapPicture.Image = global::Mapa_Kafića.Properties.Resources.map;
            this.mapPicture.Location = new System.Drawing.Point(116, 38);
            this.mapPicture.Name = "mapPicture";
            this.mapPicture.Size = new System.Drawing.Size(478, 341);
            this.mapPicture.TabIndex = 8;
            this.mapPicture.TabStop = false;
            this.mapPicture.Click += new System.EventHandler(this.mapPicture_Click);
            this.mapPicture.DoubleClick += new System.EventHandler(this.mapPicture_DoubleClick);
            // 
            // Pocetna
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 391);
            this.Controls.Add(this.mapPicture);
            this.Controls.Add(this.lokaliListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Pocetna";
            this.Text = "Pocetak";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pocetna_FormClosed);
            this.Load += new System.EventHandler(this.Pocetak_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Pocetna_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Pocetna_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pocetna_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lokaliListView;
        private System.Windows.Forms.PictureBox mapPicture;
    }
}