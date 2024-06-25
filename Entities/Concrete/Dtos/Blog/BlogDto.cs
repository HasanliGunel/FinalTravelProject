using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class BlogDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string Text { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryOfBlogID { get; set; }
        public string CategotyOfBlogName { get; set; } 
    }
}
