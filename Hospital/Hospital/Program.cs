using Hospital.Menu;
using Hospital.Models;
using Hospital.Repositories;
using Hospital.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Hospital
{
    internal class Program
    {
        private static object mainMenu;

        static void Main(string[] args)
        {
            MainMenu.Menu();
        }
        
    }
}