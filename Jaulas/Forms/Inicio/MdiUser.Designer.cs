namespace Jaulas
{
    partial class MdiUser
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iNICIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aLMACENToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pRODUCCIÓNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vENTASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vENTANASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iNICIOToolStripMenuItem,
            this.aLMACENToolStripMenuItem,
            this.pRODUCCIÓNToolStripMenuItem,
            this.vENTASToolStripMenuItem,
            this.vENTANASToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iNICIOToolStripMenuItem
            // 
            this.iNICIOToolStripMenuItem.Name = "iNICIOToolStripMenuItem";
            this.iNICIOToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.iNICIOToolStripMenuItem.Text = "INICIO";
            // 
            // aLMACENToolStripMenuItem
            // 
            this.aLMACENToolStripMenuItem.Name = "aLMACENToolStripMenuItem";
            this.aLMACENToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.aLMACENToolStripMenuItem.Text = "ALMACEN";
            // 
            // pRODUCCIÓNToolStripMenuItem
            // 
            this.pRODUCCIÓNToolStripMenuItem.Name = "pRODUCCIÓNToolStripMenuItem";
            this.pRODUCCIÓNToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.pRODUCCIÓNToolStripMenuItem.Text = "PRODUCCIÓN";
            // 
            // vENTASToolStripMenuItem
            // 
            this.vENTASToolStripMenuItem.Name = "vENTASToolStripMenuItem";
            this.vENTASToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.vENTASToolStripMenuItem.Text = "VENTAS";
            // 
            // vENTANASToolStripMenuItem
            // 
            this.vENTANASToolStripMenuItem.Name = "vENTANASToolStripMenuItem";
            this.vENTANASToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.vENTANASToolStripMenuItem.Text = "VENTANAS";
            // 
            // MdiUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MdiUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIANNEY JAULAS S.A.";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iNICIOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aLMACENToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pRODUCCIÓNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vENTASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vENTANASToolStripMenuItem;
    }
}