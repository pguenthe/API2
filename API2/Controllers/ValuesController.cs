using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API2.Models;
using System.Web.Http.Results;

namespace API2.Controllers
{
    public class ValuesController : ApiController
    {
        static int hits = 0;
        // GET api/values/5
        public int GetCounter()
        {
            hits++;
            return hits;
        }

        public Card GetCard()
        {
            Card c = new Card();
            c.Suit = "Hearts";
            c.Value = "Queen";

            return c;
        }

        public List<Product> GetCatalog()
        {
            NorthwindEntities db = new NorthwindEntities();
            List<Product> products = db.Products.ToList();

            return products;
        }

        public Product GetProduct(int id)
        {
            NorthwindEntities db = new NorthwindEntities();
            Product prod = (from p in db.Products
                            where p.ProductID == id
                            select p).Single();

            return prod;
        }

        public List<Product> GetProductByName(string id)
        {
            NorthwindEntities db = new NorthwindEntities();
            List<Product> prod = (from p in db.Products
                            where p.ProductName.Contains(id)
                            select p).ToList();

            return prod;
        }

    }
}
