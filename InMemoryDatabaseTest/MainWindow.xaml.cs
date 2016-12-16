using System.Windows;
using System.Windows.Input;
using InMemoryDatabaseTest.ViewModels;

namespace InMemoryDatabaseTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e) => ViewModel.AddWithName(NameTextBox.Text);

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e) => ViewModel.Update();

        private void EntitiesDataGrid_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                ViewModel.RemoveCurrent();
        }
    }
}
