using Entities.Concrete.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class GuideUpdateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhotoUrl { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        public bool IsHome { get; set; }


        public static Guide ToGuide (GuideUpdateDto dto)
        {
            Guide guide = new Guide()
            {
                ID = dto.ID,
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
