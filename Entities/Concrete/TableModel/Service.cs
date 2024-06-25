using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModel
{
    public class Service:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }
        public bool IsHomePage {  get; set; }
    }
}
