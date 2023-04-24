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
using System.Windows.Shapes;
using WpfProject.Tools;
using WpfProject.ViewModels;
using WpfProject.WebModels;

namespace WpfProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
            DataContext = new ListUserVM();
        }

        private async void AddUsers(object sender, RoutedEventArgs e)
        {
            var json = await HttpApi.Post("Users", "SaveUser", new User
            {
                FirstName = txt_Name.Text,
                LastName = txt_LastName.Text,
                PatronomycName = txt_PatronomycName.Text,
                PhoneNumber = long.Parse(txt_Phone.Text),
                Mail = txt_Email.Text,
                Login = txt_Login.Text,
                Password = txt_Password.Text,
                Post = new Post { PostName = txt_Role.Text}
            });
            User result = HttpApi.Deserialize<User>(json);

            MessageBox.Show("Сохранилось!");
        }
    }
}
