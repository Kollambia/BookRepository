using System;
using Microsoft.EntityFrameworkCore;
using ProjectBooksRepository.Menu;
using ProjectBooksRepository.Searching;

namespace ProjectBooksRepository
{
    class Program
    {
        static void Main(String[] args)
        {
            StartMenu startMenu = new StartMenu();
            startMenu.MainMenu();
        }
    }
}