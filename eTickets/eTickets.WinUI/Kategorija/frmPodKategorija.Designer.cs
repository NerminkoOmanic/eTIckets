
namespace eTickets.WinUI.Kategorija
{
    partial class frmPodKategorija
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
            this.BtnAdd = new System.Windows.Forms.Button();
            this.dgvPodKategorija = new System.Windows.Forms.DataGridView();
            this.PodKategorijaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kategorija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPodKategorija)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(252, 49);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(82, 24);
            this.BtnAdd.TabIndex = 9;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // dgvPodKategorija
            // 
            this.dgvPodKategorija.AllowUserToAddRows = false;
            this.dgvPodKategorija.AllowUserToDeleteRows = false;
            this.dgvPodKategorija.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPodKategorija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPodKategorija.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PodKategorijaID,
            this.Naziv,
            this.Kategorija});
            this.dgvPodKategorija.Location = new System.Drawing.Point(22, 89);
            this.dgvPodKategorija.MultiSelect = false;
            this.dgvPodKategorija.Name = "dgvPodKategorija";
            this.dgvPodKategorija.ReadOnly = true;
            this.dgvPodKategorija.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPodKategorija.Size = new System.Drawing.Size(312, 333);
            this.dgvPodKategorija.TabIndex = 10;
            // 
            // PodKategorijaID
            // 
            this.PodKategorijaID.DataPropertyName = "PodKategorijaID";
            this.PodKategorijaID.HeaderText = "PodKategorijaID";
            this.PodKategorijaID.Name = "PodKategorijaID";
            this.PodKategorijaID.ReadOnly = true;
            this.PodKategorijaID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Subcategory name";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Kategorija
            // 
            this.Kategorija.DataPropertyName = "KategorijaString";
            this.Kategorija.HeaderText = "Category name";
            this.Kategorija.Name = "Kategorija";
            this.Kategorija.ReadOnly = true;
            // 
            // frmPodKategorija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 450);
            this.Controls.Add(this.dgvPodKategorija);
            this.Controls.Add(this.BtnAdd);
            this.Name = "frmPodKategorija";
            this.Text = "frmPodKategorija";
            this.Load += new System.EventHandler(this.frmPodKategorija_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPodKategorija)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.DataGridView dgvPodKategorija;
        private System.Windows.Forms.DataGridViewTextBoxColumn PodKategorijaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kategorija;
    }
}