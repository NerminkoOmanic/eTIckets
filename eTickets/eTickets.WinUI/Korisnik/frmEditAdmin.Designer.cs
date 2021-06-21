
namespace eTickets.WinUI.Korisnik
{
    partial class frmEditAdmin
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
            this.cmbGrad = new System.Windows.Forms.ComboBox();
            this.txtbPotvrdaLozinke = new System.Windows.Forms.TextBox();
            this.txtbLozinka = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtbEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtbTelefon = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbGrad
            // 
            this.cmbGrad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrad.FormattingEnabled = true;
            this.cmbGrad.Location = new System.Drawing.Point(119, 164);
            this.cmbGrad.Name = "cmbGrad";
            this.cmbGrad.Size = new System.Drawing.Size(164, 21);
            this.cmbGrad.TabIndex = 52;
            this.cmbGrad.Validating += new System.ComponentModel.CancelEventHandler(this.cmbGrad_Validating);
            // 
            // txtbPotvrdaLozinke
            // 
            this.txtbPotvrdaLozinke.Location = new System.Drawing.Point(119, 90);
            this.txtbPotvrdaLozinke.Name = "txtbPotvrdaLozinke";
            this.txtbPotvrdaLozinke.PasswordChar = '*';
            this.txtbPotvrdaLozinke.Size = new System.Drawing.Size(164, 20);
            this.txtbPotvrdaLozinke.TabIndex = 38;
            this.txtbPotvrdaLozinke.Validating += new System.ComponentModel.CancelEventHandler(this.txtbPotvrdaLozinke_Validating);
            // 
            // txtbLozinka
            // 
            this.txtbLozinka.Location = new System.Drawing.Point(119, 56);
            this.txtbLozinka.Name = "txtbLozinka";
            this.txtbLozinka.PasswordChar = '*';
            this.txtbLozinka.Size = new System.Drawing.Size(164, 20);
            this.txtbLozinka.TabIndex = 37;
            this.txtbLozinka.Validating += new System.ComponentModel.CancelEventHandler(this.txtbLozinka_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Confirm password :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(54, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Password :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(208, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtbEmail
            // 
            this.txtbEmail.Location = new System.Drawing.Point(119, 24);
            this.txtbEmail.Name = "txtbEmail";
            this.txtbEmail.Size = new System.Drawing.Size(164, 20);
            this.txtbEmail.TabIndex = 36;
            this.txtbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEmail_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "City :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Phone number :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Email :";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtbTelefon
            // 
            this.txtbTelefon.Location = new System.Drawing.Point(119, 126);
            this.txtbTelefon.Name = "txtbTelefon";
            this.txtbTelefon.Size = new System.Drawing.Size(164, 20);
            this.txtbTelefon.TabIndex = 53;
            this.txtbTelefon.Validating += new System.ComponentModel.CancelEventHandler(this.txtbTelefon_Validating);
            // 
            // frmEditAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 266);
            this.Controls.Add(this.txtbTelefon);
            this.Controls.Add(this.cmbGrad);
            this.Controls.Add(this.txtbPotvrdaLozinke);
            this.Controls.Add(this.txtbLozinka);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtbEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "frmEditAdmin";
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.frmEditAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbGrad;
        private System.Windows.Forms.TextBox txtbPotvrdaLozinke;
        private System.Windows.Forms.TextBox txtbLozinka;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtbEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox txtbTelefon;
    }
}