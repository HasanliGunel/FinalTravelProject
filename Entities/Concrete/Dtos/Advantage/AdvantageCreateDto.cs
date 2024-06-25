using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class AdvantageCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }

        public static Advantage ToAdvantage(AdvantageCreateDto dto)
        {
            Advantage advantage = new Advantage()
            {
                Name = dto.Name,
                Description = dto.Description,
                IconName = dto.IconName,
            };

            return advantage;
        }
    }
}
