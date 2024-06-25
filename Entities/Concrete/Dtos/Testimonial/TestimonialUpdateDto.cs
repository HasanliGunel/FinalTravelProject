using Entities.Concrete.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class TestimonialUpdateDto
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Comment { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHome { get; set; }

        public static Testimonial ToTestimonial (TestimonialUpdateDto dto)
        {
            Testimonial testimonial = new Testimonial()
            {
                ID = dto.ID,
                Name = dto.Name,
                Comment = dto.Comment,
                PhotoUrl = dto.PhotoUrl,
                IsHome = dto.IsHome,    
            };

            return testimonial;
        }
    }
}
