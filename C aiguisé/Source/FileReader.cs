using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace C_aiguisé
{
    public static class FileReader
    {
        public static Save ReadFile(string filePath)
        {
            using StreamReader streamReader = new(filePath);
            var json = streamReader.ReadToEnd();
            var save = JsonSerializer.Deserialize<Save>(json);

            return save;
        }

        public static void WriteFile(Save save, string filePath) 
        {
            string json = JsonSerializer.Serialize(save);
            File.WriteAllText(filePath, json);
        }
    }
}