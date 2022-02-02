using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_App_Venda_Demo.Modelo
{
    class ProdutoLista
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string nome_voz { get; set; }
        public string gramatura { get; set; }
        public string img { get; set; }
        public string valor_atual { get; set; }
        public string valor_antigo { get; set; }
        public string quantidade { get; set; }
        public string caminho_img_quantidade { get; set; }
        public string caminho_img_menos { get; set; }
    }
}
