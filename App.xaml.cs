using FDPortal.Model.Database;
using FDPortal.Model.Repositories;
using FDPortal.View;
using System.Collections.Generic;
using System.Windows;

namespace FDPortal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Config config = new Config();
        Database database = new Database();


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

           //database.Create(config.getDataSource(), config.getPassword());
        }

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            SessionRepository.CreateSession("kbellator");

            if (!SessionRepository.GetLoggedIn())
            {
                var loginView = new LoginView();
                loginView.Show();
                loginView.IsVisibleChanged += (s, ev) =>
                {
                    if (loginView.IsVisible == false && loginView.IsLoaded)
                    {
                        var mainView = new MainWindow();
                        mainView.Show();
                        loginView.Close();
                    }
                };
            } 
            else
            {
                var mainView = new MainWindow();
                mainView.Show();
            }
        }

    }

}
