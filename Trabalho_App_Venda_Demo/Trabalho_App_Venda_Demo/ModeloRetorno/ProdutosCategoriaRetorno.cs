using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_App_Venda_Demo.ModeloRetorno
{
    class ProdutosCategoriaRetorno
    {
        /// <summary>
        /// autonumerico chave primaria da tabela
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// referencia ao codigo do produto
        /// </summary>
        public int CodigoProduto { get; set; }
        /// <summary>
        /// referecia a categoria nivel 1
        /// </summary>
        public int CategoriaNivel1 { get; set; }
        /// <summary>
        /// referecia a categoria nivel 2
        /// </summary>
        public int CategoriaNivel2 { get; set; }
        /// <summary>
        /// referecia a categoria nivel 3
        /// </summary>
        public int CategoriaNivel3 { get; set; }
        /// <summary>
        /// referecia a categoria nivel 4
        /// </summary>
        public int CategoriaNivel4 { get; set; }
        public int Ordem { get; set; }

    }
}
