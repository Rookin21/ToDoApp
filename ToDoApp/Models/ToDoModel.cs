using System;
using System.ComponentModel;

namespace ToDoApp.Models
{   
    /// <summary>
    /// Запись задач
    /// </summary>
    public class ToDoModel : INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool _IsDone;
        private string _Text;

        public bool IsDone 
        { 
            get { return _IsDone;} 
            set                                 // Проверка на наличие изменений
            {   if (_IsDone == value) return;                
                _IsDone = value; 
                OnPropertyChanged("IsDone");
            } 
        }
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
