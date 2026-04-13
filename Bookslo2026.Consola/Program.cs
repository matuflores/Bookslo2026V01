using Bookslo2026.Data;
using Bookslo2026.Entities;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Bookslo2026.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Library Manager"); 
                Console.WriteLine("1. Authors");
                Console.WriteLine("2. Books");
                Console.WriteLine("0. Exit");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Authors");
                        Console.WriteLine("1. List Authors");
                        Console.WriteLine("2. Add Authors");
                        Console.WriteLine("3. Delete Authors");
                        var optionAuthors = Console.ReadLine();
                        switch (optionAuthors)
                        {
                            case "1":
                                ListAuthors();
                                break;
                            case "2":
                                AddAuthor();
                                break;
                            case "3":
                                DeleteAuthor();
                                break;
                            case "0":
                                return;
                            default:
                                break;
                        }
                        break;
                    case "0":
                        return;
                    default:
                        break;
                }
            } while (true);
        }

        private static void DeleteAuthor()
        {
            Console.Clear();
            Console.WriteLine("Delete an Author");
            Console.WriteLine("List of Available Authors");
            ShowAuthor();
            using (var context = new BooksDbContext())
            {                
                Console.Write("Select an ID to delete: ");
                var authorId=int.Parse(Console.ReadLine()!);//el ! es para decirle al compilador que no va a ser nulo, pero hay que tener cuidado porque si el usuario ingresa algo que no es un número va a lanzar una excepción, por eso se podría usar int.TryParse para manejar ese caso
                var authorToDelete=context.Authors.Find(authorId);//uso find para buscar por la clave primaria, en este caso el AuthorId, podria haber usado FirstOrDefault pero find es más eficiente para buscar por clave primaria
                if (authorToDelete != null)
                {
                    Console.Write($"¿Are you sure to delete {authorToDelete} (y/n)?");
                    var response = Console.ReadLine();
                    if (response!.ToLower()=="y")
                    {
                        try
                        {
                            context.Authors.Remove(authorToDelete);
                            context.SaveChanges();
                            Console.WriteLine("Author deleted successfully!");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Database error!");
                        } 
                    }
                    else
                    {
                        Console.WriteLine("Deletion cancelled by user!");
                    }
                }
                else 
                { 
                    Console.WriteLine("Author does not exist!");
                }
                Console.WriteLine("Key to continue");
                Console.ReadLine();
            }
        }

        private static void AddAuthor()
        {
            Console.Clear();
            Console.WriteLine("Add a New Author");
            Console.WriteLine("First Name: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            var lastName = Console.ReadLine();

            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("First Name and Last Name are required.");
                
                return;
            }
            else
            {
                var author = new Author
                {
                    FirstName = firstName,
                    LastName = lastName,
                };
                using (var context = new BooksDbContext())
                {
                    context.Authors.Add(author);
                    context.SaveChanges();//persisto los cambios en la base de datos
                }
                Console.WriteLine("Author added successfully!!");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void ListAuthors()
        {
            Console.Clear();
            Console.WriteLine("Authors List");
            ShowAuthor();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        private static void ShowAuthor()
        {
            using (var context = new BooksDbContext())
            {
                var authors = context.Authors.ToList();
                foreach (var author in authors)
                {//recordar para que me traiga el nombre y apelldo en la entidad usar el override del ToString
                    Console.WriteLine($"ID:{author.AuthorId} Author:{author}");
                }
            }
        }
    }
}
