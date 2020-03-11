using System;
using System.Collections.Generic;
using System.Linq;
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
using TestTask1.Models;
using TestTask1.ViewModels;

namespace TestTask1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = true;
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = true;
        }

        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                popup.IsOpen = true;
                var mainViewModel = (MainViewModel) popup.DataContext;
                if (item.Content is Money)
                {
                    mainViewModel.AssetType = (int) AssetTypes.Money;
                    mainViewModel.EditingMoney = (Money) item.Content;
                }
                else if (item.Content is Building)
                {
                    mainViewModel.AssetType = (int) AssetTypes.Buildings;
                    mainViewModel.EditingBuilding = (Building) item.Content;
                }
                else if (item.Content is Asset)
                {
                    mainViewModel.AssetType = (int) AssetTypes.Other;
                    mainViewModel.EditingOther = (Asset) item.Content;
                }
            }
        }

        private void PopupCancelButtonClick(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }
    }
}