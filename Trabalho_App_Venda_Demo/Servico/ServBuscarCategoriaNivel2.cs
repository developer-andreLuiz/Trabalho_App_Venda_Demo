using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Trabalho_App_Venda_Demo.ModeloRetorno;
using Trabalho_App_Venda_Demo.VariaveisGlobais;

namespace Trabalho_App_Venda_Demo.Servico
{
    class ServBuscarCategoriaNivel2
    {
        private static string EnderecoUrl = "https://api-mercado-online.azurewebsites.net/api/categoria-nivel-2";
        public static void BuscarCategoriaNivel2Resultado()
        {
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(EnderecoUrl);

            Global.instancia.listaCategoriaNivel2 = JsonConvert.DeserializeObject<List<CategoriasNivel2Retorno>>(conteudo);
            Global.instancia.pronto++;
        }
    }
}
