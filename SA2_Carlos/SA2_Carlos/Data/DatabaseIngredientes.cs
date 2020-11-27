using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SA2_Carlos.Data
{
    public abstract class DatabaseIngredientes
    {
        public static String diretorioIngredientes = $"{Environment.CurrentDirectory}\\ingredientes.json";
        public static List<Ingredientes> getIngredientes()
        {
            StreamReader streamReader = new StreamReader(diretorioIngredientes);
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
            File.WriteAllText(diretorioIngredientes, stringJson);
        }

        public static void putIngredientes(Ingredientes ingrediente)
        {
            List<Ingredientes> list = getIngredientes();
            var atualizaIngrediente = list.Find(item => item.codIngrediente == ingrediente.codIngrediente);
            list.Remove(atualizaIngrediente);
            list.Add(ingrediente);
            var stringJson = JsonConvert.SerializeObject(list);
            File.WriteAllText(diretorioIngredientes, stringJson);
        }
        public static void deleteIngredientes (Ingredientes ingrediente)
        {
            List<Ingredientes> list = getIngredientes();
            var removeItem = list.Find(item => item.codIngrediente == ingrediente.codIngrediente);
            list.Remove(removeItem);
            var stringJson = JsonConvert.SerializeObject(list);
            File.WriteAllText(diretorioIngredientes, stringJson);
        }
    }
}
