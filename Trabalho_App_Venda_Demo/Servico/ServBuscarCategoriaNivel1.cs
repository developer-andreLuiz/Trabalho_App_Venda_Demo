using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Trabalho_App_Venda_Demo.ModeloRetorno;
using Trabalho_App_Venda_Demo.VariaveisGlobais;

namespace Trabalho_App_Venda_Demo.Servico
{
    class ServBuscarCategoriaNivel1
    {
        private static string EnderecoUrl = "https://api-mercado-online.azurewebsites.net/api/categoria-nivel-1";
        public static void BuscarCategoriaNivel1Resultado()
        {
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(EnderecoUrl);

            Global.instancia.listaCategoriaNivel1 = JsonConvert.DeserializeObject<List<CategoriasNivel1Retorno>>(conteudo);
            Global.instancia.pronto++;
        }
    }
}
