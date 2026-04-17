using Bookslo2026.Data;
using Bookslo2026.Entities;
using Bookslo2026.IoC;
using Bookslo2026.Service.DTOs.Author;
using Bookslo2026.Service.DTOs.Publisher;
using Bookslo2026.Service.Interfaces;
using Bookslo2026.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Bookslo2026.Consola
{
    internal class Program
    {//hice hasta el servicio de publisher, es decir me quede en el punto 6 del ejercicio, tengo que desarrollar los servicios 
        //static IAuthorService _service = new AuthorService();
        static IServiceProvider provider = DependencyInyectionContainer.Configure();
        
        static void Main(string[] args)
        {


            using (var scoped=provider.CreateScope())
            {
                var service = scoped.ServiceProvider.GetRequiredService<IAuthorService>();
                var servicePublisher = scoped.ServiceProvider.GetRequiredService<IPublisherService>();
                do
                {
                    Console.Clear();
                    Console.WriteLine("Library Manager");
                    Console.WriteLine("1. Authors");
                    Console.WriteLine("2. Publishers");
                    Console.WriteLine("3. Books");
                    Console.WriteLine("0. Exit");
                    var option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("Authors");
                            Console.WriteLine("1. List Authors");
                            Console.WriteLine("2. Add Authors");
                            Console.WriteLine("3. Delete Authors");
                            Console.WriteLine("4. Update Authors");
                            var optionAuthors = Console.ReadLine();
                            switch (optionAuthors)
                            {
                                case "1":
                                    ListAuthors(service);
                                    break;
                                case "2":
                                    AddAuthor(service);
                                    break;
                                case "3":
                                    DeleteAuthor(service);
                                    break;
                                case "4":
                                    UpdateAuthor(service);
                                    break;
                                case "0":
                                    return;
                                default:
                                    break;
                            }
                            break;
                        case "2":
                            Console.WriteLine("Publishers");
                            Console.WriteLine("1. List Publishers");
                            Console.WriteLine("2. Add Publishers");
                            var optionPublisher = Console.ReadLine();
                            switch (optionPublisher)
                            {
                                case "1":
                                    ListPublisher(servicePublisher);
                                    break;
                                case "2":
                                    AddPublisher(servicePublisher);
                                    break;
                                //case "3":
                                //    DeletePublisher(service);
                                //    break;
                                //case "4":
                                //    UpdatePublisher(service);
                                //    break;
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
        }

        private static void AddPublisher(IPublisherService servicePublisher)
        {
            Console.Clear();
            Console.WriteLine("Add a New Publisher");
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Country: ");
            var country = Console.ReadLine();
            Console.WriteLine("FoundedDate (yyyy-mm-dd): ");
            var foundedDate = DateTime.Parse(Console.ReadLine()!);
            Console.WriteLine("Email: ");
            var email = Console.ReadLine();

            var publisherDto = new PublisherCreateDto
            {
                Name = name!,
                Country = country!,
                FoundedDate = foundedDate,
                Email = email!
            };


            var result = servicePublisher.Add(publisherDto);
            if (!result.Success)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error);
                }
            }
            else
            {
                Console.WriteLine("Publisher added successfully!!");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        private static void ListPublisher(IPublisherService servicePublisher)
        {
            Console.Clear();
            Console.WriteLine("Publishers List");
            ShowPublisher(servicePublisher);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        private static void ShowPublisher(IPublisherService servicePublisher)
        {
            var publishers = servicePublisher.GetAll();
            foreach (var publisher in publishers)
            {
                Console.WriteLine($"ID: {publisher.PublisherId} Publisher: {publisher.Name} Country: {publisher.Country}");
            }
        }

        private static void UpdateAuthor(IAuthorService service)
        {
            Console.Clear();
            Console.WriteLine("Update an Author");
            ShowAuthor(service);

            //using (var context = new BooksDbContext())
            //{
            Console.Write("Select an ID to update: ");

            var authorId = int.Parse(Console.ReadLine()!);

            //var authorToUpdate = context.Authors.FirstOrDefault(a=>a.AuthorId==authorId);
            var authorToUpdate = service.GetForUpdate(authorId);
            if (authorToUpdate!=null)
            {
                Console.WriteLine($"Author to Update: {authorToUpdate.FirstName} {authorToUpdate.LastName}"); 
                Console.WriteLine("New First Name (ENTER to keep the same):");
                var inputFirstName = Console.ReadLine();
                var newFirstName =! string.IsNullOrWhiteSpace(inputFirstName)?inputFirstName:authorToUpdate.FirstName;//si el usuario ingresa un valor diferente de null o whitespace se asigna ese valor, sino se mantiene el mismo valor que ya tiene el autor
                Console.WriteLine("New Last Name (ENTER to keep the same):");
                var inputLastName = Console.ReadLine();
                var newLastName = !string.IsNullOrWhiteSpace(inputLastName) ? inputLastName : authorToUpdate.LastName;

                Console.WriteLine("Confirm the changes (y/n)");
                var responde= Console.ReadLine();
                if (responde!.ToLower()=="y")
                {
                    //try
                    //{
                    authorToUpdate.FirstName = newFirstName;
                    authorToUpdate.LastName = newLastName;
                    
                    var result = service.Update(authorToUpdate);
                    if (!result.Success)
                    {
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine(error);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Author updated successfully!");
                    }
                    //if (_service.Update(authorToUpdate))
                    //{
                    //    Console.WriteLine("Author updated successfully!");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Database error!");
                    //}
                        //
                        //context.SaveChanges();
                        
                    //}
                    //catch (Exception)
                    //{
                        //Console.WriteLine("Database error!");
                    //}
                }
                else
                {
                    Console.WriteLine("Cancelled by user");
                }
            }
            else
            {
                Console.WriteLine("Author does not exist");
            }
            Console.WriteLine("Key to continue");
            Console.ReadLine();
            //}
        }

        private static void DeleteAuthor(IAuthorService service)
        {
            Console.Clear();
            Console.WriteLine("Delete an Author");
            Console.WriteLine("List of Available Authors");
            ShowAuthor(service);
            //using (var context = new BooksDbContext())
            //{                
            Console.Write("Select an ID to delete: ");
            var authorId = int.Parse(Console.ReadLine()!);//el ! es para decirle al compilador que no va a ser nulo, pero hay que tener cuidado porque si el usuario ingresa algo que no es un número va a lanzar una excepción, por eso se podría usar int.TryParse para manejar ese caso

            //var authorToDelete=context.Authors.Find(authorId);//uso find para buscar por la clave primaria, en este caso el AuthorId, podria haber usado FirstOrDefault pero find es más eficiente para buscar por clave primaria
            var authorToDelete = service.GetById(authorId);
            if (authorToDelete != null)
            {
                Console.Write($"¿Are you sure to delete {authorToDelete.FirstName} {authorToDelete.LastName} (y/n)?");
                var response = Console.ReadLine();
                if (response!.ToLower()=="y")
                {
                    var result = service.Delete(authorToDelete.AuthorId);
                    if (!result.Success)
                    {
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine(error);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Author deleted successfully!");
                    }
                    //if (_service.Delete(authorToDelete.AuthorId))
                    ////try
                    //{
                    ////    context.Authors.Remove(authorToDelete);
                    ////    context.SaveChanges();
                    //    Console.WriteLine("Author deleted successfully!");
                    //}
                    ////catch (Exception)
                    //else
                    //{
                    //    Console.WriteLine("Database error!");
                    //} 
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
            //}
        }

        private static void AddAuthor(IAuthorService service)
        {
            Console.Clear();
            Console.WriteLine("Add a New Author");
            Console.WriteLine("First Name: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            var lastName = Console.ReadLine();

            //if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            //{
            //    Console.WriteLine("First Name and Last Name are required.");
            //}
            //else
            //{
            var authorDto = new AuthorCreateDto
            {
                FirstName = firstName!,
                LastName = lastName!,
            };

            var result = service.Add(authorDto);
            if (!result.Success)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error);
                }
            }
            else
            {
                Console.WriteLine("Author added successfully!!");
            }
                //if (_service.Add(author))
                //{
                //    Console.WriteLine("Author added successfully!!");
                //}
                //else//anulo lo de abajo porque empiezo a usar el servicio
                //{ 
                
                ////}
                ////try
                ////{
                ////    using (var context = new BooksDbContext())
                ////    {
                ////        context.Authors.Add(author);
                ////        context.SaveChanges();//persisto los cambios en la base de datos
                ////    }
                ////    Console.WriteLine("Author added successfully!!");
                ////}
                ////catch (Exception)
                ////{

                //    Console.WriteLine("Database error or author already exist!");
                //}
            //}

            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        private static void ListAuthors(IAuthorService service)
        {
            Console.Clear();
            Console.WriteLine("Authors List");
            ShowAuthor(service);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        private static void ShowAuthor(IAuthorService service)
        {
            //todo esto lo saco porque empiezo a usar el servicio!!!
            //using (var context = new BooksDbContext())
            //{
            //    var authors = context.Authors
            //        .AsNoTracking()
            //        .ToList();

            var authors = service.GetAll();
            foreach (var author in authors)
            {//recordar para que me traiga el nombre y apelldo en la entidad usar el override del ToString
                Console.WriteLine($"ID:{author.AuthorId,4} Author:{author.FullName,-30}");
            }
            //}
        }
    }
}
