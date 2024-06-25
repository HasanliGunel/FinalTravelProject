using Core.DataAccess.Contrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataAccess.Concrete
{
    public class PackageDal : BaseRepository<Package, ApplicationDbContext>, IPackageDal
    {
        //ApplicationDbContext _context = new();

        private readonly ApplicationDbContext _context;
        public PackageDal(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<PackageDto> GetPackagesWithDestinations()
        {
            //var data = context.Packages
            //    .Where(x=>x.Deleted==0)
            //    .Include(x => x.Destination).ToList();

            //return data;

            var result = from package in _context.Packages
                         where package.Deleted == 0
                         join destination in _context.Destinations
                         on package.DestinationID equals destination.ID
                         where destination.Deleted == 0
                         select new PackageDto
                         {
                             ID = package.ID,
                             Name = package.Name,
                             Duration = package.Duration,
                             Price = package.Price,
                             PeopleCount = package.PeopleCount,
                             PhotoUrl = package.PhotoUrl,
                             IsHome = package.IsHome,
                             DestinationID = package.DestinationID,
                             DestinationName = destination.Name,
                         };
            return result.ToList();
        }
    }

}
