
namespace QLCH
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
            this.label1 = new System.Windows.Forms.Label();
            this.QLTTNV = new System.Windows.Forms.Button();
            this.QLTTNCC = new System.Windows.Forms.Button();
            this.QLDMHH = new System.Windows.Forms.Button();
            this.Thongke = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(572, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý cửa hàng";
            // 
            // QLTTNV
            // 
            this.QLTTNV.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.QLTTNV.Location = new System.Drawing.Point(239, 336);
            this.QLTTNV.Name = "QLTTNV";
            this.QLTTNV.Size = new System.Drawing.Size(340, 63);
            this.QLTTNV.TabIndex = 2;
            this.QLTTNV.Text = "Quản lý thông tin nhân viên";
            this.QLTTNV.UseVisualStyleBackColor = true;
            // 
            // QLTTNCC
            // 
            this.QLTTNCC.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.QLTTNCC.Location = new System.Drawing.Point(239, 211);
            this.QLTTNCC.Name = "QLTTNCC";
            this.QLTTNCC.Size = new System.Drawing.Size(340, 62);
            this.QLTTNCC.TabIndex = 3;
            this.QLTTNCC.Text = "Quản lý thông tin nhà cung cấp";
            this.QLTTNCC.UseVisualStyleBackColor = true;
            // 
            // QLDMHH
            // 
            this.QLDMHH.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.QLDMHH.Location = new System.Drawing.Point(859, 211);
            this.QLDMHH.Name = "QLDMHH";
            this.QLDMHH.Size = new System.Drawing.Size(340, 62);
            this.QLDMHH.TabIndex = 4;
            this.QLDMHH.Text = "Quản lý danh mục hàng hóa";
            this.QLDMHH.UseVisualStyleBackColor = true;
            // 
            // Thongke
            // 
            this.Thongke.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Thongke.Location = new System.Drawing.Point(859, 336);
            this.Thongke.Name = "Thongke";
            this.Thongke.Size = new System.Drawing.Size(340, 63);
            this.Thongke.TabIndex = 5;
            this.Thongke.Text = "Bảng thống kê số lượng mua và bán";
            this.Thongke.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 504);
            this.Controls.Add(this.Thongke);
            this.Controls.Add(this.QLDMHH);
            this.Controls.Add(this.QLTTNCC);
            this.Controls.Add(this.QLTTNV);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button QLTTNV;
        private System.Windows.Forms.Button QLTTNCC;
        private System.Windows.Forms.Button QLDMHH;
        private System.Windows.Forms.Button Thongke;
    }
}

