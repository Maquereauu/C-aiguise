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
        public static Save ReadJsonFile(string filePath)
        {
            using StreamReader streamReader = new(filePath);
            string json = streamReader.ReadToEnd();

             var save = JsonConvert.DeserializeObject<Save>(json);

            return save;
        }

        public static void WriteJsonFile(Save save, string filePath) 
        {
            File.Delete(filePath);
            string json = JsonConvert.SerializeObject(save);
            File.WriteAllText(filePath, json);
        }

        public static (int, int) GetSizeFromFile(string filePath)
        {
            string[] file = File.ReadAllText(filePath).Split("\r\n");

            int sizeY = file.Length;
            int sizeX = 0;

            foreach (string line in file)
            {
                if (line.Length > sizeX)
                {
                    sizeX = line.Length;
                }
            }

            return (sizeX, sizeY);
        }
    }
}