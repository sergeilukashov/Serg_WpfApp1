using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Serg_WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 0;
        string fileName = "database.db";
        string data;
        int index = -1;
        public MainWindow()
        {
            InitializeComponent();

            

            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    data = sr.ReadToEnd();
                }
                string[] lines = data.Split('\n');
                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        User user = JsonConvert.DeserializeObject<User>(line);
                        ServicesGrid.Items.Add(user);
                    }

                }

            }
        }
        //List<User> users = new List<User>();
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            for (int i = 0; i < this.userList.Items.Count; i++)
            {
                if (this.userList.SelectedItems != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Имя пользователя: " + userLogin + "\nПароль: " + userPassword + "\nСервис: " + userService);



                }


            }
        }

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            if(this.ServicesGrid.Items.Count == 0)
            {
                ServicesGrid.Items.Add(new User(userService.Text, userLogin.Text, userPassword.Text));
                userService.Text = "";
                userLogin.Text = "";
                userPassword.Text = "";
            }

            else if(this.ServicesGrid.Items.Count != 0) 
            {

                ServicesGrid.Items.Add(new User(userService.Text, userLogin.Text, userPassword.Text));

                userService.Text = "";
                userLogin.Text = "";
                userPassword.Text = "";

                //index = -1;
                //User us;

                //for (int i = 0; i < this.ServicesGrid.Items.Count; i++)
                //{
                //    index = this.ServicesGrid.Items.IndexOf(this.ServicesGrid.SelectedItems[i]);

                //    us = (User)this.ServicesGrid.SelectedItems[index];
                    
                //    if (userService != ServicesGrid.Items[index] && userLogin != ServicesGrid.Items[index] && userPassword != ServicesGrid.Items[index])
                //    {
                //        ServicesGrid.Items.Add(new User(userService.Text, userLogin.Text, userPassword.Text));
                //    }
                //}



            }
            else
            {
                userService.Text = "";
                userLogin.Text = "";
                userPassword.Text = "";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string gridLins = "";
            foreach (User us in ServicesGrid.Items)
            {
                gridLins += JsonConvert.SerializeObject(us) + "\n";
            }

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write(gridLins);
            }




           
        }

        private void ServicesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            if (this.ServicesGrid.Items.Count != 0)
            {
                if (this.ServicesGrid.SelectedItems != null) 
                {


                    if (MessageBox.Show("Вы уверены?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        for (int i = 0; i < this.ServicesGrid.Items.Count; i++)
                        {
                            this.ServicesGrid.Items.Remove(this.ServicesGrid.SelectedIndex);
                        }
                    }

                    
                
                }
            }
            
        }

        private void userService_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ServicesGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ServicesGrid_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
