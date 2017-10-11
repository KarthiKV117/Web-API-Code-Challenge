using SPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SPX.Controllers
{
    [CustomExceptionFilter]
    public class ProductsController : ApiController
    {
        OrderEntities context = new OrderEntities();
        ProductVM objProductVM = new ProductVM();
        // GET api/<controller>
        public IEnumerable<Product> Get()
        {
            IEnumerable<Product> product = context.Products;
            return context.Products;
        }

        // GET api/<controller>/5
        public List<ProductVM> Get(int id)
        {
            var lstReviews = from r in context.Reviews
                             join p in context.Products on r.Product_Id equals p.Product_Id into ps
                             from p in ps.DefaultIfEmpty()
                             where p.Product_Id == id
                             select new
                             {
                                 ProductName = p.Title,
                                 Description = p.ShortDescription,
                                 Brand = p.Brand,
                                 ProductID = p.Product_Id,
                                 Rating = r.Rating,
                                 Comment = r.Comment,
                                 User = r.User,
                                 Review_ID = r.Reviews_Id
                             };

            List<ProductVM> result = new List<ProductVM>();
            foreach (var review in lstReviews)
                result.Add(new ProductVM()
                {
                    Title = review.ProductName,
                    ShortDescription = review.Description,
                    Brand = review.Brand,
                    Rating = review.Rating.ToString(),
                    Comment = review.Comment,
                    User = review.User,
                    Reviews_Id = review.Review_ID.ToString(),
                    Product_Id = review.ProductID.ToString()
                });
            return result;

        }

        // POST api/<controller>

        public void Post([FromBody]List<string> value)
        {
            Review objReview = new Review();
            objReview.Reviews_Id = Convert.ToInt16(value[0].ToString());
            objReview.Rating = Convert.ToInt64(value[1].ToString());
            objReview.Comment = value[2].ToString();
            objReview.User = value[3].ToString();
            objReview.Product_Id = Convert.ToInt16(value[4].ToString());

            context.Reviews.Add(objReview);
            context.Entry(objReview).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]List<string> value)
        {
            Review objReview = new Review();
            objReview.Rating = Convert.ToInt64(value[0].ToString());
            objReview.Comment = value[1].ToString();
            objReview.User = value[2].ToString();
            objReview.Product_Id = id;

            context.Reviews.Add(objReview);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            Review obj = context.Reviews.Find(id);
            context.Reviews.Remove(obj);
            context.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}