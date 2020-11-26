using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SA2_Carlos
{
    public class Ingredientes
    {
        [JsonProperty(PropertyName = "codIngrediente")]
        public int codIngrediente { get; set; }

        [JsonProperty(PropertyName = "nomeIngrediente")]
        public String nomeIngrediente { get; set; }

        [JsonProperty(PropertyName = "qtdIngrediente")]
        public double qtdIngrediente { get; set; }

        [JsonProperty(PropertyName = "unidadeMedida")]
        public String unidadeMedida { get; set; }

        [JsonProperty(PropertyName = "precoIngrediente")]
        public double precoIngrediente { get; set; }

        [JsonProperty(PropertyName = "precoTotal")]
        public double precoTotal { get; set; }

        /* xicara (cha)
         colher (sopa)
        colher (cha)
        colher (café)
        1/2 = 0.5*/
    }
}
