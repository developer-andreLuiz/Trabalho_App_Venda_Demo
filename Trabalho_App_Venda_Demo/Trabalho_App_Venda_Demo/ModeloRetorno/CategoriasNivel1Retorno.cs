using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_App_Venda_Demo.ModeloRetorno
{
    class CategoriasNivel1Retorno
    {
        /// <summary>
        /// chave primaria da categoria nivel 1
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nome da categoria nivel 1
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// url da imagem
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// ordem de exibição
        /// </summary>
        public int Ordem { get; set; }
    }
}
