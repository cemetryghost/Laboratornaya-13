namespace ConsoleApp13._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book<string> book1 = new Book<string>();
            book1.SetTitle("Олдос Хаксли");
            book1.SetAuthor("О дивный новый мир!");
            book1.SetPublicationDate("01.01.1932");

            Book<int> book2 = new Book<int>();
            book2.SetTitle("Олдос Хаксли");
            book2.SetAuthor("О дивный новый мир!");
            book2.SetPublicationDate(01011932);

            User<int> user1 = new User<int>();
            user1.SetLogin(123);
            user1.SetPassword("Hello!");

            User<string> user2 = new User<string>();
            user2.SetLogin("12345");
            user2.SetPassword("World!");

            ProductUser<int> productUser = new ProductUser<int>();
            productUser.SetTitle("Сияние");
            productUser.SetAuthor("Стивен Кинг");
            productUser.SetLogin(123);
            productUser.SetPassword("pop");
            productUser.Buy();
        }
    }

    interface IPublisher
    {
        void SetTitle(string title);
        void SetAuthor(string author);
    }

    interface IBook<T> : IPublisher
    {
        void SetPublicationDate(T publicationDate);
        void SetPageCount(int pageCount);
    }
    
    interface IUser<T>
    {
        void SetLogin(T login);
        void SetPassword(string password);
    }

    class Book<T> : IBook<T>
    {
        private string title;
        private string author;
        private T publicationDate;
        private int pageCount;

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPublicationDate(T publicationDate)
        {
            this.publicationDate = publicationDate;
        }

        public void SetPageCount(int pageCount)
        {
            this.pageCount = pageCount;
        }

        public void DisplayBookInfo()
        {
            Console.WriteLine($"Название: {title}");
            Console.WriteLine($"Автор: {author}");
            Console.WriteLine($"Дата публикации: {publicationDate}");
            Console.WriteLine($"Количество страницt: {pageCount}");
        }
    }

    class User<T> : IUser<T>
    {
        private T login;
        private string password;

        public void SetLogin(T login)
        {
            this.login = login;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public void InfoAccounts()
        {
            Console.WriteLine($"Login: {login}");
            Console.WriteLine($"Password: {password}");
        }
    }

    class ProductUser<T> : IUser<T>, IPublisher
    {
        private T login;
        private string password;
        private string title;
        private string author;

        public void SetLogin(T login)
        {
            this.login = login;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void Buy()
        {
            Console.WriteLine($"Пользователь {login} купил книгу - {title}, автор {author}");
        }
    }
}
