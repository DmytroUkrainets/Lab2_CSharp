using System.Windows;
using Lab2.ViewModels;

namespace Lab2.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();
    }
}