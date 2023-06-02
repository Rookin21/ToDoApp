using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ToDoApp.Models
{   
    /// <summary>
    /// Запись задач
    /// </summary>
    public class ToDoModel : INotifyPropertyChanged
    {
        private bool _IsDone;
        private string? _Text;

        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "isDone")]
        public bool IsDone 
        { 
            get { return _IsDone;} 
            set                                 // Проверка на наличие изменений
            {   if (_IsDone == value) return;                
                _IsDone = value; 
                OnPropertyChanged("IsDone");
            } 
        }

        [JsonProperty(PropertyName = "text")]
        public string Text 
        {   get { return _Text; } 
            set 
            { 
                if (_Text == value) return;
                _Text = value;
                OnPropertyChanged("Text");
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged; // Интерфейс требуется для фиксации изменений в старых задачах

        protected virtual void OnPropertyChanged(string propertyName = "") 
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // Проверка не пустая ли строка        
        }
    }
}
