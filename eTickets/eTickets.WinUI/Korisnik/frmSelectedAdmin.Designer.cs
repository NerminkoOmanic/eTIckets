
namespace eTickets.WinUI.Korisnik
{
    partial class frmSelectedAdmin
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.Location = new System.Drawing.Point(85, 83);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 37);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete user";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(85, 31);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(113, 37);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset password";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // frmSelectedAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 148);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Name = "frmSelectedAdmin";
            this.Text = "Option box";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
    }
}