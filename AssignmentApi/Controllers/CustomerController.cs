using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AssignmentApi.Models;

namespace AssignmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerDataContext db = new CustomerDataContext();

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return db.Customer;
        }

        // GET: api/Customer/5
        [HttpGet]
        [Route("Id/{id}")]
        public Customer Get(int id)
        {
            return db.Customer.Find(id);

        }
        [HttpGet]
        [Route("City/{name}")]
        public IEnumerable<Customer> GetCity(string name)
        {
            return db.Customer.Where(c=>c.City==name).ToList();

        }

        // POST: api/Customer
        [HttpPost]
        [Route("Add")]
        public void Post(Customer value)
        {
            db.Customer.Add(value);
            db.SaveChanges();
        }

        // PUT: api/Customer/5
        [HttpPut]
        [Route("update/{id}")]
        public void Put(int id)
        {
            Customer c = db.Customer.Find(id);
            c.City = "Hyd";
            db.Customer.Update(c);
            db.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            Customer c = db.Customer.Find(id);
            db.Remove(c);
            db.SaveChanges();
        }
    }
}
