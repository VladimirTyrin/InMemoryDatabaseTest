using System.Windows;

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
    }
}
