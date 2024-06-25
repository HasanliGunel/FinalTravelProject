using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModel
{
    public class Testimonial:BaseEntity
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public string PhotoUrl {  get; set; }
        public bool IsHome {  get; set; }

    }
}
