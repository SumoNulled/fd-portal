using FDPortal.Model;
using FDPortal.Model.Repositories;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace FDPortal.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        // Fields
        private string? _username = "kbellator";
        private SecureString? _password;
        private string? _errorMessage;
        private bool? _isViewVisible = true;

        private IUserRepository userRepository;

        // Properties
        public string? Username 
        { 
            get => _username; 
            
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString? Password 
        { 
            get => _password;

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string? ErrorMessage 
        { 
            get => _errorMessage; 
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool? IsViewVisible 
        { 
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        // Commands
        public ICommand? LoginCommand { get; }
        public ICommand? RecoverPasswordCommand { get; }
        public ICommand? ShowPasswordCommand { get; }
        public ICommand? RememberPasswordCommand { get; }

        // Constructor
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new RelayCommand(p => ExecuteRecoverPasswordCommand("", ""));

            // Create a new instance of SecureString and add each character of the password string
            string password = "pass1234";
            foreach (char c in password)
            {
                _password.AppendChar(c);
            }
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;

            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
            {
                validData = false;
            } 
            else
            {

                validData = true;
            }

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(
                new NetworkCredential(Username, Password) 
                );

            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null
                    );

                SessionRepository.CreateSession(Username);
                IsViewVisible = false;
            }
             else
            {
                ErrorMessage = " * Invalid username or password";
            }
        }

        private void ExecuteRecoverPasswordCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
