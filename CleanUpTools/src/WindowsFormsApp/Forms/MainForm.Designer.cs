
namespace WindowsFormsApp.Forms
{
    partial class MainForm
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
            this.btnSettings = new System.Windows.Forms.Button();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.btnCleanUp = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSettings.Location = new System.Drawing.Point(643, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(129, 61);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "edit settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // rtbConsole
            // 
            this.rtbConsole.Location = new System.Drawing.Point(12, 12);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(625, 337);
            this.rtbConsole.TabIndex = 1;
            this.rtbConsole.Text = "";
            // 
            // btnCleanUp
            // 
            this.btnCleanUp.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCleanUp.Location = new System.Drawing.Point(643, 79);
            this.btnCleanUp.Name = "btnCleanUp";
            this.btnCleanUp.Size = new System.Drawing.Size(129, 61);
            this.btnCleanUp.TabIndex = 2;
            this.btnCleanUp.Text = "clean up";
            this.btnCleanUp.UseVisualStyleBackColor = true;
            this.btnCleanUp.Click += new System.EventHandler(this.btnCleanUp_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(643, 288);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(129, 61);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "exit app";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCleanUp);
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.btnSettings);
            this.Name = "MainForm";
            this.Text = "CLEAN UP";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.Button btnCleanUp;
        private System.Windows.Forms.Button btnExit;
    }
}