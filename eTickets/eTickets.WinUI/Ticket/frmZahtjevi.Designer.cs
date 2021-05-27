
namespace eTickets.WinUI.Ticket
{
    partial class frmZahtjevi
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
            this.dgvZahtjevi = new System.Windows.Forms.DataGridView();
            this.TicketId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NazivDogadjaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZahtjevi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvZahtjevi
            // 
            this.dgvZahtjevi.AllowUserToAddRows = false;
            this.dgvZahtjevi.AllowUserToDeleteRows = false;
            this.dgvZahtjevi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvZahtjevi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZahtjevi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketId,
            this.NazivDogadjaja,
            this.Datum});
            this.dgvZahtjevi.Location = new System.Drawing.Point(73, 69);
            this.dgvZahtjevi.MultiSelect = false;
            this.dgvZahtjevi.Name = "dgvZahtjevi";
            this.dgvZahtjevi.ReadOnly = true;
            this.dgvZahtjevi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvZahtjevi.Size = new System.Drawing.Size(416, 275);
            this.dgvZahtjevi.TabIndex = 0;
            this.dgvZahtjevi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvZahtjevi_MouseDoubleClick);
            // 
            // TicketId
            // 
            this.TicketId.DataPropertyName = "TicketId";
            this.TicketId.HeaderText = "TicketId";
            this.TicketId.Name = "TicketId";
            this.TicketId.ReadOnly = true;
            this.TicketId.Visible = false;
            // 
            // NazivDogadjaja
            // 
            this.NazivDogadjaja.DataPropertyName = "NazivDogadjaja";
            this.NazivDogadjaja.HeaderText = "Event";
            this.NazivDogadjaja.Name = "NazivDogadjaja";
            this.NazivDogadjaja.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.DataPropertyName = "Datum";
            this.Datum.HeaderText = "Date of event";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "*Double click on row to preview ticket";
            // 
            // frmZahtjevi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 405);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvZahtjevi);
            this.Name = "frmZahtjevi";
            this.Text = "Requests";
            this.Load += new System.EventHandler(this.frmZahtjevi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZahtjevi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvZahtjevi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NazivDogadjaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
    }
}