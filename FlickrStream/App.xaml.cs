using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Microsoft.Practices.Unity.Configuration;
using log4net;
using FlickrStream.Infrastructure;

namespace FlickrStream
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(App));

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();
            
            //Setup Logger
            log4net.Config.XmlConfigurator.Configure();
            log.Info("        =============  Started Logging  =============        ");
            container.RegisterInstance<ILog>(log);

            //Configure Unitu for IOC
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section != null)
            {
                section.Configure(container);
            }
            DIContainer.UnityContainer = container;

            var window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}
