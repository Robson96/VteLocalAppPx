using System.Text.RegularExpressions;

namespace VteAppPx.Utils
{
    /**
     *   Classe ultilitaria, responsavel por adicionar os UserControls em Panel
     *   e adicionar ou remover mascarar de CNPJs
     */

    static class Utils
    {
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
