using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WcfProxies.Contracts.Services;
using WcfProxies.Data.Repositories;
using WcfProxies.Services;
using Autofac.Integration.Wcf;

namespace WcfProxies.WindowsHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost host;
        ContainerBuilder builder;
        IContainer container;

        public MainWindow()
        {
            InitializeComponent();
            builder = new ContainerBuilder();
            builder.RegisterType<BlogPostController>().As<IBlogPostService>();
            builder.RegisterType<BlogPostRepository>().As<IBlogPostRepository>();
            container = builder.Build();
        }

        private void btnStopService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                host.Close();
                btnStopService.IsEnabled = false;
                btnStartService.IsEnabled = true;
                lblStatus.Content = "Service is stopped.";
                lblStatus.Foreground = new SolidColorBrush(Colors.RoyalBlue);
            }
            catch (Exception ex)
            {
                container.Dispose();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStartService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                host = new ServiceHost(typeof(BlogPostController));
                host.AddDependencyInjectionBehavior<IBlogPostService>(container);
                host.Open();
                btnStopService.IsEnabled = true;
                btnStartService.IsEnabled = false;
                lblStatus.Content = "Service is running.";
                lblStatus.Foreground = new SolidColorBrush(Colors.RoyalBlue);
            }
            catch (Exception ex)
            {
                container.Dispose();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
