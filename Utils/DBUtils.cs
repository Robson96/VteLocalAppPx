namespace VteAppPx.Utils
{
    /**
     * Classe utilitaria que simula um banco de dodos
     */

    class DBUtils
    {
        private static string db = "vtedb.txt";

        public static async Task AdicionarEmpresa(Empresa empresa)
        {
            using (StreamWriter sw = new StreamWriter(db, true))
            {
                sw.WriteLine(empresa.ToString());
            }
        }

        public static async Task<List<Empresa>> ListarEmpresas()
        {
            var empresas = new List<Empresa>();

            if (File.Exists(db))
            {
                using (StreamReader sr = new StreamReader(db))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        empresas.Add(Empresa.FromString(linha));
                    }
                }
            }
            return empresas;
        }
    }

    class Empresa
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Senha { get; set; }

        public Empresa(string id, string nome, string cnpj, string senha)
        {
            Id = id;
            Nome = nome;
            CNPJ = cnpj;
            Senha = senha;
        }

        public override string ToString()
        {
            return $"{Id},{Nome},{CNPJ},{Senha}";
        }

        public static Empresa FromString(string data)
        {
            var parts = data.Split(',');
            return new Empresa(parts[0], parts[1], parts[2], parts[3]);
        }
    }
}
