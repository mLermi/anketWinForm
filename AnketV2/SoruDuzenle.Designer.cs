namespace AnketV2
{
    partial class SoruDuzenle
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
            this.btnSoruKaydet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoru = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSoruKaydet
            // 
            this.btnSoruKaydet.Location = new System.Drawing.Point(319, 82);
            this.btnSoruKaydet.Name = "btnSoruKaydet";
            this.btnSoruKaydet.Size = new System.Drawing.Size(75, 30);
            this.btnSoruKaydet.TabIndex = 5;
            this.btnSoruKaydet.Text = "Kaydet";
            this.btnSoruKaydet.UseVisualStyleBackColor = true;
            this.btnSoruKaydet.Click += new System.EventHandler(this.btnSoruKaydet_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Soru :";
            // 
            // txtSoru
            // 
            this.txtSoru.Location = new System.Drawing.Point(43, 53);
            this.txtSoru.Name = "txtSoru";
            this.txtSoru.Size = new System.Drawing.Size(351, 20);
            this.txtSoru.TabIndex = 3;
            // 
            // SoruDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 145);
            this.Controls.Add(this.btnSoruKaydet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSoru);
            this.Name = "SoruDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoruDuzenle";
            this.Load += new System.EventHandler(this.SoruDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSoruKaydet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoru;
    }
}