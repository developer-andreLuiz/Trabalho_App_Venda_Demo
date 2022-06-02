using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Trabalho_App_Venda_Demo.ModeloRetorno;
using Trabalho_App_Venda_Demo.VariaveisGlobais;

namespace Trabalho_App_Venda_Demo.Servico
{
    class ServBuscarCategoriaNivel3
    {
        private static string EnderecoUrl = "https://api-mercado-online.azurewebsites.net/api/categoria-nivel-3";
        public static void BuscarCategoriaNivel3Resultado()
        {
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(EnderecoUrl);

            Global.instancia.listaCategoriaNivel3 = JsonConvert.DeserializeObject<List<CategoriasNivel3Retorno>>(conteudo);
            Global.instancia.pronto++;
        }
    }
}
