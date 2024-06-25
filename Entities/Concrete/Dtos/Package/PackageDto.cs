using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class PackageDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DestinationID { get; set; }
        public byte Duration { get; set; }
        public decimal Price { get; set; }
        public int PeopleCount { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHome { get; set; }
        public string DestinationName { get; set; }
    }
}
