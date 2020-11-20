using System;
using System.Collections.Generic;
using System.Text;

namespace SA2_Carlos
{
    class Ingredientes
    {
        public int codIngrediente { get; set; }
        public String nomeIngrediente { get; set; }
        public double qtdIngrediente { get; set; }
        public String unidadeMedida { get; set; }

        public double precoIngrediente { get; set; }

        public double precoTotal { get; set; }

        /* xicara (cha)
         colher (sopa)
        colher (cha)
        colher (café)
        1/2 = 0.5*/
    }
}
