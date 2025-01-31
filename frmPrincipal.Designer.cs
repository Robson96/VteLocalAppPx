namespace VteAppPx
{
    partial class frmPrincipal
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
            panelTitutlo = new Panel();
            label1 = new Label();
            lblFechar = new Label();
            lblMinimizar = new Label();
            label7 = new Label();
            label6 = new Label();
            pnPrincipal = new Panel();
            pnConteudo = new Panel();
            panelLateral = new Panel();
            likSair = new LinkLabel();
            linkInicio = new LinkLabel();
            panelTitutlo.SuspendLayout();
            pnPrincipal.SuspendLayout();
            panelLateral.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitutlo
            // 
            panelTitutlo.BackColor = Color.Navy;
            panelTitutlo.Controls.Add(label1);
            panelTitutlo.Controls.Add(lblFechar);
            panelTitutlo.Controls.Add(lblMinimizar);
            panelTitutlo.Controls.Add(label7);
            panelTitutlo.Controls.Add(label6);
            panelTitutlo.Dock = DockStyle.Top;
            panelTitutlo.Location = new Point(0, 0);
            panelTitutlo.Name = "panelTitutlo";
            panelTitutlo.Size = new Size(1161, 41);
            panelTitutlo.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(1101, 4);
            label1.Name = "label1";
            label1.Size = new Size(26, 30);
            label1.TabIndex = 3;
            label1.Text = "□";
            label1.Click += lbl_Click;
            // 
            // lblFechar
            // 
            lblFechar.Anchor = AnchorStyles.Right;
            lblFechar.AutoSize = true;
            lblFechar.Cursor = Cursors.Hand;
            lblFechar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechar.ForeColor = Color.Red;
            lblFechar.Location = new Point(1133, 12);
            lblFechar.Name = "lblFechar";
            lblFechar.Size = new Size(19, 20);
            lblFechar.TabIndex = 0;
            lblFechar.Text = "X";
            lblFechar.Click += lblFechar_Click;
            // 
            // lblMinimizar
            // 
            lblMinimizar.Anchor = AnchorStyles.Right;
            lblMinimizar.AutoSize = true;
            lblMinimizar.Cursor = Cursors.Hand;
            lblMinimizar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMinimizar.ForeColor = Color.White;
            lblMinimizar.Location = new Point(1074, 10);
            lblMinimizar.Name = "lblMinimizar";
            lblMinimizar.Size = new Size(21, 20);
            lblMinimizar.TabIndex = 2;
            lblMinimizar.Text = "__";
            lblMinimizar.Click += lblMinimizar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(165, 7);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 1;
            label7.Text = "Usuario:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(591, 7);
            label6.Name = "label6";
            label6.Size = new Size(102, 25);
            label6.TabIndex = 0;
            label6.Text = "VteAppPx";
            // 
            // pnPrincipal
            // 
            pnPrincipal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnPrincipal.Controls.Add(pnConteudo);
            pnPrincipal.Controls.Add(panelLateral);
            pnPrincipal.Controls.Add(panelTitutlo);
            pnPrincipal.Location = new Point(0, 2);
            pnPrincipal.Name = "pnPrincipal";
            pnPrincipal.Size = new Size(1161, 598);
            pnPrincipal.TabIndex = 4;
            // 
            // pnConteudo
            // 
            pnConteudo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnConteudo.AutoScroll = true;
            pnConteudo.BackColor = Color.White;
            pnConteudo.Location = new Point(159, 41);
            pnConteudo.Name = "pnConteudo";
            pnConteudo.Size = new Size(1002, 557);
            pnConteudo.TabIndex = 4;
            // 
            // panelLateral
            // 
            panelLateral.BackColor = Color.CornflowerBlue;
            panelLateral.Controls.Add(likSair);
            panelLateral.Controls.Add(linkInicio);
            panelLateral.Dock = DockStyle.Left;
            panelLateral.Location = new Point(0, 41);
            panelLateral.Name = "panelLateral";
            panelLateral.Size = new Size(159, 557);
            panelLateral.TabIndex = 1;
            // 
            // likSair
            // 
            likSair.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            likSair.AutoSize = true;
            likSair.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            likSair.LinkBehavior = LinkBehavior.NeverUnderline;
            likSair.LinkColor = Color.White;
            likSair.Location = new Point(12, 526);
            likSair.Name = "likSair";
            likSair.Size = new Size(41, 20);
            likSair.TabIndex = 8;
            likSair.TabStop = true;
            likSair.Text = "Sair";
            likSair.LinkClicked += likSair_LinkClicked;
            // 
            // linkInicio
            // 
            linkInicio.AutoSize = true;
            linkInicio.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkInicio.LinkBehavior = LinkBehavior.NeverUnderline;
            linkInicio.LinkColor = Color.White;
            linkInicio.Location = new Point(12, 20);
            linkInicio.Name = "linkInicio";
            linkInicio.Size = new Size(46, 20);
            linkInicio.TabIndex = 7;
            linkInicio.TabStop = true;
            linkInicio.Text = "Inicio";
            linkInicio.LinkClicked += linkInicio_LinkClicked;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1164, 600);
            Controls.Add(pnPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VteFortalezaPx2024";
            FormClosed += frmPrincipal_FormClosed;
            Load += Form1_Load;
            panelTitutlo.ResumeLayout(false);
            panelTitutlo.PerformLayout();
            pnPrincipal.ResumeLayout(false);
            panelLateral.ResumeLayout(false);
            panelLateral.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button btnIniciar;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Panel panelTitutlo;
        private Label label7;
        private Label label6;
        private Panel pnPrincipal;
        private Panel panelLateral;
        private Panel pnConteudo;
        private LinkLabel linkInicio;
        private LinkLabel likSair;
        private Label lblMinimizar;
        private Label lblFechar;
        private Label label1;
    }
}
