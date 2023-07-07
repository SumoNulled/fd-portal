using FDPortal.Model.Repositories;
using System.Windows;
using System.Windows.Input;

namespace FDPortal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SessionRepository session = new SessionRepository();
        public MainWindow()
        {
            if (SessionRepository.GetLoggedIn())
            {
                InitializeComponent();
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CloseButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void MaximizeButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

    }
}
