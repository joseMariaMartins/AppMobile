using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastro
{
    internal class Produtos
    {
        public class Produto
        {
            public string nomeProd { get; set; }
            public string descProd { get; set; }
            public string categoriaProd { get; set; }
            public decimal precoProd { get; set; }
        }
    }
}
