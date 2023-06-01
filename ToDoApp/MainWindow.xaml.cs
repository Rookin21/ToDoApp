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
        private BindingList<ToDoModel> _ToDoData; // Контейнер для хранения данных

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _ToDoData = new BindingList<ToDoModel>()
            {
                new ToDoModel() { Text = "test" },
                new ToDoModel() { Text = "test2" }
            };

            dgToDoList.ItemsSource = _ToDoData;
        }
    }
}
