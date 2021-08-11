using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Test.Models;

namespace Test.Controllers
{
    // Controller is the entry point of an API call
    // Think of each method like your static void main in a Console App
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _dbContext = ApplicationDbContext.Create();

        // This our API Response (IHttpActionResult is just HttpResponse)
        // 1. Status Code
        // 2. Body
        // 3. Headers
                                                   // Take in the object we are trying to create
                                                   // Attributes just alter behavior
        [HttpPost]                                 // Take the customer from the HTTP Request Body
        public async Task<IHttpActionResult> Create([FromBody] Customer customer)
        {
            // Validate our data
            if (customer == null)
            {
                // Status Code 400
                // This is another comment
                // Added another comment
                return BadRequest();
            }

            // Validate our data
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            // This "symbolically" adds the customer to the db - Like putting into list in Repository CRUD
            _dbContext.Customers.Add(customer);

            // This checks to make sure the customer was actually saved to the database
            // try to always use await if you can (not every method has an async version)
            if (!(await _dbContext.SaveChangesAsync() > 0))
            {
                return InternalServerError();
            }

            return Ok(customer);
        }

        // FindAsync - looks up any object by ID (primary key) in the DB
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            // DbSet
            // A code representation of the table ( a list )
            // This is no bueno - could be millions of objects
           Customer customer = await _dbContext.Customers.FindAsync(id);

            return Ok(customer);
        }

        /*
            public List<Badge> GetAll()
            {
               return _badges;
            }
        */
    }
}
