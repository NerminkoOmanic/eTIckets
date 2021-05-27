
namespace eTickets.WinUI.Ticket
{
    partial class frmKupovine
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
            this.dgvKupovine = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NazivDogadjaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prodavac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kupac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKupovine)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKupovine
            // 
            this.dgvKupovine.AllowUserToAddRows = false;
            this.dgvKupovine.AllowUserToDeleteRows = false;
            this.dgvKupovine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKupovine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKupovine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NazivDogadjaja,
            this.Prodavac,
            this.Kupac,
            this.Cijena,
            this.Datum});
            this.dgvKupovine.Location = new System.Drawing.Point(42, 103);
            this.dgvKupovine.Name = "dgvKupovine";
            this.dgvKupovine.ReadOnly = true;
            this.dgvKupovine.Size = new System.Drawing.Size(705, 281);
            this.dgvKupovine.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // NazivDogadjaja
            // 
            this.NazivDogadjaja.DataPropertyName = "NazivDogadjaja";
            this.NazivDogadjaja.HeaderText = "Event";
            this.NazivDogadjaja.Name = "NazivDogadjaja";
            this.NazivDogadjaja.ReadOnly = true;
            // 
            // Prodavac
            // 
            this.Prodavac.DataPropertyName = "ProdavacString";
            this.Prodavac.HeaderText = "Seller";
            this.Prodavac.Name = "Prodavac";
            this.Prodavac.ReadOnly = true;
            // 
            // Kupac
            // 
            this.Kupac.DataPropertyName = "KupacString";
            this.Kupac.HeaderText = "Buyer";
            this.Kupac.Name = "Kupac";
            this.Kupac.ReadOnly = true;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "CijenaString";
            this.Cijena.HeaderText = "Price";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.DataPropertyName = "Datum";
            this.Datum.HeaderText = "Date";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // frmKupovine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvKupovine);
            this.Name = "frmKupovine";
            this.Text = "History of selling";
            this.Load += new System.EventHandler(this.frmKupovine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKupovine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKupovine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NazivDogadjaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prodavac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kupac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
    }
}