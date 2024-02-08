﻿using System;
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
using System.Configuration;
using System.Data.SqlClient;
using System.Security;

namespace MagazineManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text.ToString();
            SecureString enteredPassword = PasswordManager.GetSecurePassword(passwordBox);

            if (CurrentUser.login(login, enteredPassword))
            {
                MessageBox.Show("You have successfully logged in.");
                UserLoggedEvent(login);
                loginTextBox.Clear();
                passwordBox.Clear();
            }
            else
            {
                MessageBox.Show("Wrong login or password.");
            }
        }

        public delegate void LoginEventHandler(object sender, EventArgs e);
        public event LoginEventHandler LoginEvent;

        protected virtual void UserLoggedEvent(string login)
        {
            if (LoginEvent != null)
            {
                LoginEvent(this, EventArgs.Empty);
            }
        }
    }
}

