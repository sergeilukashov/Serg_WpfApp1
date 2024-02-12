using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serg_WpfApp1
{
    class User
    {
        string login;
        string password;
        string service;
        public User() 
        {
            string login = "";
            string password = "";
            string service = "";
        }
        public User(string login, string password, string service)
        {
         
            this.login = login;
            this.password = password;
            this.service = service;


        }
        public string Login 
        {   get { return login; }
            set { login = value; } 
        }
        public string Service
        {
            get { return service; }
            set { service = value; }

        }
        public string Password
        {  
           get { return password; } 
           set { password = value; } 
        }

        public  string ToSrting()
        {
            return "Имя пользователя: " + Login + " Пароль: " + Password + " Сервис: " +  Service;
        }


    }
}
