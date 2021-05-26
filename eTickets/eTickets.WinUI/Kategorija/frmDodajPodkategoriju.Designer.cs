
namespace eTickets.WinUI.Kategorija
{
    partial class frmDodajPodkategoriju
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbNaziv = new System.Windows.Forms.TextBox();
            this.cmbKategorija = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subcategory name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Category :";
            // 
            // txtbNaziv
            // 
            this.txtbNaziv.Location = new System.Drawing.Point(135, 35);
            this.txtbNaziv.Name = "txtbNaziv";
            this.txtbNaziv.Size = new System.Drawing.Size(164, 20);
            this.txtbNaziv.TabIndex = 2;
            this.txtbNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtbNaziv_Validating);
            // 
            // cmbKategorija
            // 
            this.cmbKategorija.FormattingEnabled = true;
            this.cmbKategorija.Location = new System.Drawing.Point(135, 74);
            this.cmbKategorija.Name = "cmbKategorija";
            this.cmbKategorija.Size = new System.Drawing.Size(164, 21);
            this.cmbKategorija.TabIndex = 3;
            this.cmbKategorija.Validating += new System.ComponentModel.CancelEventHandler(this.cmbKategorija_Validating);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(220, 122);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(79, 28);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmDodajPodkategoriju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 187);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbKategorija);
            this.Controls.Add(this.txtbNaziv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDodajPodkategoriju";
            this.Text = "Add new subcategory";
            this.Load += new System.EventHandler(this.frmDodajPodkategoriju_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbNaziv;
        private System.Windows.Forms.ComboBox cmbKategorija;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}