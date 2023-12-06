
namespace ChessGame
{
    partial class PromoteForm
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
            this.promoteTo = new System.Windows.Forms.CheckedListBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // promoteTo
            // 
            this.promoteTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this.promoteTo.CheckOnClick = true;
            this.promoteTo.FormattingEnabled = true;
            this.promoteTo.Items.AddRange(new object[] {
            "Queen",
            "Bishop",
            "Knight",
            "Rook"});
            this.promoteTo.Location = new System.Drawing.Point(142, 43);
            this.promoteTo.Name = "promoteTo";
            this.promoteTo.Size = new System.Drawing.Size(114, 123);
            this.promoteTo.TabIndex = 0;
            this.promoteTo.SelectedIndexChanged += new System.EventHandler(this.promoteTo_SelectedIndexChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this.btnSelect.Location = new System.Drawing.Point(155, 200);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(82, 53);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Ok";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // PromoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(169)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(398, 341);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.promoteTo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PromoteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promote Pawn";
            this.Load += new System.EventHandler(this.PromoteForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox promoteTo;
        private System.Windows.Forms.Button btnSelect;
    }
}