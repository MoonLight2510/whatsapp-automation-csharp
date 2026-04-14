namespace WhatsappTopluMesaj
{
    partial class Form1
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            gridexcel = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btngonder = new Button();
            combomin = new ComboBox();
            combomaks = new ComboBox();
            comboefazla = new ComboBox();
            btnExcelYukle = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridexcel).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(-2, -5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1393, 109);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 1, true);
            label1.Location = new Point(396, 23);
            label1.Name = "label1";
            label1.Size = new Size(669, 46);
            label1.TabIndex = 0;
            label1.Text = "Whatsapp Mesaj Gönderme Otomasyonu";
            // 
            // gridexcel
            // 
            gridexcel.BackgroundColor = Color.White;
            gridexcel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridexcel.Location = new Point(26, 101);
            gridexcel.Name = "gridexcel";
            gridexcel.RowHeadersWidth = 51;
            gridexcel.Size = new Size(1329, 314);
            gridexcel.TabIndex = 1;
            gridexcel.CellContentClick += gridexcel_CellContentClick;
            gridexcel.CellContentDoubleClick += gridexcel_CellContentDoubleClick;
            gridexcel.CellDoubleClick += gridexcel_CellDoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.Location = new Point(42, 455);
            label2.Name = "label2";
            label2.Size = new Size(124, 30);
            label2.TabIndex = 2;
            label2.Text = "Minimum :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.Location = new Point(27, 501);
            label3.Name = "label3";
            label3.Size = new Size(139, 30);
            label3.TabIndex = 3;
            label3.Text = "Maksimum :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.Location = new Point(59, 544);
            label4.Name = "label4";
            label4.Size = new Size(107, 30);
            label4.TabIndex = 4;
            label4.Text = "En Fazla :";
            // 
            // btngonder
            // 
            btngonder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btngonder.Location = new Point(1198, 445);
            btngonder.Name = "btngonder";
            btngonder.Size = new Size(135, 74);
            btngonder.TabIndex = 5;
            btngonder.Text = "Gönder";
            btngonder.UseVisualStyleBackColor = true;
            btngonder.Click += btngonder_Click;
            // 
            // combomin
            // 
            combomin.FormattingEnabled = true;
            combomin.Location = new Point(183, 460);
            combomin.Name = "combomin";
            combomin.Size = new Size(151, 28);
            combomin.TabIndex = 6;
            // 
            // combomaks
            // 
            combomaks.FormattingEnabled = true;
            combomaks.Location = new Point(183, 506);
            combomaks.Name = "combomaks";
            combomaks.Size = new Size(151, 28);
            combomaks.TabIndex = 7;
            // 
            // comboefazla
            // 
            comboefazla.FormattingEnabled = true;
            comboefazla.Location = new Point(183, 549);
            comboefazla.Name = "comboefazla";
            comboefazla.Size = new Size(151, 28);
            comboefazla.TabIndex = 8;
            // 
            // btnExcelYukle
            // 
            btnExcelYukle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExcelYukle.Location = new Point(1034, 445);
            btnExcelYukle.Name = "btnExcelYukle";
            btnExcelYukle.Size = new Size(135, 74);
            btnExcelYukle.TabIndex = 9;
            btnExcelYukle.Text = "Excel Yükle";
            btnExcelYukle.UseVisualStyleBackColor = true;
            btnExcelYukle.Click += btnExcelYukle_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1382, 603);
            Controls.Add(btnExcelYukle);
            Controls.Add(comboefazla);
            Controls.Add(combomaks);
            Controls.Add(combomin);
            Controls.Add(btngonder);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(gridexcel);
            Controls.Add(groupBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Whatsapp Mesaj Gönderme Otomasyonu";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridexcel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private DataGridView gridexcel;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btngonder;
        private ComboBox combomin;
        private ComboBox combomaks;
        private ComboBox comboefazla;
        private Button btnExcelYukle;
    }
}
