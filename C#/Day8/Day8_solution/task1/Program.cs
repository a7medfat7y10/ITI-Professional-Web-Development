using static task1.Book;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] Authors1 = { "Steven ", "Covey " };
            String[] Authors2 = { "Ahmed ", "Khaled ", "Tawfik" };
            DateTime date = new DateTime();

            Book book1 = new Book("1", "7 Habits", Authors1, date, 100);
            Book book2 = new Book("2", "Paranormal", Authors2, date, 200);

            List<Book> Book_List = new List<Book> { book1, book2};

            //user defined
            BookDlDT fPtr1 = new BookDlDT(BookFunctions.GetTitle);
            BookDlDT fPtr2 = new BookDlDT(BookFunctions.GetAuthors);
            BookDlDT fPtr3 = new BookDlDT(BookFunctions.GetPrice);

            //BCL
            Func<Book, string> fPtr4 = BookFunctions.GetTitle;
            Func<Book, string> fPtr5 = BookFunctions.GetAuthors;
            Func<Book, string> fPtr6 = BookFunctions.GetPrice;

            //getISBN with anonymous method
            Func<Book, string> fPtr7 = delegate (Book book) { return book.ISBN; };

            //publication date with lambda expression
            Func<Book, string> fPtr8 = (Book book) => book.PublicationDate.ToString();


            Console.WriteLine("with user defined:");
            LibraryEngine.ProcessBooks(Book_List, fPtr1);
            LibraryEngine.ProcessBooks(Book_List, fPtr2);
            LibraryEngine.ProcessBooks(Book_List, fPtr3);
            Console.WriteLine("with BCL");
            LibraryEngine.ProcessBooks(Book_List, fPtr4);
            LibraryEngine.ProcessBooks(Book_List, fPtr5);
            LibraryEngine.ProcessBooks(Book_List, fPtr6);
            Console.WriteLine("with anonymous method");
            LibraryEngine.ProcessBooks(Book_List, fPtr7);
            //Get publication date with lam
            Console.WriteLine("with lambda expression");
            LibraryEngine.ProcessBooks(Book_List, fPtr8);
        }
    }

    public class Book
    {
        public delegate string BookDlDT(Book book);

        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public Book(string _ISBN, string _Title, string[] _Authors, 
            DateTime _PublicationDate, decimal _Price)
        {
            ISBN= _ISBN;
            Title= _Title;
            Authors= _Authors;
            PublicationDate= _PublicationDate;
            Price= _Price;
        }
        public override string ToString()
        {
            string auth = "";
            for (int i=0;i<Authors.Length;i++) { 
                auth += $"Author no. {i + 1} : {Authors[i]} \t";
            }
            auth += "\n";

            return $"ISBN: {ISBN} \n" +
                $"Title: {Title} \n" +
                $"Authors:{auth}\n" +
                $"Pubkication date: {PublicationDate} \n" +
                $"Price: {Price}";
        }
    }
    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }
        public static string GetAuthors(Book B)
        {
            String Authors = "";
            foreach (var author in B.Authors)
            {
                Authors += author;
            }

            return Authors;
        }
        public static string GetPrice(Book B)
        {
            return B.Price.ToString();
        }
    }
    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList,BookDlDT fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

    }
}