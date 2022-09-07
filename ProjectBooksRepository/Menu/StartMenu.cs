using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProjectBooksRepository.Adding;
using ProjectBooksRepository.Changes;
using ProjectBooksRepository.DataOutput;
using ProjectBooksRepository.Removers;
using ProjectBooksRepository.Searching;

namespace ProjectBooksRepository.Menu
{
    internal class StartMenu
    {
        public void MainMenu()
        {
            List<string> items = new List<string> { "Add a book with/Without Author", "Remove book", "Add Author", "Remove Author", "View all books",
               "Search a book by title", "View all authors", "Author search by name", "Change the existing author/book", "Exit" };

            Action[] methods = new Action[] { AddBookAndAuthor, RemoveBook, AddAuthor, RemoveAuthor, ViewBooks, 
                                              SearchBook, ViewAuthors, AuthorSearch, ChangeAuthorBook, Exit };

            MenuHelper menu = new MenuHelper(items);
            int menuResult;
            do
            {
                menuResult = menu.PrintMenu();
                methods[menuResult]();
                Console.WriteLine("\nWant to go back to the main menu? Press any key!");
                Console.ReadKey();
            } while (menuResult != items.Count - 1);

        }
        public void AddBookAndAuthor()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter (1) to add a book with an author, enter (2) to add a book without an author\n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the book name");
                        string bookname = Console.ReadLine().Trim();

                        Console.WriteLine("Enter the number of pages");
                        int pages = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the description");
                        string description = Console.ReadLine().Trim();

                        Console.WriteLine("Enter the critical appraisal");
                        sbyte criticalAppraisal = sbyte.Parse(Console.ReadLine());

                        Console.WriteLine("Enter genre");
                        string genre = Console.ReadLine().Trim();

                        Console.WriteLine("Enter the author's first name");
                        string fisrtName = Console.ReadLine().Trim();

                        Console.WriteLine("Enter the author's last name");
                        string lastName = Console.ReadLine().Trim();

                        Console.WriteLine("Enter the date of birth of the author");
                        DateTime dateOfBirth;
                        DateTime.TryParse(Console.ReadLine(), out dateOfBirth);

                        Console.WriteLine("Enter the author's gender ");
                        string gender = Console.ReadLine().Trim();

                        AddBooksWAuthors.BookGeneratorWithAuthor(bookname, pages, description, criticalAppraisal, genre, fisrtName, lastName, dateOfBirth, gender);

                        break;

                    case 2:
                        Console.WriteLine("Enter the book name");
                        string lonelyBookname = Console.ReadLine().Trim();

                        Console.WriteLine("Enter the number of pages");
                        int lonelyPages = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the description");
                        string lonelyDescription = Console.ReadLine().Trim();

                        Console.WriteLine("Enter the critical appraisal (numbers)");
                        sbyte lonelyCriticalAppraisal = sbyte.Parse(Console.ReadLine());

                        Console.WriteLine("Enter genre");
                        string lonelyGenre = Console.ReadLine().Trim();

                        AddBooksWAuthors.BookGeneretorWithoutAuthor(lonelyBookname, lonelyPages, lonelyDescription, lonelyCriticalAppraisal, lonelyGenre);

                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Wrong input. Press (Y) to try again or press (N) to return to main menu");
                string answer = Console.ReadLine().Trim().ToUpper();
                if (answer == "Y")
                {
                    AddBookAndAuthor();
                }
                else if (answer == "N")
                {
                    MainMenu();
                }
            }
        }
        public void RemoveBook()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Available books for deletion:\n");
                OutputAllBooks.Output();
                Console.WriteLine("\nEnter the name of the book you want to remove\n");
                string bookName = Console.ReadLine().Trim();
                BooksRemover booksRemover = new BooksRemover();
                booksRemover.Remover(bookName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press (Y) to continue or press (N) to return to main menu");
                string answer = Console.ReadLine().ToUpper().Trim();
                if (answer == "Y")
                {
                    RemoveAuthor();
                }
                else if (answer == "N")
                {
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }
        public void AddAuthor()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Enter the author's first name\n");
                string fisrtName = Console.ReadLine().Trim();

                Console.WriteLine("Enter the author's last name\n");
                string lastName = Console.ReadLine().Trim();

                Console.WriteLine("Enter the date of birth of the author\n");
                DateTime dateOfBirth;
                if (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                    throw new ArgumentException("Incorrect date data");

                Console.WriteLine("Enter the author's gender\n");
                string gender = Console.ReadLine().Trim();

                AddNewAuthor.AuthorGenerator(fisrtName, lastName, gender, dateOfBirth);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void RemoveAuthor()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Available authors to remove:\n");
                OutputAllAuthors.Output();
                Console.WriteLine("\nEnter the first name of the author you wish to remove\n");
                string name = Console.ReadLine().Trim();
                AuthorRemover authorRemover = new AuthorRemover();
                authorRemover.Remover(name);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press (Y) to continue or press (N) to return to main menu");
                string answer = Console.ReadLine().ToUpper().Trim();
                if (answer == "Y")
                {
                    RemoveAuthor();
                }
                else if (answer == "N")
                {
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }
        public void ViewBooks()
        {
            Console.Clear();
            OutputAllBooks.Output();
        }
        public void SearchBook()
        {
            Console.Clear();
            Console.WriteLine("Enter a book name\n");
            string name = Console.ReadLine();
            BooksSearcher booksSearcher = new BooksSearcher();
            if (!booksSearcher.Searcher(name))
            {
                Console.WriteLine("There is no such book. Press (Y) to continue your search or press (N) to return to main menu");
                string answer = Console.ReadLine().Trim().ToUpper();
                if (answer == "Y")
                {
                    SearchBook();
                }
                else if(answer == "N")
                {
                    MainMenu();
                }
            }
        }
        public void ViewAuthors()
        {
            Console.Clear();
            OutputAllAuthors.Output();
        }
        public void AuthorSearch()
        {
            Console.Clear();
            Console.WriteLine("Enter an author name\n");
            string name = Console.ReadLine();
            AuthorsSearcher authorsSearcher = new AuthorsSearcher();
            authorsSearcher.Searcher(name);
            Console.WriteLine("There is no such author. Press (Y) to continue your search or press (N) to return to main menu");
            string answer = Console.ReadLine().Trim().ToUpper();
            if (answer == "Y")
            {
                AuthorSearch();
            }
            else if (answer == "N")
            {
                MainMenu();
            }
        }
        public void ChangeAuthorBook()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("What do you want to change the author or the book?");
                string answer = Console.ReadLine().ToLower().Trim();
                if (answer == "author")
                {
                    OutputAllAuthors.Output();
                    Console.WriteLine("Enter an author ID");
                    int authorId = int.Parse(Console.ReadLine());
                    ChangesForAuthors.Changes(authorId);
                }
                else if (answer == "book")
                {
                    OutputAllBooks.Output();
                    Console.WriteLine("Enter a book ID");
                    int bookId = int.Parse(Console.ReadLine());
                    ChangesForBooks.Changes(bookId);
                }
                else
                {
                    ChangeAuthorBook();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press (Y) to continue your search or press (N) to return to main menu");
                string answer = Console.ReadLine().Trim().ToUpper();
                if (answer == "Y")
                {
                    SearchBook();
                }
                else if (answer == "N")
                {
                    MainMenu();
                }
            }
        }
        public void Exit()
        {
            Console.Clear();
            Console.WriteLine("Thank you for using app. Goodbye!");
            Environment.Exit(0);
        }
    }
}
