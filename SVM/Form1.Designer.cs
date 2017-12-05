namespace SVM
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveVrmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refHeightPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculate3DPositionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guidelinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xGuidelinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yGuidelineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allGuidelinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateVPsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homographyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateAlphaZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(12, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(551, 369);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 471);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(585, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.loadModelToolStripMenuItem,
            this.saveModelToolStripMenuItem,
            this.saveVrmlToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.loadFileToolStripMenuItem.Text = "Load File";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // loadModelToolStripMenuItem
            // 
            this.loadModelToolStripMenuItem.Name = "loadModelToolStripMenuItem";
            this.loadModelToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.loadModelToolStripMenuItem.Text = "Load Model";
            this.loadModelToolStripMenuItem.Click += new System.EventHandler(this.loadModelToolStripMenuItem_Click);
            // 
            // saveModelToolStripMenuItem
            // 
            this.saveModelToolStripMenuItem.Name = "saveModelToolStripMenuItem";
            this.saveModelToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveModelToolStripMenuItem.Text = "Save Model";
            this.saveModelToolStripMenuItem.Click += new System.EventHandler(this.saveModelToolStripMenuItem_Click);
            // 
            // saveVrmlToolStripMenuItem
            // 
            this.saveVrmlToolStripMenuItem.Name = "saveVrmlToolStripMenuItem";
            this.saveVrmlToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveVrmlToolStripMenuItem.Text = "Save VRML";
            this.saveVrmlToolStripMenuItem.Click += new System.EventHandler(this.saveVrmlToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xLinesToolStripMenuItem,
            this.yLinesToolStripMenuItem,
            this.zLinesToolStripMenuItem,
            this.pointsToolStripMenuItem,
            this.refHeightPointToolStripMenuItem,
            this.calculate3DPositionToolStripMenuItem1,
            this.polygonToolStripMenuItem,
            this.guidelinesToolStripMenuItem,
            this.xGuidelinesToolStripMenuItem,
            this.yGuidelineToolStripMenuItem,
            this.allGuidelinesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // xLinesToolStripMenuItem
            // 
            this.xLinesToolStripMenuItem.Name = "xLinesToolStripMenuItem";
            this.xLinesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.xLinesToolStripMenuItem.Text = "X Lines";
            this.xLinesToolStripMenuItem.Click += new System.EventHandler(this.xLinesToolStripMenuItem_Click);
            // 
            // yLinesToolStripMenuItem
            // 
            this.yLinesToolStripMenuItem.Name = "yLinesToolStripMenuItem";
            this.yLinesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.yLinesToolStripMenuItem.Text = "Y Lines";
            this.yLinesToolStripMenuItem.Click += new System.EventHandler(this.yLinesToolStripMenuItem_Click);
            // 
            // zLinesToolStripMenuItem
            // 
            this.zLinesToolStripMenuItem.Name = "zLinesToolStripMenuItem";
            this.zLinesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.zLinesToolStripMenuItem.Text = "Z Lines";
            this.zLinesToolStripMenuItem.Click += new System.EventHandler(this.zLinesToolStripMenuItem_Click);
            // 
            // pointsToolStripMenuItem
            // 
            this.pointsToolStripMenuItem.Name = "pointsToolStripMenuItem";
            this.pointsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.pointsToolStripMenuItem.Text = "Ref. Plane Point";
            this.pointsToolStripMenuItem.Click += new System.EventHandler(this.pointsToolStripMenuItem_Click);
            // 
            // refHeightPointToolStripMenuItem
            // 
            this.refHeightPointToolStripMenuItem.Name = "refHeightPointToolStripMenuItem";
            this.refHeightPointToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.refHeightPointToolStripMenuItem.Text = "Ref. Height Point";
            this.refHeightPointToolStripMenuItem.Click += new System.EventHandler(this.refHeightPointToolStripMenuItem_Click);
            // 
            // calculate3DPositionToolStripMenuItem1
            // 
            this.calculate3DPositionToolStripMenuItem1.Name = "calculate3DPositionToolStripMenuItem1";
            this.calculate3DPositionToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.calculate3DPositionToolStripMenuItem1.Text = "Calculate 3D position";
            this.calculate3DPositionToolStripMenuItem1.Click += new System.EventHandler(this.calculate3DPositionToolStripMenuItem1_Click);
            // 
            // polygonToolStripMenuItem
            // 
            this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            this.polygonToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.polygonToolStripMenuItem.Text = "Polygon";
            this.polygonToolStripMenuItem.Click += new System.EventHandler(this.polygonToolStripMenuItem_Click);
            // 
            // guidelinesToolStripMenuItem
            // 
            this.guidelinesToolStripMenuItem.Name = "guidelinesToolStripMenuItem";
            this.guidelinesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.guidelinesToolStripMenuItem.Text = "Z Guideline";
            this.guidelinesToolStripMenuItem.Click += new System.EventHandler(this.guidelinesToolStripMenuItem_Click);
            // 
            // xGuidelinesToolStripMenuItem
            // 
            this.xGuidelinesToolStripMenuItem.Name = "xGuidelinesToolStripMenuItem";
            this.xGuidelinesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.xGuidelinesToolStripMenuItem.Text = "X Guideline";
            this.xGuidelinesToolStripMenuItem.Click += new System.EventHandler(this.xGuidelinesToolStripMenuItem_Click);
            // 
            // yGuidelineToolStripMenuItem
            // 
            this.yGuidelineToolStripMenuItem.Name = "yGuidelineToolStripMenuItem";
            this.yGuidelineToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.yGuidelineToolStripMenuItem.Text = "Y Guideline";
            this.yGuidelineToolStripMenuItem.Click += new System.EventHandler(this.yGuidelineToolStripMenuItem_Click);
            // 
            // allGuidelinesToolStripMenuItem
            // 
            this.allGuidelinesToolStripMenuItem.Name = "allGuidelinesToolStripMenuItem";
            this.allGuidelinesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.allGuidelinesToolStripMenuItem.Text = "All Guidelines";
            this.allGuidelinesToolStripMenuItem.Click += new System.EventHandler(this.allGuidelinesToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateVPsToolStripMenuItem,
            this.homographyToolStripMenuItem,
            this.calculateAlphaZToolStripMenuItem,
            this.textureToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // calculateVPsToolStripMenuItem
            // 
            this.calculateVPsToolStripMenuItem.Name = "calculateVPsToolStripMenuItem";
            this.calculateVPsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.calculateVPsToolStripMenuItem.Text = "Calculate VPs";
            this.calculateVPsToolStripMenuItem.Click += new System.EventHandler(this.calculateVPsToolStripMenuItem_Click);
            // 
            // homographyToolStripMenuItem
            // 
            this.homographyToolStripMenuItem.Name = "homographyToolStripMenuItem";
            this.homographyToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.homographyToolStripMenuItem.Text = "Homography";
            this.homographyToolStripMenuItem.Click += new System.EventHandler(this.homographyToolStripMenuItem_Click);
            // 
            // calculateAlphaZToolStripMenuItem
            // 
            this.calculateAlphaZToolStripMenuItem.Name = "calculateAlphaZToolStripMenuItem";
            this.calculateAlphaZToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.calculateAlphaZToolStripMenuItem.Text = "Calculate AlphaZ";
            this.calculateAlphaZToolStripMenuItem.Click += new System.EventHandler(this.calculateAlphaZToolStripMenuItem_Click);
            // 
            // textureToolStripMenuItem
            // 
            this.textureToolStripMenuItem.Name = "textureToolStripMenuItem";
            this.textureToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.textureToolStripMenuItem.Text = "Texture";
            this.textureToolStripMenuItem.Click += new System.EventHandler(this.textureToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 435);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 435);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 17);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.Text = "Same XY";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(92, 25);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(62, 17);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Same Z";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip2.Location = new System.Drawing.Point(173, 24);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(58, 25);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Backspace";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Z=0";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(585, 496);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateVPsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem homographyToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem refHeightPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateAlphaZToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ToolStripMenuItem calculate3DPositionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem textureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveVrmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem guidelinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xGuidelinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yGuidelineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allGuidelinesToolStripMenuItem;
    }
}

