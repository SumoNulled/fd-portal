using System;
using System.Windows.Input;

namespace FDPortal.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _currentChildView;
        private string? _currentChildViewTitle;

        public MainViewModel() 
        {
            ShowDashboardViewCommand = new RelayCommand(ExecuteShowDashboardViewCommand);
            ShowEmployeeViewCommand = new RelayCommand(ExecuteShowEmployeeViewCommand);

            // Default View
            ExecuteShowDashboardViewCommand(null);
        }

        private void ExecuteShowDashboardViewCommand(object obj)
        {
            CurrentChildView = new DashboardViewModel();
            CurrentChildViewTitle = "Dashboard";
        }

        private void ExecuteShowEmployeeViewCommand(object obj)
        {
            CurrentChildView = new EmployeeViewModel();
            CurrentChildViewTitle = "Employees";
        }

        public ViewModelBase CurrentChildView 
        { 
            get => _currentChildView; 
            set
            { 
                _currentChildView = value; 
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string CurrentChildViewTitle 
        { 
            get => _currentChildViewTitle; 
            set
            {
                _currentChildViewTitle = value;
                OnPropertyChanged(nameof(CurrentChildViewTitle));
            }
        }

        // Commands
        public ICommand ShowDashboardViewCommand { get; }
        public ICommand ShowEmployeeViewCommand { get; }
    }
}
