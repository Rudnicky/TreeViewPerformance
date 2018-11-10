using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using TreeViewPerformancePoC.Models;

namespace TreeViewPerformancePoC.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields & Properties
        private Stopwatch _collectionMeasureTime = new Stopwatch();
        private Stopwatch _renderingMeasureTime = new Stopwatch();
        private const int TOTAL = 100000;

        private ObservableCollection<Department> _departmentsCollection = new ObservableCollection<Department>();
        public ObservableCollection<Department> DepartmentsCollection
        {
            get
            {
                return _departmentsCollection;
            }
            set
            {
                if (_departmentsCollection != value)
                {
                    _departmentsCollection = value;
                    OnPropertyChanged(nameof(DepartmentsCollection));
                }
            }
        }

        private string _collectionTimeElapsed;
        public string CollectionTimeElapsed
        {
            get
            {
                return _collectionTimeElapsed;
            }
            set
            {
                if (_collectionTimeElapsed != value)
                {
                    _collectionTimeElapsed = value;
                    OnPropertyChanged(nameof(CollectionTimeElapsed));
                }
            }
        }

        private string _renderingTimeElapsed;
        public string RenderingTimeElapsed
        {
            get
            {
                return _renderingTimeElapsed;
            }
            set
            {
                if (_renderingTimeElapsed != value)
                {
                    _renderingTimeElapsed = value;
                    OnPropertyChanged(nameof(RenderingTimeElapsed));
                }
            }
        }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            SetupData();
        }
        #endregion

        #region Private Methods
        private void SetupData()
        {
            _collectionMeasureTime.Start();

            for (int i=0; i<TOTAL; i++)
            {
                _departmentsCollection.Add(new Department(RandomString(10)));
            }

            _collectionMeasureTime.Stop();
            CollectionTimeElapsed = _collectionMeasureTime.Elapsed.ToString();

            _renderingMeasureTime.Start();

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                _renderingMeasureTime.Stop();
                RenderingTimeElapsed = _renderingMeasureTime.Elapsed.ToString();
            }), DispatcherPriority.ApplicationIdle);
        }
        #endregion

        #region Helpers
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion
    }
}
