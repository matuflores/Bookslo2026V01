using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Bookslo2026.Entities
{
    //[Index(nameof(FirstName),nameof(LastName),IsUnique =true,Name ="IX_Authors_FirstName_LastName")]//con esta anotación se crea un índice único en la base de datos para los campos FirstName y LastName, lo que garantiza que no se puedan insertar autores con el mismo nombre completo
    //public class Author
    //{
    //    //por convencion entity framework reconoce que AuthorId es la clave primaria de la entidad Author, pero también se podría usar el atributo [Key] para indicarlo explícitamente
    //    [Key]
    //    public int AuthorId { get; set; }

    //    [Required(ErrorMessage = "The field {0} is required.")]
    //    [StringLength(50, ErrorMessage = "The field {0} must have {2} and {1} characters.", MinimumLength = 3)]
    //    public string FirstName { get; set; } = null!;

    //    [Required(ErrorMessage = "The field {0} is required.")]
    //    [StringLength(50, ErrorMessage = "The field {0} must have {2} and {1} characters.", MinimumLength = 3)]
    //    public string LastName { get; set; } = null!;

    //    public override string ToString()
    //    {
    //        return $"{FirstName} {LastName}";
    //    }
    //}

    //todas las anotaciones y parametros que puse arriba los anule para hacelor desde "CONFIGURATIONS"
    //y no ensuciar mi entidad, pero si quisiera dejarlo aca también es válido
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        ICollection<Book> Books { get; set; } = null!;
    }
}
