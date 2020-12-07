namespace Visualizer.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelTools = new System.Windows.Forms.Panel();
            this.labelShow = new System.Windows.Forms.Label();
            this.labelPutFreePath = new System.Windows.Forms.Label();
            this.labelPutWall = new System.Windows.Forms.Label();
            this.labelPutTarget = new System.Windows.Forms.Label();
            this.labelPutOrigin = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelReset = new System.Windows.Forms.Label();
            this.labelRun = new System.Windows.Forms.Label();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSite = new System.Windows.Forms.Label();
            this.labelCredits = new System.Windows.Forms.Label();
            this.panelTools.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTools
            // 
            this.panelTools.BackColor = System.Drawing.Color.White;
            this.panelTools.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTools.Controls.Add(this.labelShow);
            this.panelTools.Controls.Add(this.labelPutOrigin);
            this.panelTools.Controls.Add(this.labelPutTarget);
            this.panelTools.Controls.Add(this.labelPutWall);
            this.panelTools.Controls.Add(this.labelPutFreePath);
            this.panelTools.Controls.Add(this.comboBox);
            this.panelTools.Controls.Add(this.label1);
            this.panelTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTools.Location = new System.Drawing.Point(0, 0);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(1300, 51);
            this.panelTools.TabIndex = 0;
            // 
            // labelShow
            // 
            this.labelShow.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShow.Location = new System.Drawing.Point(688, 0);
            this.labelShow.Name = "labelShow";
            this.labelShow.Size = new System.Drawing.Size(179, 47);
            this.labelShow.TabIndex = 8;
            this.labelShow.Text = "Put blocks:";
            this.labelShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPutFreePath
            // 
            this.labelPutFreePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPutFreePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPutFreePath.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelPutFreePath.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPutFreePath.Location = new System.Drawing.Point(1167, 0);
            this.labelPutFreePath.Name = "labelPutFreePath";
            this.labelPutFreePath.Size = new System.Drawing.Size(129, 47);
            this.labelPutFreePath.TabIndex = 7;
            this.labelPutFreePath.Text = "Free path";
            this.labelPutFreePath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPutFreePath.Click += new System.EventHandler(this.LabelPutFreePath_Click);
            // 
            // labelPutWall
            // 
            this.labelPutWall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPutWall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPutWall.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelPutWall.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPutWall.Location = new System.Drawing.Point(1067, 0);
            this.labelPutWall.Name = "labelPutWall";
            this.labelPutWall.Size = new System.Drawing.Size(100, 47);
            this.labelPutWall.TabIndex = 6;
            this.labelPutWall.Text = "Wall";
            this.labelPutWall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPutWall.Click += new System.EventHandler(this.LabelPutWall_Click);
            // 
            // labelPutTarget
            // 
            this.labelPutTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPutTarget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPutTarget.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelPutTarget.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPutTarget.Location = new System.Drawing.Point(967, 0);
            this.labelPutTarget.Name = "labelPutTarget";
            this.labelPutTarget.Size = new System.Drawing.Size(100, 47);
            this.labelPutTarget.TabIndex = 5;
            this.labelPutTarget.Text = "Target";
            this.labelPutTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPutTarget.Click += new System.EventHandler(this.LabelPutTarget_Click);
            // 
            // labelPutOrigin
            // 
            this.labelPutOrigin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPutOrigin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPutOrigin.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelPutOrigin.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPutOrigin.Location = new System.Drawing.Point(867, 0);
            this.labelPutOrigin.Name = "labelPutOrigin";
            this.labelPutOrigin.Size = new System.Drawing.Size(100, 47);
            this.labelPutOrigin.TabIndex = 4;
            this.labelPutOrigin.Text = "Origin";
            this.labelPutOrigin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPutOrigin.Click += new System.EventHandler(this.LabelPutOrigin_Click);
            // 
            // comboBox
            // 
            this.comboBox.CausesValidation = false;
            this.comboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox.Font = new System.Drawing.Font("Verdana", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.ForeColor = System.Drawing.Color.Black;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.ItemHeight = 38;
            this.comboBox.Location = new System.Drawing.Point(179, 0);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(347, 46);
            this.comboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Algorithms:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelReset
            // 
            this.labelReset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReset.Location = new System.Drawing.Point(1126, 0);
            this.labelReset.Name = "labelReset";
            this.labelReset.Size = new System.Drawing.Size(105, 49);
            this.labelReset.TabIndex = 3;
            this.labelReset.Text = "Reset";
            this.labelReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelReset.Click += new System.EventHandler(this.LabelReset_Click);
            // 
            // labelRun
            // 
            this.labelRun.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRun.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRun.Location = new System.Drawing.Point(1231, 0);
            this.labelRun.Name = "labelRun";
            this.labelRun.Size = new System.Drawing.Size(69, 49);
            this.labelRun.TabIndex = 0;
            this.labelRun.Text = "Run";
            this.labelRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRun.Click += new System.EventHandler(this.LabelRun_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.BackColor = System.Drawing.Color.CadetBlue;
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGrid.Location = new System.Drawing.Point(0, 51);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1300, 739);
            this.panelGrid.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Interval = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labelSite);
            this.panel1.Controls.Add(this.labelCredits);
            this.panel1.Controls.Add(this.labelReset);
            this.panel1.Controls.Add(this.labelRun);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 790);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 49);
            this.panel1.TabIndex = 2;
            // 
            // labelSite
            // 
            this.labelSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSite.Location = new System.Drawing.Point(123, 0);
            this.labelSite.Name = "labelSite";
            this.labelSite.Size = new System.Drawing.Size(123, 49);
            this.labelSite.TabIndex = 5;
            this.labelSite.Text = "Site";
            this.labelSite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSite.Click += new System.EventHandler(this.LabelSite_Click);
            // 
            // labelCredits
            // 
            this.labelCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCredits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCredits.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCredits.Location = new System.Drawing.Point(0, 0);
            this.labelCredits.Name = "labelCredits";
            this.labelCredits.Size = new System.Drawing.Size(123, 49);
            this.labelCredits.TabIndex = 4;
            this.labelCredits.Text = "Credits";
            this.labelCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCredits.Click += new System.EventHandler(this.LabelCredits_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 839);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelTools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PathFinding Visualizer";
            this.panelTools.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Label labelRun;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPutWall;
        private System.Windows.Forms.Label labelPutTarget;
        private System.Windows.Forms.Label labelPutOrigin;
        private System.Windows.Forms.Label labelReset;
        private System.Windows.Forms.Label labelPutFreePath;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelShow;
        private System.Windows.Forms.Label labelSite;
        private System.Windows.Forms.Label labelCredits;
    }
}

