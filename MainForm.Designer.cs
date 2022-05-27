namespace texswap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.loadPAKbutton = new System.Windows.Forms.ToolStripButton();
            this.ImgListContainer = new System.Windows.Forms.GroupBox();
            this.itemsHolder = new System.Windows.Forms.TreeView();
            this.itemIcons = new System.Windows.Forms.ImageList(this.components);
            this.sideBar1 = new System.Windows.Forms.SplitContainer();
            this.propsCont = new System.Windows.Forms.GroupBox();
            this.unktxt = new System.Windows.Forms.TextBox();
            this.unklbl = new System.Windows.Forms.Label();
            this.xlb = new System.Windows.Forms.Label();
            this.imghnum = new System.Windows.Forms.NumericUpDown();
            this.imgwnum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.imgpathtxt = new System.Windows.Forms.TextBox();
            this.imgpathlbl = new System.Windows.Forms.Label();
            this.propsApplyBtn = new System.Windows.Forms.Button();
            this.mainContain = new System.Windows.Forms.SplitContainer();
            this.curImg = new System.Windows.Forms.PictureBox();
            this.imgPanelCtxt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToolbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.openPak = new System.Windows.Forms.OpenFileDialog();
            this.status = new System.Windows.Forms.StatusStrip();
            this.exportDiag = new System.Windows.Forms.SaveFileDialog();
            this.importDiag = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip.SuspendLayout();
            this.ImgListContainer.SuspendLayout();
            this.sideBar1.Panel1.SuspendLayout();
            this.sideBar1.Panel2.SuspendLayout();
            this.sideBar1.SuspendLayout();
            this.propsCont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imghnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgwnum)).BeginInit();
            this.mainContain.Panel1.SuspendLayout();
            this.mainContain.Panel2.SuspendLayout();
            this.mainContain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.curImg)).BeginInit();
            this.imgPanelCtxt.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPAKbutton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(842, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // loadPAKbutton
            // 
            this.loadPAKbutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadPAKbutton.Image = global::texswap.Properties.Resources.openHS;
            this.loadPAKbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadPAKbutton.Name = "loadPAKbutton";
            this.loadPAKbutton.Size = new System.Drawing.Size(23, 22);
            this.loadPAKbutton.ToolTipText = "Open file";
            this.loadPAKbutton.Click += new System.EventHandler(this.clickLoadToolbtn);
            // 
            // ImgListContainer
            // 
            this.ImgListContainer.Controls.Add(this.itemsHolder);
            this.ImgListContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImgListContainer.Location = new System.Drawing.Point(0, 0);
            this.ImgListContainer.Name = "ImgListContainer";
            this.ImgListContainer.Size = new System.Drawing.Size(310, 517);
            this.ImgListContainer.TabIndex = 1;
            this.ImgListContainer.TabStop = false;
            this.ImgListContainer.Text = "Files";
            // 
            // itemsHolder
            // 
            this.itemsHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsHolder.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsHolder.ImageIndex = 0;
            this.itemsHolder.ImageList = this.itemIcons;
            this.itemsHolder.Location = new System.Drawing.Point(3, 16);
            this.itemsHolder.Name = "itemsHolder";
            this.itemsHolder.SelectedImageIndex = 0;
            this.itemsHolder.Size = new System.Drawing.Size(304, 498);
            this.itemsHolder.TabIndex = 0;
            this.itemsHolder.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.selectImg);
            // 
            // itemIcons
            // 
            this.itemIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("itemIcons.ImageStream")));
            this.itemIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.itemIcons.Images.SetKeyName(0, "pak0");
            this.itemIcons.Images.SetKeyName(1, "img0");
            this.itemIcons.Images.SetKeyName(2, "img1");
            this.itemIcons.Images.SetKeyName(3, "save");
            this.itemIcons.Images.SetKeyName(4, "swap");
            // 
            // sideBar1
            // 
            this.sideBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideBar1.Location = new System.Drawing.Point(0, 0);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sideBar1.Panel1
            // 
            this.sideBar1.Panel1.Controls.Add(this.ImgListContainer);
            // 
            // sideBar1.Panel2
            // 
            this.sideBar1.Panel2.Controls.Add(this.propsCont);
            this.sideBar1.Size = new System.Drawing.Size(310, 637);
            this.sideBar1.SplitterDistance = 517;
            this.sideBar1.TabIndex = 2;
            // 
            // propsCont
            // 
            this.propsCont.Controls.Add(this.imghnum);
            this.propsCont.Controls.Add(this.unktxt);
            this.propsCont.Controls.Add(this.unklbl);
            this.propsCont.Controls.Add(this.xlb);
            this.propsCont.Controls.Add(this.imgwnum);
            this.propsCont.Controls.Add(this.label1);
            this.propsCont.Controls.Add(this.imgpathtxt);
            this.propsCont.Controls.Add(this.imgpathlbl);
            this.propsCont.Controls.Add(this.propsApplyBtn);
            this.propsCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propsCont.Location = new System.Drawing.Point(0, 0);
            this.propsCont.Name = "propsCont";
            this.propsCont.Size = new System.Drawing.Size(310, 116);
            this.propsCont.TabIndex = 0;
            this.propsCont.TabStop = false;
            this.propsCont.Text = "Properties";
            // 
            // unktxt
            // 
            this.unktxt.Enabled = false;
            this.unktxt.Location = new System.Drawing.Point(72, 62);
            this.unktxt.Name = "unktxt";
            this.unktxt.Size = new System.Drawing.Size(100, 20);
            this.unktxt.TabIndex = 7;
            // 
            // unklbl
            // 
            this.unklbl.AutoSize = true;
            this.unklbl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.unklbl.Location = new System.Drawing.Point(6, 64);
            this.unklbl.Name = "unklbl";
            this.unklbl.Size = new System.Drawing.Size(56, 13);
            this.unklbl.TabIndex = 6;
            this.unklbl.Text = "Unknown:";
            // 
            // xlb
            // 
            this.xlb.AutoSize = true;
            this.xlb.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.xlb.Location = new System.Drawing.Point(131, 42);
            this.xlb.Name = "xlb";
            this.xlb.Size = new System.Drawing.Size(12, 13);
            this.xlb.TabIndex = 5;
            this.xlb.Text = "x";
            // 
            // imghnum
            // 
            this.imghnum.Enabled = false;
            this.imghnum.Location = new System.Drawing.Point(141, 39);
            this.imghnum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.imghnum.Name = "imghnum";
            this.imghnum.Size = new System.Drawing.Size(56, 20);
            this.imghnum.TabIndex = 4;
            this.imghnum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // imgwnum
            // 
            this.imgwnum.Enabled = false;
            this.imgwnum.Location = new System.Drawing.Point(72, 39);
            this.imgwnum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.imgwnum.Name = "imgwnum";
            this.imgwnum.Size = new System.Drawing.Size(56, 20);
            this.imgwnum.TabIndex = 4;
            this.imgwnum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Image scale:";
            // 
            // imgpathtxt
            // 
            this.imgpathtxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgpathtxt.Enabled = false;
            this.imgpathtxt.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgpathtxt.Location = new System.Drawing.Point(72, 17);
            this.imgpathtxt.Name = "imgpathtxt";
            this.imgpathtxt.Size = new System.Drawing.Size(232, 19);
            this.imgpathtxt.TabIndex = 2;
            // 
            // imgpathlbl
            // 
            this.imgpathlbl.AutoSize = true;
            this.imgpathlbl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.imgpathlbl.Location = new System.Drawing.Point(6, 19);
            this.imgpathlbl.Name = "imgpathlbl";
            this.imgpathlbl.Size = new System.Drawing.Size(63, 13);
            this.imgpathlbl.TabIndex = 1;
            this.imgpathlbl.Text = "Image path:";
            // 
            // propsApplyBtn
            // 
            this.propsApplyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.propsApplyBtn.Enabled = false;
            this.propsApplyBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.propsApplyBtn.Location = new System.Drawing.Point(204, 87);
            this.propsApplyBtn.Name = "propsApplyBtn";
            this.propsApplyBtn.Size = new System.Drawing.Size(100, 23);
            this.propsApplyBtn.TabIndex = 0;
            this.propsApplyBtn.Text = "Apply Changes";
            this.propsApplyBtn.UseVisualStyleBackColor = true;
            // 
            // mainContain
            // 
            this.mainContain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainContain.Location = new System.Drawing.Point(0, 28);
            this.mainContain.Name = "mainContain";
            // 
            // mainContain.Panel1
            // 
            this.mainContain.Panel1.Controls.Add(this.sideBar1);
            // 
            // mainContain.Panel2
            // 
            this.mainContain.Panel2.Controls.Add(this.curImg);
            this.mainContain.Size = new System.Drawing.Size(842, 637);
            this.mainContain.SplitterDistance = 310;
            this.mainContain.TabIndex = 3;
            // 
            // curImg
            // 
            this.curImg.ContextMenuStrip = this.imgPanelCtxt;
            this.curImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curImg.Location = new System.Drawing.Point(0, 0);
            this.curImg.Name = "curImg";
            this.curImg.Size = new System.Drawing.Size(528, 637);
            this.curImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.curImg.TabIndex = 0;
            this.curImg.TabStop = false;
            // 
            // imgPanelCtxt
            // 
            this.imgPanelCtxt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolbtn,
            this.importToolbtn});
            this.imgPanelCtxt.Name = "imgPanelCtxt";
            this.imgPanelCtxt.Size = new System.Drawing.Size(114, 48);
            // 
            // exportToolbtn
            // 
            this.exportToolbtn.Enabled = false;
            this.exportToolbtn.Name = "exportToolbtn";
            this.exportToolbtn.Size = new System.Drawing.Size(113, 22);
            this.exportToolbtn.Text = "Export...";
            this.exportToolbtn.Click += new System.EventHandler(this.xportBtn);
            // 
            // importToolbtn
            // 
            this.importToolbtn.Enabled = false;
            this.importToolbtn.Name = "importToolbtn";
            this.importToolbtn.Size = new System.Drawing.Size(113, 22);
            this.importToolbtn.Text = "Import...";
            this.importToolbtn.Click += new System.EventHandler(this.mportBtn);
            // 
            // openPak
            // 
            this.openPak.Filter = "All supported formats|*.tex.xen;*.tex.wpc;*.img.xen;*.img.wpc;*.pak.xen;*.pak.wpc" +
    "|PC PAK|*.xen;*.wpc|Guitar Hero PAK|*.xen|THAW PAK|*.wpc|Did QueenBee name it wr" +
    "ong?|*.qb.xen;*.qb.wpc|Any type|*.*";
            this.openPak.Multiselect = true;
            this.openPak.RestoreDirectory = true;
            this.openPak.SupportMultiDottedExtensions = true;
            this.openPak.Title = "Open texture image or PAK";
            this.openPak.FileOk += new System.ComponentModel.CancelEventHandler(this.loadFilesFromDiag);
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 668);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(842, 22);
            this.status.TabIndex = 4;
            // 
            // exportDiag
            // 
            this.exportDiag.Filter = "Common types|*.png;*.jpg;*.bmp|Picture files|*.png;*.jpg;*.bmp|Any type|*.*";
            this.exportDiag.RestoreDirectory = true;
            this.exportDiag.Title = "Import image";
            this.exportDiag.FileOk += new System.ComponentModel.CancelEventHandler(this.xportConfirm);
            // 
            // importDiag
            // 
            this.importDiag.Filter = "Common types|*.png;*.jpg;*.bmp;*.dds|Picture files|*.png;*.jpg;*.bmp|Any type|*.*" +
    "";
            this.importDiag.RestoreDirectory = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 690);
            this.Controls.Add(this.status);
            this.Controls.Add(this.mainContain);
            this.Controls.Add(this.toolStrip);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TexSwap (read-only rn)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.quit);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ImgListContainer.ResumeLayout(false);
            this.sideBar1.Panel1.ResumeLayout(false);
            this.sideBar1.Panel2.ResumeLayout(false);
            this.sideBar1.ResumeLayout(false);
            this.propsCont.ResumeLayout(false);
            this.propsCont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imghnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgwnum)).EndInit();
            this.mainContain.Panel1.ResumeLayout(false);
            this.mainContain.Panel2.ResumeLayout(false);
            this.mainContain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.curImg)).EndInit();
            this.imgPanelCtxt.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ImageList itemIcons;
        private System.Windows.Forms.PictureBox curImg;
        private System.Windows.Forms.GroupBox propsCont;
        private System.Windows.Forms.TreeView itemsHolder;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.OpenFileDialog openPak;
        private System.Windows.Forms.SplitContainer mainContain;
        private System.Windows.Forms.SplitContainer sideBar1;
        private System.Windows.Forms.GroupBox ImgListContainer;
        private System.Windows.Forms.ToolStripButton loadPAKbutton;
        private System.Windows.Forms.ToolStrip toolStrip;

        #endregion

        private System.Windows.Forms.ContextMenuStrip imgPanelCtxt;
        private System.Windows.Forms.ToolStripMenuItem exportToolbtn;
        private System.Windows.Forms.ToolStripMenuItem importToolbtn;
        private System.Windows.Forms.SaveFileDialog exportDiag;
        private System.Windows.Forms.OpenFileDialog importDiag;
        private System.Windows.Forms.TextBox unktxt;
        private System.Windows.Forms.Label unklbl;
        private System.Windows.Forms.Label xlb;
        private System.Windows.Forms.NumericUpDown imghnum;
        private System.Windows.Forms.NumericUpDown imgwnum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imgpathtxt;
        private System.Windows.Forms.Label imgpathlbl;
        private System.Windows.Forms.Button propsApplyBtn;
    }
}