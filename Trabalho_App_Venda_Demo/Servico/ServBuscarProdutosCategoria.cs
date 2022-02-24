using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Trabalho_App_Venda_Demo.ModeloRetorno;
using Trabalho_App_Venda_Demo.VariaveisGlobais;

namespace Trabalho_App_Venda_Demo.Servico
{
    class ServBuscarProdutosCategoria
    {
        private static string EnderecoUrl = "https://api-mercado-online.azurewebsites.net/api/produto-categoria";
        public static void BuscarProdutosCategoriaResultado()
        {
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(EnderecoUrl);

            Global.instancia.listaProdutosCategoria = JsonConvert.DeserializeObject<List<ProdutosCategoriaRetorno>>(conteudo);
        }
    }
}
