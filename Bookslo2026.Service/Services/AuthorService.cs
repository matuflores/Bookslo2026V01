using Bookslo2026.Data;
using Bookslo2026.Data.Interfaces;
using Bookslo2026.Data.Repositories;
using Bookslo2026.Entities;
using Bookslo2026.Service.DTOs.Author;
using Bookslo2026.Service.Interfaces;
using Bookslo2026.Service.Mappers;
using Bookslo2026.Service.Validators;
using FluentValidation;

namespace Bookslo2026.Service.Services
{
    public class AuthorService : IAuthorService
    {
        //private readonly IAuthorsRepository? _repository;
        private readonly IValidator<Author> _validator;
        private readonly IUnitOfWork _uow;

        public AuthorService(IValidator<Author> validator, IUnitOfWork unitOfWork)
        {
            //_repository = repository;
            _validator = validator;
            _uow = unitOfWork;
            //_repository = new AuthorRepository();
            //_validator = new AuthorValidator();
        }
        public (bool Success, List<string> Errors) Add(AuthorCreateDto authorDto)
        {
            //var author = new Author
            //{
            //    FirstName = authorDto.FirstName,
            //    LastName = authorDto.LastName,
            //};
            var author = AuthorMapper.toEntity(authorDto);
            var result = _validator.Validate(author);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return (false, errors);
            }// SI LA VALIDACION NO FUE VALIDADA, DEVOLVEMOS LOS ERRORES DE VALIDACION AL USUARIO
            if (!_uow.Authors.Exist(author.FirstName, author.LastName))
            {
                try
                {
                    _uow.Authors.Add(author);
                    _uow.Save();
                    return (true, new List<string>());
                }
                catch (Exception)
                {
                    return (false, new List<string>() { "Database error!" });
                }
            }
            else
            {
                return (false, new List<string>() { "Author alredy exist!" });
            }
        }

        public (bool Success, List<string> Errors) Delete(int id)
        {

            try
            {
                _uow.Authors.Delete(id);
                _uow.Save();//esto lo pongo para que se guarden los cambios en la base de datos, ya que el repository solo hace el cambio en memoria, pero no lo guarda en la base de datos, por eso necesito el unit of work para guardar los cambios en la base de datos
                return (true, new List<string>());
            }
            catch (Exception)
            {
                return (false, new List<string>() { "Database error!" });
            }
        }

        public List<AuthorListDto> GetAll()
        {
            return _uow.Authors.GetAll()
                .Select(a => AuthorMapper
                .ToAuthorListDto(a))
                .ToList();//transformamos la lista de autores a una lista de AuthorListDto, que es lo que queremos mostrar al usuario
        }

        public AuthorDetailsDto? GetById(int id)
        {
            var author = _uow.Authors.GetById(id);
            if (author == null) return null;
            return AuthorMapper.ToAuthorDetailsDto(author);
            //return new AuthorDetailsDto
            //{
            //    AuthorId = author.AuthorId,
            //    FirstName = author.FirstName,
            //    LastName = author.LastName
            //};
        }

        public AuthorUpdateDto? GetForUpdate(int id)
        {
            var author = _uow.Authors.GetById(id);
            if (author == null) return null;
            return AuthorMapper.ToAuthorUpdateDto(author);
            //return new AuthorUpdateDto
            //{
            //    AuthorId = author.AuthorId,
            //    FirstName = author.FirstName,
            //    LastName = author.LastName
            //};
        }

        public (bool Success, List<string> Errors) Update(AuthorUpdateDto authorDto)
        {
            //var author = AuthorMapper.toEntity(authorDto);
            Author? author=_uow.Authors.GetById(authorDto.AuthorId);
            if (author == null)
            {
                return (false, new List<string>() { "Author Not Found!" });
            }
            author.FirstName = authorDto.FirstName;
            author.LastName = authorDto.LastName;


            //var author = new Author
            //{
            //    AuthorId = authorDto.AuthorId,
            //    FirstName = authorDto.FirstName,
            //    LastName = authorDto.LastName
            //};

            var result = _validator.Validate(author);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return (false, errors);
            }
            if (!_uow.Authors.Exist(author.FirstName, author.LastName, author.AuthorId))
            {
                try
                {
                    //_repository.Update(author);
                    _uow.Save();
                    return (true, new List<string>());
                }
                catch (Exception)
                {
                    return (false, new List<string>() { "Database error!" });
                }
            }
            else
            {
                return (false, new List<string>() { "Author already exist!" });
            }
        }
    }
}
