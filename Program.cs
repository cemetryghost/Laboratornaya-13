using System;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBook book1 = new Book("Book 1", "Author 1");
            book1.SetPublicationDate(new DateTime(2022, 1, 1));
            book1.SetPages(100);

            IBook book2 = new Book("Book 2", "Author 2");
            book2.SetPublicationDate(DateTime.Parse("2022-01-02"));
            book2.SetPages(200);

            IUser user1 = new User("user1", "password1");
            IUser user2 = new User("user2", "1234");

            IProductUser productUser = new ProductUser("Book 1", 10.0M, user1);
            productUser.Buy();
        }
    }

    public interface IPublisher
    {
        void SetTitle(string title);
        void SetAuthor(string author);
        string GetTitle();
        string GetAuthor();
    }


    public interface IBook : IPublisher
    {
        DateTime PublicationDate { get; set; }
        int Pages { get; set; }
        void SetPublicationDate(DateTime date);
        void SetPages(int pages);
    }

    public interface IUser
    {
        object Login { get; set; }
        object Password { get; set; }
    }

    public interface IProduct
    {
        void Buy();
    }

    public class Book : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Pages { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public Book(string title, string author, DateTime publicationDate, int pages)
        {
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
            Pages = pages;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetAuthor(string author)
        {
            Author = author;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetAuthor()
        {
            return Author;
        }

        public void SetPublicationDate(DateTime date)
        {
            PublicationDate = date;
        }

        public void SetPages(int pages)
        {
            Pages = pages;
        }

        public DateTime GetPublicationDate()
        {
            return PublicationDate;
        }

        public int GetPages()
        {
            return Pages;
        }
    }

    public class User : IUser
    {
        public object Login { get; set; }
        public object Password { get; set; }

        public User(object login, object password)
        {
            Login = login;
            Password = password;
        }
    }

    public interface IProductUser : IProduct
    {
        IUser User { get; set; }
    }

    public class ProductUser : IProductUser
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IUser User { get; set; }

        public ProductUser(string name, decimal price, IUser user)
        {
            Name = name;
            Price = price;
            User = user;
        }

        public void Buy() => Console.WriteLine($"{User.Login} купил {Name}");
    }
}
