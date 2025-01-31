/*
 * -------------------------------------------------------------------------
 * 
 * Autor: Robson Magno <robson.magno2022@gmail.com>
 * Data de Criação: 14/11/2024
 * 
 * Descrição: Programa desenvolvido para verificar fraudes no uso do passcard
 * 
 * -------------------------------------------------------------------------
 */

using VteAppPx.Utils;
using VteAppPx.UserControls;

namespace VteAppPx
{
    public partial class frmPrincipal : Form
    {

        // Variavel global que vai indicar se o usuario escolheu uma pasta
        public static string globalCaminhoPastaTrabalho = "";

        // Objetos que vao instanciar os UsersControls
        private UserControl inicio;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Estado inicial da tela do programa
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
        }

        private void lblMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void likSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void linkInicio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (inicio == null) inicio = new uctInicio();
            Utils.Utils.CarregarFormularioFilho(pnConteudo, inicio);
        }
    }
}
