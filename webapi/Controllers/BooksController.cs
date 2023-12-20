using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public BooksController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAllBooks()
        {
            var result = _context.Books.ToList();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id) {
            try
            {
                var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();

                Console.WriteLine(book?.Title);    

                if(book is null) return NotFound();

                return Ok(book);


            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            
            
   
        
        }


        [HttpPost]
        public IActionResult CreateOneBook( [FromBody] Book book   ) {

            try
            {   
                if(book is null) return BadRequest();

                _context.Books.Add(book);
                _context.SaveChanges();

                return StatusCode(201, book);



            }catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }




        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book) {

            try
            {
                var entity = _context.Books.Where(b => b.Id.Equals(id)).SingleOrDefault();
                if(entity is null) return NotFound();

                if(id != book.Id) return BadRequest();

                entity.Title = book.Title;
                entity.Price = book.Price;

                _context.SaveChanges();

                return Ok(book);





            } catch (Exception ex) {

                throw new Exception(ex.Message);        
                }
        
        
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name ="id")]int id)
        {
            try
            {
                var entity = _context.Books.Where(b => b.Id.Equals(id)).SingleOrDefault();

                if(entity is null) return NotFound(new {
                    StatusCode = 404,
                    message = $"Book{id} not found."
                });

                _context.Books.Remove(entity);

                _context.SaveChanges();

                return NoContent();




            }catch (Exception ex) {
                throw new Exception(ex.Message);
            
            }

        }

    }
}
