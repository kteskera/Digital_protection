namespace Potpis
{
    partial class SigurnostForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SigurnostForm));
            this.symmetricEncryptionBtn = new System.Windows.Forms.Button();
            this.symmetricDecryptionBtn = new System.Windows.Forms.Button();
            this.asymetricEncryptionBtn = new System.Windows.Forms.Button();
            this.asymetricDecryptionBtn = new System.Windows.Forms.Button();
            this.sazetakPorukeBtn = new System.Windows.Forms.Button();
            this.digitalniPotpisBtn = new System.Windows.Forms.Button();
            this.provjeraPotpisaBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialogSymmetric = new System.Windows.Forms.OpenFileDialog();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // symmetricEncryptionBtn
            // 
            this.symmetricEncryptionBtn.Location = new System.Drawing.Point(23, 42);
            this.symmetricEncryptionBtn.Name = "symmetricEncryptionBtn";
            this.symmetricEncryptionBtn.Size = new System.Drawing.Size(204, 35);
            this.symmetricEncryptionBtn.TabIndex = 0;
            this.symmetricEncryptionBtn.Text = "Simetrično kriptiranje AES";
            this.symmetricEncryptionBtn.UseVisualStyleBackColor = true;
            this.symmetricEncryptionBtn.Click += new System.EventHandler(this.symmetricEncryptionBtn_Click);
            // 
            // symmetricDecryptionBtn
            // 
            this.symmetricDecryptionBtn.Location = new System.Drawing.Point(23, 83);
            this.symmetricDecryptionBtn.Name = "symmetricDecryptionBtn";
            this.symmetricDecryptionBtn.Size = new System.Drawing.Size(204, 35);
            this.symmetricDecryptionBtn.TabIndex = 1;
            this.symmetricDecryptionBtn.Text = "Simetrično dekripitanje AES";
            this.symmetricDecryptionBtn.UseVisualStyleBackColor = true;
            this.symmetricDecryptionBtn.Click += new System.EventHandler(this.symmetricDecryption_Click);
            // 
            // asymetricEncryptionBtn
            // 
            this.asymetricEncryptionBtn.Location = new System.Drawing.Point(23, 157);
            this.asymetricEncryptionBtn.Name = "asymetricEncryptionBtn";
            this.asymetricEncryptionBtn.Size = new System.Drawing.Size(204, 35);
            this.asymetricEncryptionBtn.TabIndex = 2;
            this.asymetricEncryptionBtn.Text = "Asimetrično kriptiranje RSA";
            this.asymetricEncryptionBtn.UseVisualStyleBackColor = true;
            this.asymetricEncryptionBtn.Click += new System.EventHandler(this.asymetricEncryptionBtn_Click);
            // 
            // asymetricDecryptionBtn
            // 
            this.asymetricDecryptionBtn.Location = new System.Drawing.Point(23, 198);
            this.asymetricDecryptionBtn.Name = "asymetricDecryptionBtn";
            this.asymetricDecryptionBtn.Size = new System.Drawing.Size(204, 35);
            this.asymetricDecryptionBtn.TabIndex = 3;
            this.asymetricDecryptionBtn.Text = "Asimetrično dekriptiranje RSA";
            this.asymetricDecryptionBtn.UseVisualStyleBackColor = true;
            this.asymetricDecryptionBtn.Click += new System.EventHandler(this.asymetricDecryptionBtn_Click);
            // 
            // sazetakPorukeBtn
            // 
            this.sazetakPorukeBtn.Location = new System.Drawing.Point(23, 268);
            this.sazetakPorukeBtn.Name = "sazetakPorukeBtn";
            this.sazetakPorukeBtn.Size = new System.Drawing.Size(204, 35);
            this.sazetakPorukeBtn.TabIndex = 4;
            this.sazetakPorukeBtn.Text = "Sažetak poruke";
            this.sazetakPorukeBtn.UseVisualStyleBackColor = true;
            this.sazetakPorukeBtn.Click += new System.EventHandler(this.sazetakPorukeBtn_Click);
            // 
            // digitalniPotpisBtn
            // 
            this.digitalniPotpisBtn.Location = new System.Drawing.Point(23, 349);
            this.digitalniPotpisBtn.Name = "digitalniPotpisBtn";
            this.digitalniPotpisBtn.Size = new System.Drawing.Size(204, 35);
            this.digitalniPotpisBtn.TabIndex = 5;
            this.digitalniPotpisBtn.Text = "Digitalni potpis";
            this.digitalniPotpisBtn.UseVisualStyleBackColor = true;
            this.digitalniPotpisBtn.Click += new System.EventHandler(this.digitalniPotpisBtn_Click);
            // 
            // provjeraPotpisaBtn
            // 
            this.provjeraPotpisaBtn.Location = new System.Drawing.Point(23, 390);
            this.provjeraPotpisaBtn.Name = "provjeraPotpisaBtn";
            this.provjeraPotpisaBtn.Size = new System.Drawing.Size(204, 35);
            this.provjeraPotpisaBtn.TabIndex = 6;
            this.provjeraPotpisaBtn.Text = "Provjera potpisa";
            this.provjeraPotpisaBtn.UseVisualStyleBackColor = true;
            this.provjeraPotpisaBtn.Click += new System.EventHandler(this.provjeraPotpisaBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(300, 42);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(450, 191);
            this.textBox1.TabIndex = 7;
            // 
            // openFileDialogSymmetric
            // 
            this.openFileDialogSymmetric.FileName = "openFileDialogSymmetric";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(300, 247);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(450, 191);
            this.textBox2.TabIndex = 8;
            // 
            // SigurnostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 491);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.provjeraPotpisaBtn);
            this.Controls.Add(this.digitalniPotpisBtn);
            this.Controls.Add(this.sazetakPorukeBtn);
            this.Controls.Add(this.asymetricDecryptionBtn);
            this.Controls.Add(this.asymetricEncryptionBtn);
            this.Controls.Add(this.symmetricDecryptionBtn);
            this.Controls.Add(this.symmetricEncryptionBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SigurnostForm";
            this.Text = "Sigurnost";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button symmetricEncryptionBtn;
        private System.Windows.Forms.Button symmetricDecryptionBtn;
        private System.Windows.Forms.Button asymetricEncryptionBtn;
        private System.Windows.Forms.Button asymetricDecryptionBtn;
        private System.Windows.Forms.Button sazetakPorukeBtn;
        private System.Windows.Forms.Button digitalniPotpisBtn;
        private System.Windows.Forms.Button provjeraPotpisaBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialogSymmetric;
        private System.Windows.Forms.TextBox textBox2;
    }
}

