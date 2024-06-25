using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class TagUpdateDto
    {
        public int ID { get; set; } 
        public string Name { get; set; }

        public static Tag ToTag(TagUpdateDto dto)
        {
            Tag tag = new Tag()
            {
                ID = dto.ID,
                Name = dto.Name,
            };

            return tag;
        }
    }
}
