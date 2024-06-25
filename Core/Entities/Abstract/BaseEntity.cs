using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public class BaseEntity 
    {
        public int ID { get; set; }
        public int Deleted { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdateDate { get; set; }
    }
}
