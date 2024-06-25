using Entities.Concrete.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class HomeSlideCreateDto
    {
        public string Description { get; set; }
        public string PhotoUrl { get; set; }

        public static HomeSlide ToHomeSlide(HomeSlideCreateDto dto)
        {
            HomeSlide homeSlide = new HomeSlide()
            {
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
            };

            return homeSlide;
        }
    }
}
