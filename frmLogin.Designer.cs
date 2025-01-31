namespace VteAppPx
{
    partial class frmLogin
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            btLogin = new Button();
            btCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 17);
            label1.Name = "label1";
            label1.Size = new Size(146, 37);
            label1.TabIndex = 0;
            label1.Text = "VteAppPx";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(119, 74);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 76);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 2;
            label2.Text = "Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 117);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 3;
            label3.Text = "Senha:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(119, 110);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            // 
            // btLogin
            // 
            btLogin.BackColor = Color.CornflowerBlue;
            btLogin.FlatAppearance.BorderSize = 0;
            btLogin.FlatStyle = FlatStyle.Flat;
            btLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btLogin.ForeColor = Color.White;
            btLogin.Location = new Point(62, 148);
            btLogin.Name = "btLogin";
            btLogin.Size = new Size(157, 32);
            btLogin.TabIndex = 5;
            btLogin.Text = "Entrar";
            btLogin.UseVisualStyleBackColor = false;
            btLogin.Click += button1_Click;
            // 
            // btCancelar
            // 
            btCancelar.BackColor = Color.Firebrick;
            btCancelar.FlatAppearance.BorderSize = 0;
            btCancelar.FlatStyle = FlatStyle.Flat;
            btCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btCancelar.ForeColor = Color.White;
            btCancelar.Location = new Point(62, 194);
            btCancelar.Name = "btCancelar";
            btCancelar.Size = new Size(157, 33);
            btCancelar.TabIndex = 6;
            btCancelar.Text = "Cancelar";
            btCancelar.UseVisualStyleBackColor = false;
            btCancelar.Click += btCancelar_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 262);
            Controls.Add(btCancelar);
            Controls.Add(btLogin);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Button btLogin;
        private Button btCancelar;
    }
}