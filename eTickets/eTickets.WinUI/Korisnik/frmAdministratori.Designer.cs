
namespace eTickets.WinUI.Korisnik
{
    partial class frmAdministratori
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
            this.dgvAdministratori = new System.Windows.Forms.DataGridView();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.txtbSearch = new System.Windows.Forms.TextBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AdminId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnickoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdministratori)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAdministratori
            // 
            this.dgvAdministratori.AllowUserToAddRows = false;
            this.dgvAdministratori.AllowUserToDeleteRows = false;
            this.dgvAdministratori.AllowUserToResizeColumns = false;
            this.dgvAdministratori.AllowUserToResizeRows = false;
            this.dgvAdministratori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdministratori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdministratori.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AdminId,
            this.KorisnickoIme,
            this.Ime,
            this.Prezime,
            this.Email,
            this.Telefon});
            this.dgvAdministratori.Location = new System.Drawing.Point(15, 93);
            this.dgvAdministratori.Name = "dgvAdministratori";
            this.dgvAdministratori.ReadOnly = true;
            this.dgvAdministratori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdministratori.Size = new System.Drawing.Size(657, 272);
            this.dgvAdministratori.TabIndex = 7;
            this.dgvAdministratori.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvAdministratori_MouseDoubleClick);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(222, 51);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(76, 20);
            this.BtnSearch.TabIndex = 5;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtbSearch
            // 
            this.txtbSearch.Location = new System.Drawing.Point(15, 51);
            this.txtbSearch.Name = "txtbSearch";
            this.txtbSearch.Size = new System.Drawing.Size(187, 20);
            this.txtbSearch.TabIndex = 4;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(599, 48);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(73, 23);
            this.btnDodaj.TabIndex = 8;
            this.btnDodaj.Text = "Add";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Username :";
            // 
            // AdminId
            // 
            this.AdminId.DataPropertyName = "KorisnikId";
            this.AdminId.HeaderText = "Id";
            this.AdminId.Name = "AdminId";
            this.AdminId.Visible = false;
            // 
            // KorisnickoIme
            // 
            this.KorisnickoIme.DataPropertyName = "KorisnickoIme";
            this.KorisnickoIme.HeaderText = "Username";
            this.KorisnickoIme.Name = "KorisnickoIme";
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "First name";
            this.Ime.Name = "Ime";
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Last name";
            this.Prezime.Name = "Prezime";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Phone number";
            this.Telefon.Name = "Telefon";
            // 
            // frmAdministratori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 484);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.dgvAdministratori);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.txtbSearch);
            this.Name = "frmAdministratori";
            this.Text = "Administratori";
            this.Load += new System.EventHandler(this.frmAdministratori_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdministratori)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAdministratori;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox txtbSearch;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdminId;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnickoIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
    }
}