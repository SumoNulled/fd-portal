using FDPortal.Model;
using FDPortal.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FDPortal.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
        public ICommand? ChangeClockedInCommand { get; }

        private IUserRepository userRepository;

        public event EventHandler ClockedInChanged;

        public DashboardViewModel() 
        {
            userRepository = new UserRepository();
            ChangeClockedInCommand = new RelayCommand(ExecuteChangeClockedInCommand, CanExecuteChangeClockedInCommand);
        }

        private bool _isClockedIn;

        public bool IsClockedIn
        {
            get { return _isClockedIn; }
            set
            {
                if (_isClockedIn != value)
                {
                    _isClockedIn = value;
                    OnPropertyChanged(nameof(IsClockedIn));
                }
            }
        }

        private UserModel selectedGridItem;
        public UserModel SelectedGridItem
        {
            get { return selectedGridItem; }
            set
            {
                if (selectedGridItem != value)
                {
                    selectedGridItem = value;
                    OnPropertyChanged(nameof(SelectedGridItem));
                }
            }
        }

        private void ExecuteChangeClockedInCommand(object obj)
        {
            int userId = selectedGridItem.Id ?? 0; // Replace with the actual user ID

            // Check if the user is already clocked in
            bool isClockedIn = userRepository.IsClockedIn(userId);

            if (isClockedIn)
            {
                // User is already clocked in, so clock them out
                userRepository.ClockOut(userId);
            }
            else
            {
                // User is not clocked in, so clock them in
                userRepository.ClockIn(userId);
            }

            // Raise the event to notify the view to refresh the DataGrid
            ClockedInChanged?.Invoke(this, EventArgs.Empty);
        }

        private bool CanExecuteChangeClockedInCommand(object obj)
        {
            return SelectedGridItem != null;
        }
    }
}
