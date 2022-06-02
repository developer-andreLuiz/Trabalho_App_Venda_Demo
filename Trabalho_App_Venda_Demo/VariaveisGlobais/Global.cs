using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_App_Venda_Demo.ModeloRetorno;

namespace Trabalho_App_Venda_Demo.VariaveisGlobais
{
    class Global
    {
        public static Global instancia = new Global();

        public List<CategoriasNivel1Retorno> listaCategoriaNivel1 = new List<CategoriasNivel1Retorno>();

        public List<CategoriasNivel2Retorno> listaCategoriaNivel2 = new List<CategoriasNivel2Retorno>();

        public List<CategoriasNivel3Retorno> listaCategoriaNivel3 = new List<CategoriasNivel3Retorno>();

        public List<CategoriasNivel4Retorno> listaCategoriaNivel4 = new List<CategoriasNivel4Retorno>();

        public List<ProdutoRetorno> listaProdutos = new List<ProdutoRetorno>();

        public List<ProdutosCategoriaRetorno> listaProdutosCategoria = new List<ProdutosCategoriaRetorno>();

        public int pronto = 0;

        public int id_Categoria_Nivel1 { get; set; }
        public int id_Categoria_Nivel2 { get; set; }
        public int id_Categoria_Nivel3 { get; set; }
        public int id_Categoria_Nivel4 { get; set; }

    }
}
