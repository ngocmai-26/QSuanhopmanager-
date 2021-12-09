
namespace QShopManagement.DTO.UC
{
    partial class loadding
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pgrLoading = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.SuspendLayout();
            // 
            // pgrLoading
            // 
            this.pgrLoading.Animated = true;
            this.pgrLoading.AnimationSpeed = 3F;
            this.pgrLoading.BackColor = System.Drawing.Color.Transparent;
            this.pgrLoading.FillColor = System.Drawing.Color.Transparent;
            this.pgrLoading.FillThickness = 10;
            this.pgrLoading.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pgrLoading.ForeColor = System.Drawing.Color.White;
            this.pgrLoading.InnerColor = System.Drawing.Color.Transparent;
            this.pgrLoading.Location = new System.Drawing.Point(60, 61);
            this.pgrLoading.Minimum = 0;
            this.pgrLoading.Name = "pgrLoading";
            this.pgrLoading.ProgressColor = System.Drawing.Color.Black;
            this.pgrLoading.ProgressColor2 = System.Drawing.Color.Black;
            this.pgrLoading.ProgressThickness = 6;
            this.pgrLoading.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pgrLoading.ShadowDecoration.Parent = this.pgrLoading;
            this.pgrLoading.Size = new System.Drawing.Size(35, 35);
            this.pgrLoading.TabIndex = 0;
            this.pgrLoading.Text = "guna2CircleProgressBar1";
            this.pgrLoading.Value = 40;
            // 
            // loadding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pgrLoading);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Name = "loadding";
            this.Size = new System.Drawing.Size(160, 162);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleProgressBar pgrLoading;
    }
}
