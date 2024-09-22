using API_Bibliotek.Serviceis;
using AutoMapper;
using API_Bibliotek.Data;
using API_Bibliotek.Models;
using API_Bibliotek.Models.DTOs;


namespace API_Bibliotek.Endpoints
{
    public static class LibraryEndPoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            app.MapGet("/api/books", GetAllBooks).WithName("GetBooks").Produces<APIResponse>();

            app.MapGet("/api/book/{id:int}", GetBook).WithName("GetBook").Produces<APIResponse>();

            app.MapPost("/api/book", CreateBook).
                WithName("CreateBook").
                Accepts<CreateBookDTO>("application/json").
                Produces(201).Produces(400);

            app.MapPut("/api/book", UpdateBook).WithName("UpdateBook").
                Accepts<UpdateBookDTO>("application/json").
                Produces<UpdateBookDTO>(200).Produces(400);

            app.MapDelete("/api/book/{id:int}", DeleteBook).WithName("DeleteBook");
        }

        private async static Task<IResult> GetAllBooks(IbookRepo _bookRepo)
        {
            APIResponse response = new APIResponse
            {
                Result = await _bookRepo.GetAllBooksAsync(),
                IsSuccess = true,
                StatusCode = System.Net.HttpStatusCode.OK
            };

            return Results.Ok(response);
        }

        private async static Task<IResult> GetBook(IbookRepo _bookRepo, int id)
        {
            APIResponse response = new APIResponse
            {
                Result = await _bookRepo.GetBookByIdAsync(id),
                IsSuccess = true,
                StatusCode = System.Net.HttpStatusCode.OK
            };

            return Results.Ok(response);
        }

        private async static Task<IResult> CreateBook(IbookRepo _bookRepo, IMapper _mapper, CreateBookDTO bookCreateDto)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            var existingBook = await _bookRepo.GetBookByTitleAsync(bookCreateDto.Title);
            if (existingBook != null)
            {
                response.ErrorMessages.Add("Book Title is already in use, please use another");
                return Results.BadRequest(response);
            }

            Book book = _mapper.Map<Book>(bookCreateDto);
            await _bookRepo.AddBookAsync(book);
            BookDTO bookDto = _mapper.Map<BookDTO>(book);

            response.Result = bookDto;
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.Created;

            return Results.Ok(response);
        }

        private async static Task<IResult> UpdateBook(IbookRepo _bookRepo, IMapper _mapper, UpdateBookDTO bookUpdateDto)
        {
            APIResponse response = new APIResponse { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            var book = await _bookRepo.GetBookByIdAsync(bookUpdateDto.id);
            if (book == null)
            {
                response.ErrorMessages.Add("Invalid Book ID");
                return Results.BadRequest(response);
            }

            _mapper.Map(bookUpdateDto, book);
            await _bookRepo.UpdateBookAsync(book);

            response.Result = _mapper.Map<BookDTO>(book);
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return Results.Ok(response);
        }

        private async static Task<IResult> DeleteBook(IbookRepo _bookRepo, int id)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            Book bookFromDb = await _bookRepo.GetBookByIdAsync(id);

            if (bookFromDb != null)
            {
                await _bookRepo.DeleteBookAsync(id);
                response.IsSuccess = true;
                response.StatusCode = System.Net.HttpStatusCode.NoContent;
                return Results.NoContent();
            }
            else
            {
                response.ErrorMessages.Add("Invalid ID");
                return Results.BadRequest(response);
            }
        }
    }
}