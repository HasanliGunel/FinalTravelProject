using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModel
{
    public class Guide:BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhotoUrl {  get; set; }   
        public string InstagramLink {  get; set; }  
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        public bool IsHome { get; set; }
    }
}
