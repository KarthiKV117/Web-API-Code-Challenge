using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPX.Models
{
    public class ProductVM
    {
        public Product product { get; set; }

        public Review review { get; set; }

        public List<Review> reviewList { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Brand { get; set; }
        public string Product_Id { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public string Reviews_Id { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
        public string User { get; set; }

        public virtual Product Product { get; set; }
    }
}