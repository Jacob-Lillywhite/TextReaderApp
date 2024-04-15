using System.Windows.Forms;

namespace TextReader
{
    partial class FormOverlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOverlay));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CaptureButton = new System.Windows.Forms.Button();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.voiceSelector = new System.Windows.Forms.ComboBox();
            this.volumeSelector = new System.Windows.Forms.TrackBar();
            this.textBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ProcessingPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadingBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSelector)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.ProcessingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.CaptureButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProcessButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.voiceSelector, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.volumeSelector, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(572, 77);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // CaptureButton
            // 
            this.CaptureButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.CaptureButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CaptureButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CaptureButton.FlatAppearance.BorderSize = 0;
            this.CaptureButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(138)))));
            this.CaptureButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.CaptureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CaptureButton.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptureButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CaptureButton.Image = global::TextReader.Properties.Resources.snip;
            this.CaptureButton.Location = new System.Drawing.Point(3, 3);
            this.CaptureButton.Name = "CaptureButton";
            this.CaptureButton.Size = new System.Drawing.Size(280, 32);
            this.CaptureButton.TabIndex = 0;
            this.CaptureButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CaptureButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip1.SetToolTip(this.CaptureButton, "Capture Text");
            this.CaptureButton.UseVisualStyleBackColor = false;
            this.CaptureButton.Click += new System.EventHandler(this.CaptureButton_Click);
            // 
            // ProcessButton
            // 
            this.ProcessButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ProcessButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProcessButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ProcessButton.FlatAppearance.BorderSize = 0;
            this.ProcessButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(138)))));
            this.ProcessButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProcessButton.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessButton.Image = global::TextReader.Properties.Resources.play;
            this.ProcessButton.Location = new System.Drawing.Point(289, 3);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(280, 32);
            this.ProcessButton.TabIndex = 1;
            this.toolTip1.SetToolTip(this.ProcessButton, "Play Audio");
            this.ProcessButton.UseVisualStyleBackColor = false;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_ClickAsync);
            // 
            // voiceSelector
            // 
            this.voiceSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.voiceSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.voiceSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.voiceSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.voiceSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.voiceSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voiceSelector.ForeColor = System.Drawing.Color.White;
            this.voiceSelector.FormattingEnabled = true;
            this.voiceSelector.ItemHeight = 20;
            this.voiceSelector.Location = new System.Drawing.Point(16, 38);
            this.voiceSelector.Margin = new System.Windows.Forms.Padding(16, 0, 3, 0);
            this.voiceSelector.Name = "voiceSelector";
            this.voiceSelector.Size = new System.Drawing.Size(267, 28);
            this.voiceSelector.TabIndex = 2;
            this.toolTip1.SetToolTip(this.voiceSelector, "Select Voice");
            this.voiceSelector.SelectedIndexChanged += new System.EventHandler(this.VoiceSelector_SelectedIndexChanged);
            // 
            // volumeSelector
            // 
            this.volumeSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.volumeSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.volumeSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeSelector.LargeChange = 20;
            this.volumeSelector.Location = new System.Drawing.Point(289, 41);
            this.volumeSelector.Maximum = 100;
            this.volumeSelector.Name = "volumeSelector";
            this.volumeSelector.Size = new System.Drawing.Size(280, 33);
            this.volumeSelector.SmallChange = 10;
            this.volumeSelector.TabIndex = 3;
            this.volumeSelector.TickFrequency = 10;
            this.toolTip1.SetToolTip(this.volumeSelector, "Adjust Volume");
            this.volumeSelector.Value = 50;
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.ForeColor = System.Drawing.Color.White;
            this.textBox.Location = new System.Drawing.Point(16, 16);
            this.textBox.Margin = new System.Windows.Forms.Padding(16);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(540, 209);
            this.textBox.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.textBox, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 77);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(572, 241);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // ProcessingPanel
            // 
            this.ProcessingPanel.Controls.Add(this.label1);
            this.ProcessingPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProcessingPanel.Location = new System.Drawing.Point(0, 271);
            this.ProcessingPanel.Name = "ProcessingPanel";
            this.ProcessingPanel.Size = new System.Drawing.Size(572, 47);
            this.ProcessingPanel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(194, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Processing...";
            // 
            // LoadingBox
            // 
            this.LoadingBox.BackColor = System.Drawing.Color.Transparent;
            this.LoadingBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoadingBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.LoadingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadingBox.Image = global::TextReader.Properties.Resources.SquareSpinner;
            this.LoadingBox.Location = new System.Drawing.Point(0, 77);
            this.LoadingBox.Name = "LoadingBox";
            this.LoadingBox.Size = new System.Drawing.Size(572, 194);
            this.LoadingBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.LoadingBox.TabIndex = 5;
            this.LoadingBox.TabStop = false;
            // 
            // FormOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(572, 318);
            this.Controls.Add(this.LoadingBox);
            this.Controls.Add(this.ProcessingPanel);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOverlay";
            this.Text = "Text Reader";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSelector)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ProcessingPanel.ResumeLayout(false);
            this.ProcessingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingBox)).EndInit();
            this.ResumeLayout(false);

            // Uncomment this out to use native windows DARK_MODE styling,
            // it helps the WinForm looks a bit more mordern...
            //var preference = Convert.ToInt32(true);
            //DwmSetWindowAttribute(this.Handle,
            //                      DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE,
            //                      ref preference, sizeof(uint));
        }

        #endregion

        private Button CaptureButton;
        private Button ProcessButton;
        private ComboBox voiceSelector;
        private Label label1;
        private Panel ProcessingPanel;
        private PictureBox LoadingBox;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBox;
        private ToolTip toolTip1;
        private TrackBar volumeSelector;
    }
}