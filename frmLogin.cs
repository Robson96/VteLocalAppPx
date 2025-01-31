namespace VteAppPx
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // Futuramente sera um login real
        private void button1_Click(object sender, EventArgs e)
        {
            var frmPrincipal = new frmPrincipal();
            this.Visible = false;
            frmPrincipal.Show();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
