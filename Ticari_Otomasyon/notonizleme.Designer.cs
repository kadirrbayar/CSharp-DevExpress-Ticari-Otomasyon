namespace Ticari_Otomasyon
{
    partial class notonizleme
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
            this.detayTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // detayTextBox
            // 
            this.detayTextBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.detayTextBox.Location = new System.Drawing.Point(12, 12);
            this.detayTextBox.Name = "detayTextBox";
            this.detayTextBox.Size = new System.Drawing.Size(768, 537);
            this.detayTextBox.TabIndex = 0;
            this.detayTextBox.Text = "";
            // 
            // notonizleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 561);
            this.Controls.Add(this.detayTextBox);
            this.Name = "notonizleme";
            this.Text = "notonizleme";
            this.Load += new System.EventHandler(this.notonizleme_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox detayTextBox;
    }
}