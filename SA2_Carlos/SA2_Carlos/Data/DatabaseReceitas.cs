using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SA2_Carlos
{
    public abstract class DatabaseReceitas
    {
        public static String diretorioReceitas = $"{Directory.GetCurrentDirectory()}\\receitas.json";
        public static List<Receitas> getReceitas()
        {
            StreamReader streamReader = new StreamReader(diretorioReceitas);
            var json = streamReader.ReadToEnd();
            var list = JsonConvert.DeserializeObject<List<Receitas>>(json);
            streamReader.Close();
            return list;
        }
       public static void postReceitas(Receitas receita)
        {
            List<Receitas> list = getReceitas();
            list.Add(receita);
            var stringJson = JsonConvert.SerializeObject(list);
            File.WriteAllText(diretorioReceitas, stringJson);
        }
    }
}
