using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SA2_Carlos
{
    public class Receitas
    {
        [JsonProperty(PropertyName = "nomeReceita")]
        public String nomeReceita { get; set; }

        [JsonProperty(PropertyName = "tempoPreparacao")]
        public String tempoPreparacao { get; set; }

        [JsonProperty(PropertyName = "dificuldade")]
        public String dificuldade { get; set; }

        [JsonProperty(PropertyName = "porcao")]
        public int porcao { get; set; }

        [JsonProperty(PropertyName = "categoria")]
        public String categoria { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public String descricao { get; set; }

        [JsonProperty(PropertyName = "ingredientes")]
        public List<Ingredientes> ingredientes { get; set; }

        [JsonProperty(PropertyName = "codReceita")]
        public int codReceita { get; set; }

        [JsonProperty(PropertyName = "precoReceita")]
        public double precoReceita { get; set; }
    }
}
