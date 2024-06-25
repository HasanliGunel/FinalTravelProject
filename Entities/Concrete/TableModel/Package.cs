using Core.Entities.Abstract;

namespace Entities.Concrete.TableModel
{
    public class Package:BaseEntity
    {
        public string Name { get; set; }  
        public int DestinationID { get; set; }
        public byte Duration { get; set; }
        public decimal Price { get; set; }
        public int PeopleCount { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHome {  get; set; }
        public virtual Destination Destination { get; set; }    
    }
}
