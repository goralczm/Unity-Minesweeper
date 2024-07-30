using UnityEngine;
using System.IO;
using Newtonsoft.Json;

namespace Utilities.SaveSystem
{
    /// <summary>
    /// Handles saving and retrieving custom classes to/from a file.
    /// </summary>
    public static class SaveSystem
    {
        private static readonly string keyword = "Minesweepter";

        public static object LoadData<T>(string fileName, bool encrypt = true)
        {
            string path = Application.persistentDataPath + "/" + fileName + ".json";

            if (File.Exists(path))
            {
                try
                {
                    var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

                    string json = File.ReadAllText(path);
                    if (encrypt)
                        json = EncryptDecrypt(json);
                    T data = JsonConvert.DeserializeObject<T>(json, settings);
                    return data;
                }
                catch
                {
                    return null;
                }
            }
            else
                return null;
        }

        public static void SaveData(object data, string fileName, bool encrypt = true)
        {
            string path = Application.persistentDataPath + "/" + fileName + ".json";

            try
            {
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = JsonConvert.SerializeObject(data, Formatting.Indented, settings);
                if (encrypt)
                    json = EncryptDecrypt(json);
                File.WriteAllText(path, json);
            }
            catch
            {
                
            }
        }

        private static string EncryptDecrypt(string data)
        {
            string result = "";

            for (int i = 0; i < data.Length; i++)
            {
                result += (char)(data[i] ^ keyword[i % keyword.Length]);
            }

            return result;
        }

        public static void DeleteData(string fileName)
        {
            string path = Application.persistentDataPath + "/" + fileName + ".json";

            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
