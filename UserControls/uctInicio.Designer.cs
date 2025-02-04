namespace VteAppPx.UserControls
{
    partial class uctInicio
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
            btnImportar = new Button();
            dataGridView1 = new DataGridView();
            webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            btnProximo = new Button();
            lblStatus = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            btnAtivos = new Button();
            btnUsuarios = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView2).BeginInit();
            SuspendLayout();
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(31, 52);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(142, 23);
            btnImportar.TabIndex = 1;
            btnImportar.Text = "IMPORTAR EMPRESAS";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 97);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(483, 600);
            dataGridView1.TabIndex = 2;
            dataGridView1.Visible = false;
            // 
            // webView2
            // 
            webView2.AllowExternalDrop = true;
            webView2.CreationProperties = null;
            webView2.DefaultBackgroundColor = Color.White;
            webView2.Location = new Point(520, 97);
            webView2.Name = "webView2";
            webView2.Size = new Size(670, 600);
            webView2.Source = new Uri("https://www.vtefortaleza.com.br/Login", UriKind.Absolute);
            webView2.TabIndex = 4;
            webView2.Visible = false;
            webView2.ZoomFactor = 1D;
            // 
            // btnProximo
            // 
            btnProximo.Location = new Point(327, 52);
            btnProximo.Name = "btnProximo";
            btnProximo.Size = new Size(75, 23);
            btnProximo.TabIndex = 5;
            btnProximo.Text = "INICIAR";
            btnProximo.UseVisualStyleBackColor = true;
            btnProximo.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(520, 60);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(125, 15);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Total de empresas: 0/0";
            lblStatus.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(682, 60);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 7;
            label3.Text = "Periodo:";
            label3.Visible = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro" });
            comboBox1.Location = new Point(739, 55);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 8;
            comboBox1.Visible = false;
            // 
            // btnAtivos
            // 
            btnAtivos.Location = new Point(866, 54);
            btnAtivos.Name = "btnAtivos";
            btnAtivos.Size = new Size(181, 24);
            btnAtivos.TabIndex = 9;
            btnAtivos.Text = "IMPORTAR USUARIOS ATIVOS";
            btnAtivos.UseVisualStyleBackColor = true;
            btnAtivos.Visible = false;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(179, 52);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(142, 23);
            btnUsuarios.TabIndex = 10;
            btnUsuarios.Text = "IMPORTAR USUARIOS";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Visible = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // uctInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnUsuarios);
            Controls.Add(btnAtivos);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(lblStatus);
            Controls.Add(btnProximo);
            Controls.Add(webView2);
            Controls.Add(dataGridView1);
            Controls.Add(btnImportar);
            Name = "uctInicio";
            Size = new Size(1222, 716);
            Load += uctInicio_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnImportar;
        private DataGridView dataGridView1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private Button btnProximo;
        private Label lblStatus;
        private Label label3;
        private ComboBox comboBox1;
        private Button btnAtivos;
        private Button btnUsuarios;
    }
}
