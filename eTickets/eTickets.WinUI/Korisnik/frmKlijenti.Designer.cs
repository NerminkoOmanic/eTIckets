
namespace eTickets.WinUI.Korisnik
{
    partial class frmKlijenti
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
            this.txtbSearch = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvKlijenti = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnickoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbSearch
            // 
            this.txtbSearch.Location = new System.Drawing.Point(15, 53);
            this.txtbSearch.Name = "txtbSearch";
            this.txtbSearch.Size = new System.Drawing.Size(182, 20);
            this.txtbSearch.TabIndex = 0;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(224, 52);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 21);
            this.BtnSearch.TabIndex = 1;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvKlijenti
            // 
            this.dgvKlijenti.AllowUserToAddRows = false;
            this.dgvKlijenti.AllowUserToDeleteRows = false;
            this.dgvKlijenti.AllowUserToResizeColumns = false;
            this.dgvKlijenti.AllowUserToResizeRows = false;
            this.dgvKlijenti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKlijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlijenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.KorisnickoIme,
            this.Ime,
            this.Prezime,
            this.Email,
            this.Telefon,
            this.Grad,
            this.Spol});
            this.dgvKlijenti.Location = new System.Drawing.Point(15, 90);
            this.dgvKlijenti.MultiSelect = false;
            this.dgvKlijenti.Name = "dgvKlijenti";
            this.dgvKlijenti.ReadOnly = true;
            this.dgvKlijenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKlijenti.Size = new System.Drawing.Size(642, 291);
            this.dgvKlijenti.TabIndex = 3;
            this.dgvKlijenti.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvKlijenti_MouseDoubleClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "KorisnikId";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // KorisnickoIme
            // 
            this.KorisnickoIme.DataPropertyName = "KorisnickoIme";
            this.KorisnickoIme.HeaderText = "Username";
            this.KorisnickoIme.Name = "KorisnickoIme";
            this.KorisnickoIme.ReadOnly = true;
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "First name";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Last name";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Phone number";
            this.Telefon.Name = "Telefon";
            this.Telefon.ReadOnly = true;
            // 
            // Grad
            // 
            this.Grad.DataPropertyName = "GradString";
            this.Grad.HeaderText = "City";
            this.Grad.Name = "Grad";
            this.Grad.ReadOnly = true;
            // 
            // Spol
            // 
            this.Spol.DataPropertyName = "SpolString";
            this.Spol.HeaderText = "Gender";
            this.Spol.Name = "Spol";
            this.Spol.ReadOnly = true;
            // 
            // frmKlijenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 488);
            this.Controls.Add(this.dgvKlijenti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.txtbSearch);
            this.Name = "frmKlijenti";
            this.Text = "Klijenti";
            this.Load += new System.EventHandler(this.frmKlijenti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbSearch;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvKlijenti;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnickoIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spol;
    }
}