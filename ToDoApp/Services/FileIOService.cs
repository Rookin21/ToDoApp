using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class FileIOService
    {
        private readonly string _Path;

        public FileIOService(string path)
        {
            _Path = path;
        }

        public BindingList<ToDoModel> LoadData()
        {
            var FileExists = File.Exists(_Path); // Проверка существует ли файл
            if (!FileExists) // Создание файла
            {
                File.CreateText(_Path).Dispose(); // После создания - освобождение ресурса
                return new BindingList<ToDoModel>();
            }
            
            using (var reader = File.OpenText(_Path)) // Чтения файла
            {
                var FileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(FileText); // Десериализование
            }
        }

        public void SaveData(object ToDoList)
        {
            using (StreamWriter writer = File.CreateText(_Path))
            {
                string output = JsonConvert.SerializeObject(ToDoList);
                writer.Write(output);
            }
        }
    }
}
