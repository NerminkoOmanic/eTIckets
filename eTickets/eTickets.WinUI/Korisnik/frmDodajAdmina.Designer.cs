
namespace eTickets.WinUI.Korisnik
{
    partial class frmDodajAdmina
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtbTelefon = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbEmail = new System.Windows.Forms.TextBox();
            this.txtbPrezime = new System.Windows.Forms.TextBox();
            this.txtbIme = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtbKorisnickoIme = new System.Windows.Forms.TextBox();
            this.txtbLozinka = new System.Windows.Forms.TextBox();
            this.txtbPotvrdaLozinke = new System.Windows.Forms.TextBox();
            this.cmbGrad = new System.Windows.Forms.ComboBox();
            this.cmbSpol = new System.Windows.Forms.ComboBox();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(211, 394);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 27);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtbTelefon
            // 
            this.txtbTelefon.Location = new System.Drawing.Point(128, 221);
            this.txtbTelefon.Mask = "(999) 000-0000";
            this.txtbTelefon.Name = "txtbTelefon";
            this.txtbTelefon.Size = new System.Drawing.Size(164, 20);
            this.txtbTelefon.TabIndex = 6;
            this.txtbTelefon.Validating += new System.ComponentModel.CancelEventHandler(this.txtbTelefon_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Birth date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Gender :";
            // 
            // txtbEmail
            // 
            this.txtbEmail.Location = new System.Drawing.Point(128, 119);
            this.txtbEmail.Name = "txtbEmail";
            this.txtbEmail.Size = new System.Drawing.Size(164, 20);
            this.txtbEmail.TabIndex = 3;
            this.txtbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtbEmail_Validating);
            // 
            // txtbPrezime
            // 
            this.txtbPrezime.Location = new System.Drawing.Point(128, 86);
            this.txtbPrezime.Name = "txtbPrezime";
            this.txtbPrezime.Size = new System.Drawing.Size(164, 20);
            this.txtbPrezime.TabIndex = 2;
            this.txtbPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.txtbPrezime_Validating);
            // 
            // txtbIme
            // 
            this.txtbIme.Location = new System.Drawing.Point(128, 55);
            this.txtbIme.Name = "txtbIme";
            this.txtbIme.Size = new System.Drawing.Size(164, 20);
            this.txtbIme.TabIndex = 1;
            this.txtbIme.Validating += new System.ComponentModel.CancelEventHandler(this.txtbIme_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "City :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Phone number :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Email :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Last name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "First name :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Username :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(63, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Password :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Confirm password :";
            // 
            // txtbKorisnickoIme
            // 
            this.txtbKorisnickoIme.Location = new System.Drawing.Point(128, 28);
            this.txtbKorisnickoIme.Name = "txtbKorisnickoIme";
            this.txtbKorisnickoIme.Size = new System.Drawing.Size(164, 20);
            this.txtbKorisnickoIme.TabIndex = 0;
            this.txtbKorisnickoIme.Validating += new System.ComponentModel.CancelEventHandler(this.txtbKorisnickoIme_Validating);
            // 
            // txtbLozinka
            // 
            this.txtbLozinka.Location = new System.Drawing.Point(128, 151);
            this.txtbLozinka.Name = "txtbLozinka";
            this.txtbLozinka.PasswordChar = '*';
            this.txtbLozinka.Size = new System.Drawing.Size(164, 20);
            this.txtbLozinka.TabIndex = 4;
            this.txtbLozinka.Validating += new System.ComponentModel.CancelEventHandler(this.txtbLozinka_Validating);
            // 
            // txtbPotvrdaLozinke
            // 
            this.txtbPotvrdaLozinke.Location = new System.Drawing.Point(128, 185);
            this.txtbPotvrdaLozinke.Name = "txtbPotvrdaLozinke";
            this.txtbPotvrdaLozinke.PasswordChar = '*';
            this.txtbPotvrdaLozinke.Size = new System.Drawing.Size(164, 20);
            this.txtbPotvrdaLozinke.TabIndex = 5;
            this.txtbPotvrdaLozinke.Validating += new System.ComponentModel.CancelEventHandler(this.txtbPotvrdaLozinke_Validating);
            // 
            // cmbGrad
            // 
            this.cmbGrad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrad.FormattingEnabled = true;
            this.cmbGrad.Location = new System.Drawing.Point(128, 300);
            this.cmbGrad.Name = "cmbGrad";
            this.cmbGrad.Size = new System.Drawing.Size(164, 21);
            this.cmbGrad.TabIndex = 31;
            this.cmbGrad.Validating += new System.ComponentModel.CancelEventHandler(this.cmbGrad_Validating);
            // 
            // cmbSpol
            // 
            this.cmbSpol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpol.FormattingEnabled = true;
            this.cmbSpol.Location = new System.Drawing.Point(128, 338);
            this.cmbSpol.Name = "cmbSpol";
            this.cmbSpol.Size = new System.Drawing.Size(164, 21);
            this.cmbSpol.TabIndex = 32;
            this.cmbSpol.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSpol_Validating);
            // 
            // dtpDatum
            // 
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatum.Location = new System.Drawing.Point(128, 260);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(164, 20);
            this.dtpDatum.TabIndex = 33;
            this.dtpDatum.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDatum_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmDodajAdmina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 450);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.cmbSpol);
            this.Controls.Add(this.cmbGrad);
            this.Controls.Add(this.txtbPotvrdaLozinke);
            this.Controls.Add(this.txtbLozinka);
            this.Controls.Add(this.txtbKorisnickoIme);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtbTelefon);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbEmail);
            this.Controls.Add(this.txtbPrezime);
            this.Controls.Add(this.txtbIme);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDodajAdmina";
            this.Text = "Add new admin";
            this.Load += new System.EventHandler(this.frmDodajAdmina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.MaskedTextBox txtbTelefon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbEmail;
        private System.Windows.Forms.TextBox txtbPrezime;
        private System.Windows.Forms.TextBox txtbIme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtbKorisnickoIme;
        private System.Windows.Forms.TextBox txtbLozinka;
        private System.Windows.Forms.TextBox txtbPotvrdaLozinke;
        private System.Windows.Forms.ComboBox cmbGrad;
        private System.Windows.Forms.ComboBox cmbSpol;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}