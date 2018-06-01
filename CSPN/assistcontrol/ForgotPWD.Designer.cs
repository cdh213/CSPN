namespace CSPN.assistcontrol
{
    partial class ForgotPWD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPWD));
            this.btnSure = new System.Windows.Forms.Button();
            this.tbPWD = new CSPN.assistcontrol.WaterTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRePWD = new CSPN.assistcontrol.WaterTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbWork_ID = new CSPN.assistcontrol.WaterTextBox();
            this.SuspendLayout();
            // 
            // btnSure
            // 
            this.btnSure.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSure.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSure.BackgroundImage")));
            this.btnSure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSure.FlatAppearance.BorderSize = 0;
            this.btnSure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSure.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSure.ForeColor = System.Drawing.Color.White;
            this.btnSure.Location = new System.Drawing.Point(136, 213);
            this.btnSure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(86, 26);
            this.btnSure.TabIndex = 1;
            this.btnSure.Text = "修改";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // tbPWD
            // 
            this.tbPWD.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPWD.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbPWD.Location = new System.Drawing.Point(136, 94);
            this.tbPWD.Name = "tbPWD";
            this.tbPWD.PasswordChar = '*';
            this.tbPWD.Size = new System.Drawing.Size(164, 26);
            this.tbPWD.TabIndex = 3;
            this.tbPWD.UseSystemPasswordChar = true;
            this.tbPWD.WaterText = "请输入密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(65, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(65, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "工号";
            // 
            // tbRePWD
            // 
            this.tbRePWD.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRePWD.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbRePWD.Location = new System.Drawing.Point(136, 149);
            this.tbRePWD.Name = "tbRePWD";
            this.tbRePWD.PasswordChar = '*';
            this.tbRePWD.Size = new System.Drawing.Size(164, 26);
            this.tbRePWD.TabIndex = 4;
            this.tbRePWD.UseSystemPasswordChar = true;
            this.tbRePWD.WaterText = "请再次输入密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(53, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "重复密码";
            // 
            // tbWork_ID
            // 
            this.tbWork_ID.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbWork_ID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbWork_ID.Location = new System.Drawing.Point(136, 37);
            this.tbWork_ID.Name = "tbWork_ID";
            this.tbWork_ID.Size = new System.Drawing.Size(164, 26);
            this.tbWork_ID.TabIndex = 2;
            this.tbWork_ID.WaterText = "请输入工号";
            // 
            // ForgotPWD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(365, 261);
            this.Controls.Add(this.tbWork_ID);
            this.Controls.Add(this.tbRePWD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.tbPWD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ForgotPWD";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSure;
        private WaterTextBox tbPWD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private WaterTextBox tbRePWD;
        private System.Windows.Forms.Label label3;
        private WaterTextBox tbWork_ID;
    }
}