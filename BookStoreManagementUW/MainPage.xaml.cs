using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BookStoreManagementUW
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(Books.BookType), null);
            // this.Frame.Navigate(typeof(Books.Category), null);
            //this.Frame.Navigate(typeof(Staffs.RightStaff), null);
           
       
            //this.Frame.Navigate(typeof(Staffs.StaffInformation), new {bAdd=false, StaffID=7});
            this.Frame.Navigate(typeof(Books.BookSell),null);

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
