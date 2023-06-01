using System.ComponentModel;
using System.Windows;
using ToDoApp.Models;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<ToDoModel> _ToDoList; // Контейнер для хранения данных

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _ToDoList = new BindingList<ToDoModel>()
            {
                new ToDoModel() { Text = "test" },
                new ToDoModel() { Text = "test2" }
            };

            dgToDoList.ItemsSource = _ToDoList;
            _ToDoList.ListChanged += _ToDoList_ListChanged; // При изменении списка - вызывается метод
        }

        private void _ToDoList_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemAdded || 
                e.ListChangedType == ListChangedType.ItemDeleted || 
                e.ListChangedType == ListChangedType.ItemChanged)
            {

            }
        }
    }
}
