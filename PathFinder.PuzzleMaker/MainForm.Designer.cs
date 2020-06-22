using Pathfinder.PuzzleVisualizer.WinForms;

namespace PathFinder.PuzzleMaker
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
            this.emptyRadioButton = new System.Windows.Forms.RadioButton();
            this.wallRadioButton = new System.Windows.Forms.RadioButton();
            this.startRadioButton = new System.Windows.Forms.RadioButton();
            this.finishRadioButton = new System.Windows.Forms.RadioButton();
            this.loadButton = new System.Windows.Forms.Button();
            this.storeButton = new System.Windows.Forms.Button();
            this.widthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.heightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.teleport1RadioButton = new System.Windows.Forms.RadioButton();
            this.teleport2RadioButton = new System.Windows.Forms.RadioButton();
            this.teleport3RadioButton = new System.Windows.Forms.RadioButton();
            this.pathFinderPuzzleControl = new Pathfinder.PuzzleVisualizer.WinForms.PuzzleVisualizer();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // emptyRadioButton
            // 
            this.emptyRadioButton.AutoSize = true;
            this.emptyRadioButton.Location = new System.Drawing.Point(12, 12);
            this.emptyRadioButton.Name = "emptyRadioButton";
            this.emptyRadioButton.Size = new System.Drawing.Size(54, 17);
            this.emptyRadioButton.TabIndex = 1;
            this.emptyRadioButton.Text = "Empty";
            this.emptyRadioButton.UseVisualStyleBackColor = true;
            this.emptyRadioButton.CheckedChanged += new System.EventHandler(this.emptyRadioButton_CheckedChanged);
            // 
            // wallRadioButton
            // 
            this.wallRadioButton.AutoSize = true;
            this.wallRadioButton.Checked = true;
            this.wallRadioButton.Location = new System.Drawing.Point(12, 35);
            this.wallRadioButton.Name = "wallRadioButton";
            this.wallRadioButton.Size = new System.Drawing.Size(46, 17);
            this.wallRadioButton.TabIndex = 2;
            this.wallRadioButton.TabStop = true;
            this.wallRadioButton.Text = "Wall";
            this.wallRadioButton.UseVisualStyleBackColor = true;
            this.wallRadioButton.CheckedChanged += new System.EventHandler(this.wallRadioButton_CheckedChanged);
            // 
            // startRadioButton
            // 
            this.startRadioButton.AutoSize = true;
            this.startRadioButton.Location = new System.Drawing.Point(12, 58);
            this.startRadioButton.Name = "startRadioButton";
            this.startRadioButton.Size = new System.Drawing.Size(47, 17);
            this.startRadioButton.TabIndex = 3;
            this.startRadioButton.Text = "Start";
            this.startRadioButton.UseVisualStyleBackColor = true;
            this.startRadioButton.CheckedChanged += new System.EventHandler(this.startRadioButton_CheckedChanged);
            // 
            // finishRadioButton
            // 
            this.finishRadioButton.AutoSize = true;
            this.finishRadioButton.Location = new System.Drawing.Point(12, 81);
            this.finishRadioButton.Name = "finishRadioButton";
            this.finishRadioButton.Size = new System.Drawing.Size(52, 17);
            this.finishRadioButton.TabIndex = 4;
            this.finishRadioButton.Text = "Finish";
            this.finishRadioButton.UseVisualStyleBackColor = true;
            this.finishRadioButton.CheckedChanged += new System.EventHandler(this.finishRadioButton_CheckedChanged);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadButton.Location = new System.Drawing.Point(12, 443);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(135, 23);
            this.loadButton.TabIndex = 5;
            this.loadButton.Text = "Load puzzle";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // storeButton
            // 
            this.storeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.storeButton.Location = new System.Drawing.Point(12, 414);
            this.storeButton.Name = "storeButton";
            this.storeButton.Size = new System.Drawing.Size(135, 23);
            this.storeButton.TabIndex = 6;
            this.storeButton.Text = "Store puzzle";
            this.storeButton.UseVisualStyleBackColor = true;
            this.storeButton.Click += new System.EventHandler(this.storeButton_Click);
            // 
            // widthNumericUpDown
            // 
            this.widthNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.widthNumericUpDown.Location = new System.Drawing.Point(12, 197);
            this.widthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumericUpDown.Name = "widthNumericUpDown";
            this.widthNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.widthNumericUpDown.TabIndex = 7;
            this.widthNumericUpDown.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.widthNumericUpDown.ValueChanged += new System.EventHandler(this.widthNumericUpDown_ValueChanged);
            // 
            // heightNumericUpDown
            // 
            this.heightNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.heightNumericUpDown.Location = new System.Drawing.Point(12, 223);
            this.heightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNumericUpDown.Name = "heightNumericUpDown";
            this.heightNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.heightNumericUpDown.TabIndex = 8;
            this.heightNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.heightNumericUpDown.ValueChanged += new System.EventHandler(this.heightNumericUpDown_ValueChanged);
            // 
            // teleport1RadioButton
            // 
            this.teleport1RadioButton.AutoSize = true;
            this.teleport1RadioButton.Location = new System.Drawing.Point(12, 104);
            this.teleport1RadioButton.Name = "teleport1RadioButton";
            this.teleport1RadioButton.Size = new System.Drawing.Size(73, 17);
            this.teleport1RadioButton.TabIndex = 9;
            this.teleport1RadioButton.Text = "Teleport 1";
            this.teleport1RadioButton.UseVisualStyleBackColor = true;
            this.teleport1RadioButton.CheckedChanged += new System.EventHandler(this.teleport1RadioButton_CheckedChanged);
            // 
            // teleport2RadioButton
            // 
            this.teleport2RadioButton.AutoSize = true;
            this.teleport2RadioButton.Location = new System.Drawing.Point(12, 127);
            this.teleport2RadioButton.Name = "teleport2RadioButton";
            this.teleport2RadioButton.Size = new System.Drawing.Size(73, 17);
            this.teleport2RadioButton.TabIndex = 10;
            this.teleport2RadioButton.Text = "Teleport 2";
            this.teleport2RadioButton.UseVisualStyleBackColor = true;
            this.teleport2RadioButton.CheckedChanged += new System.EventHandler(this.teleport2RadioButton_CheckedChanged);
            // 
            // teleport3RadioButton
            // 
            this.teleport3RadioButton.AutoSize = true;
            this.teleport3RadioButton.Location = new System.Drawing.Point(12, 150);
            this.teleport3RadioButton.Name = "teleport3RadioButton";
            this.teleport3RadioButton.Size = new System.Drawing.Size(73, 17);
            this.teleport3RadioButton.TabIndex = 11;
            this.teleport3RadioButton.Text = "Teleport 3";
            this.teleport3RadioButton.UseVisualStyleBackColor = true;
            this.teleport3RadioButton.CheckedChanged += new System.EventHandler(this.teleport3RadioButton_CheckedChanged);
            // 
            // pathFinderPuzzleControl
            // 
            this.pathFinderPuzzleControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathFinderPuzzleControl.BackColor = System.Drawing.Color.Transparent;
            this.pathFinderPuzzleControl.EditBlockKind = Pathfinder.PuzzleVisualizer.WinForms.PuzzleVisualizer.BlockKind.Start;
            this.pathFinderPuzzleControl.EditMode = true;
            this.pathFinderPuzzleControl.GridHeight = 10;
            this.pathFinderPuzzleControl.GridWidth = 13;
            this.pathFinderPuzzleControl.Location = new System.Drawing.Point(153, 12);
            this.pathFinderPuzzleControl.Name = "pathFinderPuzzleControl";
            this.pathFinderPuzzleControl.Size = new System.Drawing.Size(673, 454);
            this.pathFinderPuzzleControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 478);
            this.Controls.Add(this.teleport3RadioButton);
            this.Controls.Add(this.teleport2RadioButton);
            this.Controls.Add(this.teleport1RadioButton);
            this.Controls.Add(this.heightNumericUpDown);
            this.Controls.Add(this.widthNumericUpDown);
            this.Controls.Add(this.storeButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.finishRadioButton);
            this.Controls.Add(this.startRadioButton);
            this.Controls.Add(this.wallRadioButton);
            this.Controls.Add(this.emptyRadioButton);
            this.Controls.Add(this.pathFinderPuzzleControl);
            this.Name = "MainForm";
            this.Text = "PathFinder PuzzleMaker";
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PuzzleVisualizer pathFinderPuzzleControl;
        private System.Windows.Forms.RadioButton emptyRadioButton;
        private System.Windows.Forms.RadioButton wallRadioButton;
        private System.Windows.Forms.RadioButton startRadioButton;
        private System.Windows.Forms.RadioButton finishRadioButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button storeButton;
        private System.Windows.Forms.NumericUpDown widthNumericUpDown;
        private System.Windows.Forms.NumericUpDown heightNumericUpDown;
        private System.Windows.Forms.RadioButton teleport1RadioButton;
        private System.Windows.Forms.RadioButton teleport2RadioButton;
        private System.Windows.Forms.RadioButton teleport3RadioButton;
    }
}

