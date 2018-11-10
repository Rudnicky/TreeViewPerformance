using System.Windows;
using TreeViewPerformancePoC.ViewModels;

namespace TreeViewPerformancePoC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }
        #endregion

        #region Private Methods
        private void Setup()
        {
            this.DataContext = new MainWindowViewModel();
        }
        #endregion
    }
}
