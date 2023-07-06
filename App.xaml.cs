using FDPortal.Model.Database;
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

           // database.Create(config.getDataSource(), config.getPassword());
        }
    }

}
