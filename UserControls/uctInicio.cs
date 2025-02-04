using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using VteAppPx.scripts;

namespace VteAppPx.UserControls
{
    public partial class uctInicio : UserControl
    {
        private DataTable dtUsuariosSindiOnibus, dtEmpresas, dtCpfs, dtUsuariosAtivosDp, dtOperacoes, dtUsuarios;
        private bool jaIniciou = false;
        private int linhaAtual = 0;
        private string empresaOuSenha, CNPJ;

        public uctInicio()
        {
            InitializeComponent();
        }

        private void HabilitarBotoes(bool visivel)
        {
            btnProximo.Visible = visivel;
            dataGridView1.Visible = visivel;
            webView2.Visible = visivel;
            btnAtivos.Visible = visivel;
            label3.Visible = visivel;
            lblStatus.Visible = visivel;
            comboBox1.Visible = visivel;
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
                    btnUsuarios.Visible = true;
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
                    // Em sites que usa Reactjs

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

        private void AtualizarDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = dtUsuariosSindiOnibus;
        }

        private async void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            string message = e.TryGetWebMessageAsString();
            Debug.WriteLine(message);

            var parts = message.Split("###");

            switch (parts[0])
            {
                case "Fim":
                    await JuntarTabelas();
                    AtualizarDataGrid();
                    break;
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

        /**
         * Metodo utilizado para juntar as datatables
         */

        private async Task JuntarTabelas()
        {
            foreach (DataRow row2 in dtUsuariosSindiOnibus.Rows)
            {
                string nome2 = row2["Usuário"].ToString();
                foreach (DataRow row1 in dtCpfs.Rows)
                {
                    string nome1 = row1["Nome"].ToString();
                    if (nome1.Equals(nome2, StringComparison.OrdinalIgnoreCase))
                    {
                        row2["CPF"] = row1["CPF"];
                        break;
                    }
                }
            }
        }

        private async void btnUsuarios_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog arquivo = new OpenFileDialog())
            {
                arquivo.Filter = "Planilhas Excel (*.PDF)|*.pdf";
                arquivo.Title = "Selecione um arquivo";

                if (arquivo.ShowDialog() == DialogResult.OK)
                {
                    dtUsuarios = await ExtrairTabelaDoPdf(arquivo.FileName);
                    ImprimirDataTable(dtUsuarios);
                    HabilitarBotoes(true);
                    dataGridView1.DataSource = dtUsuarios;
                    MessageBox.Show("Arquivo importado com sucesso!");
                }
            }
        }

        private async Task ConverterDataTableParaJson()
        {
            var rows = new List<Dictionary<string, object>>();

            for (int i = linhaAtual; i < dtUsuariosSindiOnibus.Rows.Count; i++)
            {
                var row = dtUsuariosSindiOnibus.Rows[i];
                var rowDict = new Dictionary<string, object>();
                foreach (DataColumn column in dtUsuariosSindiOnibus.Columns)
                {
                    rowDict[column.ColumnName] = row[column];
                }
                rows.Add(rowDict);
            }

            string jsonRows = JsonConvert.SerializeObject(rows);
            webView2.CoreWebView2.PostWebMessageAsString(jsonRows);
        }

        private async Task<DataTable> ExtrairTabelaDoPdf(string caminhoPdf)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Matrícula");
            dt.Columns.Add("Usuário");
            dt.Columns.Add("CPF");
            dt.Columns.Add("Status");
            dt.Columns.Add("Categoria");
            dt.Columns.Add("Valor");
            dt.Columns.Add("Mês");
            dt.Columns.Add("Ano");
            dt.Columns.Add("Hora");

            StringBuilder texto = new StringBuilder();
            using (PdfReader reader = new PdfReader(caminhoPdf))
            {
                using (PdfDocument pdfDoc = new PdfDocument(reader))
                {
                    int totalPages = pdfDoc.GetNumberOfPages();

                    for (int i = 1; i <= totalPages; i++)
                    {
                        texto.Append(PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i)));
                    }
                }
            }

            // Processar o texto para separar as linhas e colunas da tabela
            string[] linhas = texto.ToString().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            var linhas2 = CorrigirLinhas(linhas.ToList());

            foreach (var linha in linhas2)
            {

                Debug.WriteLine("Texto da linha: " + linha);  // Exibir o conteúdo da linha para verificar o formato.
                DataRow row = dt.NewRow();

                // Capturar o Usuário (Nome Completo)
                var matchUsuario = Regex.Match(linha, @"^\d{7}\s+\d{8}\s+([a-zA-Záàãâäéèêëíìîïóòôöúùûüç\s]+)");
                if (matchUsuario.Success)
                {
                    row["Usuário"] = matchUsuario.Groups[1].Value.ToUpper();
                }

                // Capturar o Status
                var matchStatus = Regex.Match(linha, @"providenciado\s+(urbano)");
                if (matchStatus.Success)
                {
                    row["Status"] = matchStatus.Groups[1].Value;
                }

                // Capturar a Matrícula
                var matchMatricula = Regex.Match(linha, @"^\d{7}\s+(\d{8})");
                if (matchMatricula.Success)
                {
                    row["Matrícula"] = matchMatricula.Groups[1].Value;
                }

                // Capturar o Registro (Data)
                //var matchRegistro = Regex.Match(linha, @"\d{7}\s+\d{8}\s+[a-zA-Záàãâäéèêëíìîïóòôöúùûüç\s]+\s+(\d{2}/\d{2}/\d{4})");
                //if (matchRegistro.Success)
                //{
                //    row["Registro"] = matchRegistro.Groups[1].Value;
                //}

                // Capturar a Categoria
                var matchCategoria = Regex.Match(linha, @"urbano\s+(saldo de [a-zA-Z\s]+|bloqueio)");
                if (matchCategoria.Success)
                {
                    row["Categoria"] = matchCategoria.Groups[1].Value;
                }

                // Capturar o Valor
                var matchValor = Regex.Match(linha, @"(\d+,\d+)");
                if (matchValor.Success)
                {
                    string valorString = matchValor.Groups[1].Value;
                    row["Valor"] = decimal.TryParse(valorString, out decimal valor) ? valor : 0;
                }

                // Capturar a Data e Hora da Última Utilização
                var matchDataHora = Regex.Match(linha, @"(\d{2}/\d{2}/\d{4}\s\d{2}:\d{2}:\d{2})");
                if (matchDataHora.Success)
                {
                    var dataHora = matchDataHora.Groups[1].Value;
                    DateTime ultimaUtilizacao = DateTime.TryParse(dataHora, out DateTime dtUtilizacao) ? dtUtilizacao : DateTime.MinValue;

                    row["Mês"] = ultimaUtilizacao.Month.ToString("00");
                    row["Ano"] = ultimaUtilizacao.Year.ToString();
                    row["Hora"] = ultimaUtilizacao.ToString("HH:mm:ss");
                }

                // Adicionar a linha ao DataTable
                dt.Rows.Add(row);

            }

            Utils.Utils.RemoverLinhasVazias(dt);

            return dt;
        }

        public List<string> CorrigirLinhas(List<string> linhas)
        {
            List<string> linhasCorrigidas = new List<string>();
            string linhaAnterior = "";

            for (int i = 0; i < linhas.Count - 1; i++)
            {
                // Até a quinta linha, não faz a verificação de união
                if (i > 5)
                {
                    linhasCorrigidas.Add(linhas[i] + linhas[i + 1]);
                }
            }

            return linhasCorrigidas;
        }
    }
}