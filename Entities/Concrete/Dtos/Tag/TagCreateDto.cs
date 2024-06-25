using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class TagCreateDto
    {
        public string Name { get; set; }

        public static Tag ToTag(TagCreateDto dto)
        {
            Tag tag = new Tag()
            {
                Name = dto.Name,
            };

            return tag;
        }
    }
}
