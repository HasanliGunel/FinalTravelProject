using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class AdvantageUpdateDto
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }

        public static Advantage ToAdvantage(AdvantageUpdateDto dto)
        {
            Advantage advantage = new Advantage()
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                IconName = dto.IconName,
            };

            return advantage;
        }
    }
}
