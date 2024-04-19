using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;



namespace ContactsApp
{
    /// <summary>
    /// Менеджер для работы с файлами.
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// Путь к файлу.
        /// </summary>
        private const string _fileSave = "..\\My Documents\\ContactApp.notes";

        /// <summary>
        /// Сохранить контакт в файл.
        /// </summary>
        public static void SaveToFile(Contact data, string filename)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(_fileSave + filename))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }
        }

        /// <summary>
        /// Загрузить проект из файла.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Contact LoadFromFile(string filename)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(_fileSave + filename))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return (Contact)serializer.Deserialize<Contact>(reader);
            }
        }


    }

}


