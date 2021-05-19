
namespace eTickets.WinUI.Kategorija
{
    partial class frmKategorije
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
            this.dgvKategorija = new System.Windows.Forms.DataGridView();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.KategorijaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKategorija)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKategorija
            // 
            this.dgvKategorija.AllowUserToAddRows = false;
            this.dgvKategorija.AllowUserToDeleteRows = false;
            this.dgvKategorija.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKategorija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKategorija.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KategorijaId,
            this.Naziv});
            this.dgvKategorija.Location = new System.Drawing.Point(12, 93);
            this.dgvKategorija.Name = "dgvKategorija";
            this.dgvKategorija.ReadOnly = true;
            this.dgvKategorija.Size = new System.Drawing.Size(219, 334);
            this.dgvKategorija.TabIndex = 7;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(151, 51);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(80, 24);
            this.BtnAdd.TabIndex = 5;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            // 
            // KategorijaId
            // 
            this.KategorijaId.HeaderText = "KategorijaId";
            this.KategorijaId.Name = "KategorijaId";
            this.KategorijaId.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.HeaderText = "Category name";
            this.Naziv.Name = "Naziv";
            // 
            // frmKategorije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 450);
            this.Controls.Add(this.dgvKategorija);
            this.Controls.Add(this.BtnAdd);
            this.Name = "frmKategorije";
            this.Text = "Kategorije";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKategorija)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKategorija;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn KategorijaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
    }
}