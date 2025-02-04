using System.Text.RegularExpressions;
using System.Data;

namespace VteAppPx.Utils
{
    /**
     *   Classe ultilitaria, responsavel por adicionar os UserControls em Panel
     *   e adicionar ou remover mascarar de CNPJs
     */

    static class Utils
    {

        public static void RemoverLinhasVazias(DataTable dt)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dt.Rows[i];

                // Verifica se todos os campos da linha são nulos ou vazios
                if (row.ItemArray.All(field => field == DBNull.Value || string.IsNullOrWhiteSpace(field.ToString())))
                {
                    dt.Rows.Remove(row); // Remove a linha
                }
            }
        }

        public static void CarregarFormularioFilho(Panel panel, UserControl userControl)
        {
            panel.Controls.Clear();
            userControl.Size = panel.ClientSize;
            panel.Controls.Add(userControl);
        }

        public static string RemoverMascara(string valorComMascara)
        {
            string resultado = Regex.Replace(valorComMascara, @"\D", "");
            return resultado;
        }

        public static string AdicionarMascara(string valorSemMascara)
        {
            return Regex.Replace(valorSemMascara, @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1.$2.$3/$4-$5");
        }
    }
}
