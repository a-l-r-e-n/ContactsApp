using Newtonsoft.Json;
using System;
using System.IO;

namespace ContactsApp
{
    /// <summary>
    /// Описывает менеджер проекта
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// Имя файла.
        /// </summary>
        private static string _fileName = @"\ContactsApp.txt";

        /// <summary>
        /// Путь к AppData.
        /// </summary>
        private static string _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// Путь к папке сохранения.
        /// </summary>
        private static string _path = $@"{_appData}\ContactsApp";

        /// <summary>
        /// Возвращает путь к папке сохранения.
        /// </summary>
        public string Path
        {
            get
            {
                return _path;
            }
        }

        /// <summary>
        /// Возвращает имя файла.
        /// </summary>
        public string FileName
        {
            get
            {
                return _fileName;
            }
        }

        /// <summary>
        /// Сохраняет данные в файл.
        /// </summary>
        /// <param name="project"></param>
        public void SaveProject(Project project)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            string json = JsonConvert.SerializeObject(project, Formatting.Indented);
            File.WriteAllText(Path + FileName, json);
        }

        /// <summary>
        /// Загружает данные из файла.
        /// </summary>
        /// <returns></returns>
        public Project LoadProject()
        {
            try
            {
                Project project;
                string json = File.ReadAllText(Path + FileName);
                project = JsonConvert.DeserializeObject<Project>(json);
                if (project == null)
                {
                    return new Project();
                }
                return project;
            }
            catch (Exception)
            {
                return new Project();
            }
        }
    }
}
