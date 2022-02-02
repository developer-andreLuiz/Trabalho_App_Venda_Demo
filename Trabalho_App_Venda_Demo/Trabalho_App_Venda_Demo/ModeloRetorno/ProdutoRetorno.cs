using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_App_Venda_Demo.ModeloRetorno
{
    class ProdutoRetorno
    {
        /// <summary>
        /// autonumerico chave primaria da tabela
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nome do produto
        /// 
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// leitura da descrição
        /// 
        /// </summary>
        public string Pronuncia { get; set; }
        /// <summary>
        /// url -jpg
        /// 
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// numero de codigo interno da loja\n
        /// </summary>
        public string CodigoLoja { get; set; }
        /// <summary>
        /// valor de custo do produto\\n
        /// </summary>
        public double CustoUnitario { get; set; }
        /// <summary>
        /// valor de venda do produto\\n
        /// </summary>
        public double ValorVenda { get; set; }
        /// <summary>
        /// valor de promoção do produto\\n
        /// </summary>
        public double ValorPromocao { get; set; }
        /// <summary>
        /// 1,5L  - 50ml (sem espaço e maiusculo) kg - gr - lt - ml - und
        /// 
        /// </summary>
        public string Gramatura { get; set; }
        /// <summary>
        /// PCT - UND - CX - PESO
        /// 
        /// </summary>
        public string Embalagem { get; set; }
        /// <summary>
        /// 01526 (01,526kg)
        /// 
        /// </summary>
        public string Peso { get; set; }
        /// <summary>
        /// 0 - 1 - 2 -3 
        /// serve para realizar alteração em produtos iguais
        /// </summary>
        public int IgualaProduto { get; set; }
        /// <summary>
        /// quantidade de produto  na caixa
        /// 
        /// </summary>
        public int ItensCaixa { get; set; }
        /// <summary>
        /// 30 - caixa volume =100 (cabe 3 na caixa)volume do produto
        /// 
        /// </summary>
        public int Volume { get; set; }
        /// <summary>
        /// se o produto é perecivel ou nao
        /// 
        /// </summary>
        public bool Validade { get; set; }
        /// <summary>
        /// informação nutricional do produto
        /// 
        /// </summary>
        public string Informacao { get; set; }
    }
}
