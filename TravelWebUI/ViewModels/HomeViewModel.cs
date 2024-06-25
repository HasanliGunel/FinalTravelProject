using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;

namespace TravelWebUI.ViewModels
{
    public class HomeViewModel
    {
        public List<About> Abouts { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<Testimonial> Testimonials { get; set;}
        public List<Advantage> Advantages { get; set; }
        public List<Service> Services { get; set; }
        public List<PackageDto> Packages { get; set; }
        public List<Guide> Guides { get; set; }
        public List<BlogDto> Blogs { get; set; }
    }
}
