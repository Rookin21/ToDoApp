using System;

namespace ToDoApp.Models
{
    public class ToDoModel
    {
        public DateTime _CreationDate = DateTime.Now;

        private bool _IsDone;
        private string _Text;

        public bool IsDone { get { return _IsDone;} set { _IsDone = value; } }
        public string Text { get { return _Text; } set { _Text = value; } }
    }
}
