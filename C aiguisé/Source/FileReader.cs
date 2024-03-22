using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;


namespace C_aiguisé
{
    public static class FileReader
    {
        public static Save ReadFile(string filePath)
        {
            using StreamReader streamReader = new(filePath);
            string json = streamReader.ReadToEnd();

            var save = JsonConvert.DeserializeObject<Save>(json);

            return save;
        }

        public static void WriteFile(Save save, string filePath) 
        {
            File.Delete(filePath);
            string json = JsonConvert.SerializeObject(save);
            File.WriteAllText(filePath, json);
        }
    }
}