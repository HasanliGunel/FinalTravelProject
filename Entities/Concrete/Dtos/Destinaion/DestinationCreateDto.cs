using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class DestinationCreateDto
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHomePage { get; set; }

        public static Destination ToDestination(DestinationCreateDto dto)
        {
            Destination destination = new Destination() 
            {
                Name = dto.Name,
                PhotoUrl = dto.PhotoUrl,
                IsHomePage = dto.IsHomePage,
            };

            return destination;
        }
    }
}
