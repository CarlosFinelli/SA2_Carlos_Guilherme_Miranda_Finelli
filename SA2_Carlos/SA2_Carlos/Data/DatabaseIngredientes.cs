using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SA2_Carlos.Data
{
    public abstract class DatabaseIngredientes
    {
        public static String diretorioReceitas = $"{Directory.GetCurrentDirectory()}\\ingredientes.json";
        public static List<Ingredientes> getIngredientes()
        {
            StreamReader streamReader = new StreamReader(diretorioReceitas);
            var json = streamReader.ReadToEnd();
            var list = JsonConvert.DeserializeObject<List<Ingredientes>>(json);
            streamReader.Close();
            return list;
        }
        public static void postIngredientes(Ingredientes ingrediente)
        {
            List<Ingredientes> list = getIngredientes();
            list.Add(ingrediente);
            var stringJson = JsonConvert.SerializeObject(list);
            File.WriteAllText(diretorioReceitas, stringJson);
        }
    }
}
