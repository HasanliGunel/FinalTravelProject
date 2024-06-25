using Core.Entities.Abstract;

namespace Entities.Concrete.TableModel
{
    public class Destination:BaseEntity
    {
        public Destination() 
        {
            Packages = new HashSet<Package>();
        }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHomePage {  get; set; }   
        public ICollection<Package> Packages { get; set; }
        
    }
}
