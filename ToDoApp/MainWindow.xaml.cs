using System;
using System.ComponentModel;
using System.Windows;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _Path = $"{Environment.CurrentDirectory}\\ToDoList.json";
        private BindingList<ToDoModel> _ToDoList; // Контейнер для хранения данных
        private FileIOService _FileIOService;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _FileIOService = new FileIOService(_Path);

            // Обработки ошибки при загрузке
            try
            {
                _ToDoList = _FileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();  
            }

            dgToDoList.ItemsSource = _ToDoList;
            _ToDoList.ListChanged += _ToDoList_ListChanged; // При изменении списка - вызывается метод
        }
        /// <summary>
        /// Фиксация изменений в списке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _ToDoList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemAdded || 
                e.ListChangedType == ListChangedType.ItemDeleted || 
                e.ListChangedType == ListChangedType.ItemChanged)
            {
                // Обработки ошибки при сохранении
                try
                {
                    _FileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }

            }
        }
    }
}
