using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class PackageCreateDto
    {
        public string Name { get; set; }  
        public int DestinationID { get; set; }
        public byte Duration { get; set; }
        public decimal Price { get; set; }
        public int PeopleCount { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHome {  get; set; }

        public static Package ToPackage( PackageCreateDto dto)
        {
            Package package = new Package() 
            {
                Name = dto.Name,
                DestinationID = dto.DestinationID,
                Duration = dto.Duration,
                Price = dto.Price,
                PeopleCount = dto.PeopleCount,
                PhotoUrl = dto.PhotoUrl,
                IsHome = dto.IsHome,
            };
            return package;
        }
    }
}
