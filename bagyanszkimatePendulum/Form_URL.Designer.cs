
namespace Pendulum
{
    partial class Form_URL
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtbox = new System.Windows.Forms.TextBox();
            this.addbnt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(313, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add URL";
            // 
            // txtbox
            // 
            this.txtbox.Location = new System.Drawing.Point(207, 211);
            this.txtbox.Multiline = true;
            this.txtbox.Name = "txtbox";
            this.txtbox.Size = new System.Drawing.Size(409, 39);
            this.txtbox.TabIndex = 3;
            // 
            // addbnt
            // 
            this.addbnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addbnt.Location = new System.Drawing.Point(282, 335);
            this.addbnt.Name = "addbnt";
            this.addbnt.Size = new System.Drawing.Size(225, 69);
            this.addbnt.TabIndex = 2;
            this.addbnt.Text = "Add";
            this.addbnt.UseVisualStyleBackColor = true;
            this.addbnt.Click += new System.EventHandler(this.add_Click);
            // 
            // Form_URL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 511);
            this.Controls.Add(this.addbnt);
            this.Controls.Add(this.txtbox);
            this.Controls.Add(this.label1);
            this.Name = "Form_URL";
            this.Text = "URL Share";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox;
        private System.Windows.Forms.Button addbnt;
    }
}