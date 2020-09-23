﻿using MongoDB.Bson;
using MongoDB.Driver;
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


namespace socialnetwork_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MongoClient client = new MongoClient("mongodb://localhost:27017");
        static IMongoDatabase db = client.GetDatabase("users");
        static IMongoCollection<User> collection = db.GetCollection<User>("socialnetwork");

        public void VerifyUsersLogInData()
        {
            List<User> list = collection.AsQueryable().ToList<User>();
            dgUser.ItemsSource = list;
            User user = (User)dgUser.Items.GetItemAt(0);
            //List<User> list = collection.AsQueryable().ToList<User>();

            
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<User> list = collection.AsQueryable().ToList<User>();
            dgUser.ItemsSource = list;
            User user = (User)dgUser.Items.GetItemAt(0);
            if(tbxUserName.Text == user.userName && tbxPassword.Text == user.password)
            {
                GeneralWindow objGeneralWindow = new GeneralWindow();
                this.Visibility = Visibility.Hidden;
                objGeneralWindow.Show();
            }
            if(tbxUserName.Text == user.userName && tbxPassword.Text != user.password)
            {
                MessageBox.Show("Wrong password! Please try again.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterWindow objRegisterWindow = new RegisterWindow();
            this.Visibility = Visibility.Hidden;
            objRegisterWindow.Show();
        }
    }
}