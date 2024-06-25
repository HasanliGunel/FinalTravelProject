using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class DestinationDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHomePage { get; set; }

        public static Destination ToDestination(DestinationUpdateDto dto)
        {
            Destination destination = new Destination()
            {
                ID = dto.ID,
                Name = dto.Name,
                PhotoUrl = dto.PhotoUrl,
                IsHomePage = dto.IsHomePage
            };
            return destination;
        }
    }
}
