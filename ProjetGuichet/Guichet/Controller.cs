﻿using System;

namespace Guichet
{
    class Controller
    {
        static void Main(string[] args)
        {
            Guichet guichet = new Guichet();
            Console.WriteLine(guichet);


            User a = new User("a");

            a.teste();


        }
    }
}
