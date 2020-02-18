using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        PracticeDBContext db = new PracticeDBContext();
        //[HttpGet]
        ////get all product records
        //public List<Product16> GetAll()
        //{
        //    return db.Product16.ToList();
        //}
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product16> Get()
        {

            return db.Product16;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        [Route("GetById/{id}")]
        public Product16 Get(int id)
        {
            return db.Product16.Find(id);
        }
        [HttpGet("{name}")]
        [Route("GetByName/{names}")]
        public Product16 GetByName(string names)
        {
            return db.Product16.SingleOrDefault(p => p.Name == names);
        }
        [HttpPost]
        [Route("Add")]
        public void Add(Product16 item)
        {
            db.Product16.Add(item);
            db.SaveChanges();
        }
        

        // POST: api/Product
        
        //public Product16 Add([FromBody]Product16 product16)
        //{
        //    return db.Add(product16);
        //}
        //public string Post(object value)
        //{
        //    return "response added";
        //}

        // PUT: api/Product/5
        [HttpPut]
        [Route("update/{id}")]
        public void Put(int id)
        {
            Product16 p = db.Product16.Find(id);
            p.Stock = 3;
            db.Product16.Update(p);
            db.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            Product16 p = db.Product16.Find(id);
            db.Remove(p);
            db.SaveChanges();
        }

    }
}
