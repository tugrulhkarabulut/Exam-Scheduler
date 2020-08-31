namespace DiscreteMathProject
{
    partial class GraphForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.appNameLabel = new System.Windows.Forms.Label();
            this.totalCourseLabel = new System.Windows.Forms.Label();
            this.totalCourse = new System.Windows.Forms.Label();
            this.colorGroups = new System.Windows.Forms.Label();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.resultText = new System.Windows.Forms.Label();
            this.showGraphPanel = new System.Windows.Forms.Button();
            this.showInfoPanel = new System.Windows.Forms.Button();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.graphPanel.SuspendLayout();
            this.SuspendLayout();
            this.AutoScroll = true;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            // 
            // appNameLabel
            // 
            this.appNameLabel.AutoSize = true;
            this.appNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.appNameLabel.Location = new System.Drawing.Point(564, 13);
            this.appNameLabel.Name = "appNameLabel";
            this.appNameLabel.Size = new System.Drawing.Size(234, 26);
            this.appNameLabel.TabIndex = 0;
            this.appNameLabel.Text = "Graf Boyama Problemi";
            // 
            // totalCourseLabel
            // 
            this.totalCourseLabel.AutoSize = true;
            this.totalCourseLabel.Location = new System.Drawing.Point(283, 73);
            this.totalCourseLabel.Name = "totalCourseLabel";
            this.totalCourseLabel.Size = new System.Drawing.Size(134, 17);
            this.totalCourseLabel.TabIndex = 2;
            this.totalCourseLabel.Text = "Toplam Ders Sayısı:";
            // 
            // totalCourse
            // 
            this.totalCourse.AutoSize = true;
            this.totalCourse.Location = new System.Drawing.Point(413, 73);
            this.totalCourse.Name = "totalCourse";
            this.totalCourse.Size = new System.Drawing.Size(46, 17);
            this.totalCourse.TabIndex = 3;
            this.totalCourse.Text = "label4";

            // 
            // colorGroups
            // 
            this.colorGroups.AutoSize = true;
            this.colorGroups.Location = new System.Drawing.Point(300, 450);
            this.colorGroups.Name = "colorGroups";
            this.colorGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colorGroups.Size = new System.Drawing.Size(100, 30);
            this.colorGroups.TabIndex = 3;
            this.colorGroups.Text = "Ders Renk Grupları";
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.dataGridView1);
            this.infoPanel.Controls.Add(this.resultText);
            this.infoPanel.Controls.Add(this.showGraphPanel);
            this.infoPanel.Controls.Add(this.totalCourse);
            this.infoPanel.Controls.Add(this.totalCourseLabel);
            this.infoPanel.Controls.Add(this.appNameLabel);
            this.infoPanel.Controls.Add(this.colorGroups);
            this.infoPanel.Location = new System.Drawing.Point(1, 0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(1346, windowHeight);
            this.infoPanel.TabIndex = 0;
            this.infoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.InfoPanel_Paint);

            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(283, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(835, 230);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // resultText
            // 
            this.resultText.AutoSize = true;
            this.resultText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.resultText.Location = new System.Drawing.Point(329, 360);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(60, 24);
            this.resultText.TabIndex = 6;
            this.resultText.Text = "label1";
            // 
            // showGraphPanel
            // 
            this.showGraphPanel.Location = new System.Drawing.Point(1000, 10);
            this.showGraphPanel.Name = "showGraphPanel";
            this.showGraphPanel.Size = new System.Drawing.Size(182, 32);
            this.showGraphPanel.TabIndex = 5;
            this.showGraphPanel.Text = "Grafı Göster";
            this.showGraphPanel.UseVisualStyleBackColor = true;
            this.showGraphPanel.Click += new System.EventHandler(this.showGraphPanel_Click);
            // 
            // showInfoPanel
            // 
            this.showInfoPanel.Location = new System.Drawing.Point(1000, 10);
            this.showInfoPanel.Name = "showInfoPanel";
            this.showInfoPanel.Size = new System.Drawing.Size(143, 35);
            this.showInfoPanel.TabIndex = 7;
            this.showInfoPanel.Text = "Geri Dön";
            this.showInfoPanel.UseVisualStyleBackColor = true;
            this.showInfoPanel.Click += new System.EventHandler(this.showInfoPanel_Click);
            // 
            // graphPanel
            // 
            this.graphPanel.Controls.Add(this.showInfoPanel);
            this.graphPanel.Location = new System.Drawing.Point(0, 0);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(5000, windowHeight);
            this.graphPanel.TabIndex = 0;
            this.graphPanel.Visible = false;
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphPanel_Paint);
            this.graphPanel.AutoScroll = true;
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 637);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.infoPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GraphForm";
            this.Text = "Graf Boyama";
            this.Load += new System.EventHandler(this.GraphForm_Load);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.graphPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label appNameLabel;
        private System.Windows.Forms.Label totalCourseLabel;
        private System.Windows.Forms.Label totalCourse;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label colorGroups;
        private System.Windows.Forms.Label resultText;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Button showGraphPanel;
        private System.Windows.Forms.Button showInfoPanel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private int windowHeight = 1200;
    }
}

