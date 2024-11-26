namespace LMS
{
    public class Book
    {
        public String title;
        public String Author;
        public String Isbn;
        public bool IsAvailable;

        public Book(string title = "", string author = "", String isbn = "", bool isAvilable = default)
        {
            this.title = title;
            Author = author;
            Isbn = isbn;
            IsAvailable = isAvilable;
        }
        public void SetTitle(String title)
        {
            this.title = title;
        }
        public String GetTitle()
        {
            return title;
        }
        public void SetAuthor(String AuthorName)
        {
            Author = AuthorName;
        }
        public String GetAuthor()
        {
            return Author;
        }
        public void SetIsbn(String Isbn)
        {
            this.Isbn = Isbn;
        }
        public String GetIsbn()
        {
            return Isbn;
        }
        public void SetAvilable(bool Avilable)
        {
            IsAvailable = Avilable;
        }
        public bool GetIsAvilable()
        {
            return IsAvailable;
        }
    }
    public class Library
    {
        public List<Book> CollectionOfBooks = new List<Book>();
        public List<Book> AddBook()
        {
            Book book = new Book();
            Console.WriteLine("Please enter the title of the book:");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter Name of Book Author");
            String AuthorName = Console.ReadLine();
            Console.WriteLine("Please enter Isbn of Book ");
            String bookIsbn = Console.ReadLine();
            for (int i = 0; i < CollectionOfBooks.Count; i++)
            {
                if (CollectionOfBooks[i].Isbn == bookIsbn && CollectionOfBooks[i].title == title)
                {
                    Console.WriteLine("Sorry there is a book with the same Info ");
                    Console.WriteLine("");
                    return CollectionOfBooks;
                }
                
                 



            }

    Book newBook = new Book(title, AuthorName, bookIsbn, true);
            CollectionOfBooks.Add(newBook);
            Console.WriteLine("Book added successfully!");
            Console.WriteLine("");
                return CollectionOfBooks;
            {

            };
        }
        public bool BorrowBook()
        {
            Console.WriteLine("please enter Name of Book or Author");
            String Answer = Console.ReadLine();
            for (int i = 0; i < CollectionOfBooks.Count; i++)
            {
                string bookTitle = CollectionOfBooks[i].title;
                string bookAuthor = CollectionOfBooks[i].Author;
                if (bookTitle == Answer || bookAuthor == Answer)
                {
                    if (CollectionOfBooks[i].IsAvailable == true)
                    {
                        CollectionOfBooks[i].IsAvailable = false;
                        Console.WriteLine($"You have successfully borrowed '{bookTitle}' by {bookAuthor}.");
                        Console.WriteLine("");
                        return true;

                    }
                    else if (Answer != null && CollectionOfBooks[i].IsAvailable == false)
                    {
                        Console.WriteLine($"Sorry, the book '{bookTitle}' is already borrowed.");
                        Console.WriteLine("");
                        return false;

                    }

                }
                else
                {
                    Console.WriteLine("No matching book found in the library.");
                    Console.WriteLine("");

                }




            }



            return false;

        }
        public void SearchBook()
        {
            Console.WriteLine("PLease enter Title or AuthorName:  ");
            String Answer = Console.ReadLine();
            bool bookFound = false;

            for (int i = 0; i < CollectionOfBooks.Count; i++)
            {
                string bookTitle = CollectionOfBooks[i].title;
                string bookAuthor = CollectionOfBooks[i].Author;

                if (bookTitle == Answer || bookAuthor == Answer)
                {
                    bookFound = true;
                    if (CollectionOfBooks[i].IsAvailable)
                    {

                        Console.WriteLine($"Book '{CollectionOfBooks[i].title}' by {CollectionOfBooks[i].Author} is available.");
                    }
                    else
                    {
                        Console.WriteLine($"Book '{CollectionOfBooks[i].title}' by {CollectionOfBooks[i].Author} is borrowed. Sorry!");
                    }

                    break;
                }
            }

            if (!bookFound)
            {
                Console.WriteLine($"No matching book found for book{Answer} in the library.");
            }
        }
        public bool ReturnBook()
        {

            Console.WriteLine("Please enter name of Book you want to Return");
            String Answer = Console.ReadLine();
            for (int i = 0; i < CollectionOfBooks.Count; i++)
            {
                if (CollectionOfBooks[i].title == Answer || CollectionOfBooks[i].Author == Answer)
                {
                    if (CollectionOfBooks[i].IsAvailable)
                    {
                        Console.WriteLine("the book is already avilabele");
                        Console.WriteLine("");
                    }
                    else if (!CollectionOfBooks[i].IsAvailable)
                    {
                        Console.WriteLine("the book succefully Returned !");
                        Console.WriteLine("");
                        CollectionOfBooks[i].IsAvailable = true;

                    }
                    else
                    {
                        Console.WriteLine("there is no book with that name");
                        Console.WriteLine("");
                    }
                    {

                    }
                }

            }
            return false;
        }
        public void PrintAll()
        {
            for (int i = 0; i < CollectionOfBooks.Count; i++)
            {
                if (CollectionOfBooks[i].IsAvailable)
                {
                    Console.WriteLine($"The book \"{CollectionOfBooks[i].title}\" is available.");
                }
                else
                {
                    Console.WriteLine($"The book \"{CollectionOfBooks[i].title}\" is found but currently borrowed.");
                }
                Console.WriteLine();
            }
            
        }

        public void DeleteBook()
        {
            Console.WriteLine("Please Enter Title Of Book You Want Delete");
            String Answer = Console.ReadLine();
            for (int i = 0; i < CollectionOfBooks.Count; i++)
            {
                if (CollectionOfBooks[i].title == Answer)
                {
                    if (CollectionOfBooks[i].IsAvailable)
                    {
                        string bookTitle = CollectionOfBooks[i].title; 
                        CollectionOfBooks.RemoveAt(i);
                        Console.WriteLine($"The Book {bookTitle} Deleted Succesfully ");
                        Console.WriteLine("");
                        return;
                    }
                    else if(!CollectionOfBooks[i].IsAvailable)
                    {
                        Console.WriteLine("Sorry Book Is Borrowed");
                        Console.WriteLine("");

                    }
                    else
                    {
                        Console.WriteLine("Sorry Book Not Available Here");
                        Console.WriteLine("");


                    }

                }
            }
        }







        internal class Program
        {
            static void Main(string[] args)
            {
                Library library = new Library();
                char Answer;
                do
                {
                    Console.WriteLine("please enter A to add a book to our library !");
                    Console.WriteLine("Please enter B to borrow a Book ");
                    Console.WriteLine("Please enter S to Search for a Book ");
                    Console.WriteLine("Please enter R to Return a Book ");
                    Console.WriteLine("Please enter P to Print all list of Books  ");
                    Console.WriteLine("Please enter D to Delete Book From list of Books  ");
                    Console.WriteLine("Please enter Q to Quit ");
                    Answer = char.ToUpper(char.Parse(Console.ReadLine()));


                    switch (Answer)
                    {
                        case 'A':
                            library.AddBook();
                            break;

                        case 'B':
                            library.BorrowBook();
                            break;
                        case 'S':
                            library.SearchBook();
                            break;
                        case 'R':
                            library.ReturnBook();
                            break;
                        case 'P':
                            library.PrintAll();
                            break;
                            case 'D':
                             library.DeleteBook();
                                break;
                            case 'Q':
                            Console.WriteLine("See You Later Goodbye !");
                            break;
                         default:
                            Console.WriteLine("Please Enter A Valid Letter");
                            break;


                    }








                } while (Answer != 'Q');
            }
        }
    }
}
