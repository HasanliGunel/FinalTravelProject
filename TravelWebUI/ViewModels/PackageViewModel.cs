using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;

namespace TravelWebUI.ViewModels
{
    public class PackageViewModel
    {
        public List<PackageDto> Packages { get; set; }
        public List<Destination> Destinations { get; set; }
    }
}
