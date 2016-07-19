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
using WcfProxies.Contracts.Data;
using WcfProxies.Proxies.Shared;

namespace WcfProxies.Clients
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

        private void btnSharedClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //BlogPostClient sharedProxy = new BlogPostClient("tcp");
                EndpointAddress address = new EndpointAddress("http://localhost:9002/BlogPostService");
                System.ServiceModel.Channels.Binding binding = new WSHttpBinding();
                BlogPostClient sharedProxy = new BlogPostClient(binding, address);
                PostData firstPost = sharedProxy.GetPost(1);
                if (firstPost != null)
                {
                    lbxResult.Items.Clear();
                    lbxResult.Items.Add(firstPost.Title + " by " + firstPost.Author);
                }
                sharedProxy.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNonSharedClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNonSharedClientInjected_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
