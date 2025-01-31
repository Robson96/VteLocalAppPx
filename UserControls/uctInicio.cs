using ClosedXML.Excel;
using Microsoft.Web.WebView2.Core;
using System.Data;
using System.Diagnostics;

using VteAppPx.scripts;

namespace VteAppPx.UserControls
{
    public partial class uctInicio : UserControl
    {
        private DataTable dtUsuariosSindiOnibus, dtEmpresas, dtCpfs, dtUsuariosAtivosDp, dtOperacoes;
        private bool jaIniciou = false;
        private int linhaAtual = 0;
        private string empresaOuSenha, CNPJ;

        public uctInicio()
        {
            InitializeComponent();
        }

        private async void btnImportar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog arquivo = new OpenFileDialog())
            {
                arquivo.Filter = "Planilhas Excel (*.xlsx)|*.xlsx";
                arquivo.Title = "Selecione um arquivo";

                if (arquivo.ShowDialog() == DialogResult.OK)
                {
                    dtEmpresas = await ImportarExcelEmpresas(arquivo.FileName);
                    //HabilitarBotoes(true);
                    MessageBox.Show("Arquivo importado com sucesso!");
                }
            }
        }

        private async Task<DataTable> ImportarExcelEmpresas(string arquivo)
        {
            var dt = new DataTable();
            dt.Columns.Add("CNPJ", typeof(string));
            dt.Columns.Add("Senha", typeof(string));

            try
            {
                using var workbook = new XLWorkbook(arquivo);
                var worksheet = workbook.Worksheet(1);
                int ultimaLinha = worksheet.LastRowUsed().RowNumber();

                for (int i = 2; i <= ultimaLinha; i++)
                {
                    var novaLinha = dt.NewRow();
                    novaLinha["CNPJ"] = worksheet.Cell(i, 1).GetString().Trim();
                    novaLinha["Senha"] = worksheet.Cell(i, 2).GetString().Trim();
                    Debug.WriteLine("CNPJ" + novaLinha["CNPJ"].ToString());
                    Debug.WriteLine("Senha" + novaLinha["Senha"].ToString());
                    dt.Rows.Add(novaLinha);
                }

                return dt;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Erro ao ler o arquivo!");
                MessageBox.Show("Feche o arquivo!");
                return null;
            }
        }

        private IEnumerator<DataRow> empresas;

        // Variaves para indicar o progresso do trabalho
        int quantidadeEmpresas = 0;
        int empresaAtual = 0;

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (!jaIniciou)
            {
                jaIniciou = true;
                btnProximo.Text = "Proximo Empresa";
                empresas = (IEnumerator<DataRow>)dtEmpresas.Rows.GetEnumerator();
                quantidadeEmpresas = dtEmpresas.Rows.Count;
            }

            // Cada empresa é processada de cada vez ao clique do botão
            if (empresas.MoveNext())
            {
                empresaAtual++;
                string login = empresas.Current["CNPJ"].ToString();
                string senha = empresas.Current["Senha"].ToString();
                InserirInformcoesLogin(Utils.Utils.RemoverMascara(login), senha);
                lblStatus.Text = $"Total de empresas: {empresaAtual}/{quantidadeEmpresas}";
                Debug.WriteLine("Login " + login);
                Debug.WriteLine("Senha " + senha);
            }
        }

        private async void InserirInformcoesLogin(string login, string senha)
        {
            string scriptLogin = $@"
                (async function() {{
                    function getElement(xpath) {{
                        return document.evaluate(xpath, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
                    }}

                    function delay(time) {{
                        return new Promise(resolve => setTimeout(resolve, time));
                    }}
                    
                    // E recomendado realizar a escrita em campos de login
                    // que usa Reactjs

                    var input = Object.getOwnPropertyDescriptor(window.HTMLInputElement.prototype, 'value').set;
                    
                    var login = getElement('/html/body/div[1]/div/div[1]/div/form/div[3]/input');
                    var senha = getElement('/html/body/div[1]/div/div[1]/div/form/div[4]/div/input');

                    input.call(login, '{login}');
                    login.dispatchEvent(new Event('input', {{bubbles: true }}));
                    login.dispatchEvent(new Event('change', {{bubbles: true }}));
                    
                    await delay(1000);
                    
                    input.call(senha, '{senha}');
                    senha.dispatchEvent(new Event('input', {{bubbles: true }}));
                    senha.dispatchEvent(new Event('change', {{bubbles: true }}));
                    
                    await delay(1000);
                    
                    getElement('/html/body/div[1]/div/div[1]/div/form/button').click();
                }})();
            ";

            await webView2.ExecuteScriptAsync(scriptLogin);
        }

        private async void uctInicio_Load(object sender, EventArgs e)
        {
            await webView2.EnsureCoreWebView2Async();
            webView2.CoreWebView2.Settings.IsScriptEnabled = true;
            webView2.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            webView2.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

            dtUsuariosSindiOnibus = new DataTable();
            dtUsuariosSindiOnibus.Columns.Add("Empresa", typeof(string));
            dtUsuariosSindiOnibus.Columns.Add("CNPJ", typeof(string));
            dtUsuariosSindiOnibus.Columns.Add("CPF", typeof(string));
            dtUsuariosSindiOnibus.Columns.Add("Usuário", typeof(string));
            dtUsuariosSindiOnibus.Columns.Add("Status", typeof(string));
            dtUsuariosSindiOnibus.Columns.Add("Tipo", typeof(string));
            dtUsuariosSindiOnibus.Columns.Add("Ultima Data", typeof(string));
            dtUsuariosSindiOnibus.Columns.Add("Ultima Hora", typeof(string));
            dtUsuariosSindiOnibus.Columns.Add("Ultima Mes", typeof(string));
            dtUsuariosSindiOnibus.Columns.Add("Ultima Ano", typeof(string));
            dtUsuariosSindiOnibus.Columns.Add("Valor", typeof(decimal));
            dtUsuariosSindiOnibus.Columns.Add("Código", typeof(string));

            dtCpfs = new DataTable();
            dtCpfs.Columns.Add("CPF");
            dtCpfs.Columns.Add("Nome");
        }

        private async void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            string message = e.TryGetWebMessageAsString();
            Debug.WriteLine(message);

            var parts = message.Split("###");

            switch (parts[0])
            {
                case "cpf":
                    dtCpfs.Rows.Add(parts[1], parts[2]);
                    break;
                case "login":
                    CNPJ = Utils.Utils.RemoverMascara(parts[1]);
                    empresaOuSenha = parts[2];
                    await Task.Delay(8000);
                    await webView2.ExecuteScriptAsync(ScriptsJS.scriptIrPaginaCartoesEObterTabelaECpfs);
                    break;
            }
        }

        private async void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                await webView2.ExecuteScriptAsync(ScriptsJS.scriptCapturarLogin);
                Debug.WriteLine("Página carregada com sucesso!");
            }
            else
            {
                Debug.WriteLine($"Erro ao carregar a página: {e.WebErrorStatus}");
            }
        }

        private void ImprimirDataTable(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("O DataTable está vazio.");
                return;
            }

            foreach (DataColumn column in dt.Columns)
            {
                Debug.Write(column.ColumnName + "\t");
            }
            Debug.WriteLine("");

            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Debug.Write(item.ToString() + "\t");
                }
                Debug.WriteLine("");
            }
        }
    }
}
