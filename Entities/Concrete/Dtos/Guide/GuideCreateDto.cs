using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class GuideCreateDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhotoUrl { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        public bool IsHome { get; set; }


        public static Guide ToGuide(GuideCreateDto dto)
        {
            Guide guide = new Guide()
            {
                Name = dto.Name,
                SurName = dto.SurName,
                PhotoUrl = dto.PhotoUrl,
                InstagramLink = dto.InstagramLink,
                FacebookLink = dto.FacebookLink,
                TwitterLink = dto.TwitterLink,
                LinkedInLink = dto.LinkedInLink,
                IsHome = dto.IsHome,
            };

            return guide;
        }
    }
}
