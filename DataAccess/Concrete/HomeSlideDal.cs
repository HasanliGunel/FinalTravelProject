using Core.DataAccess.Contrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.TableModel;

namespace DataAccess.Concrete
{
    public class HomeSlideDal : BaseRepository<HomeSlide, ApplicationDbContext>, IHomeSlideDal
    {
    }

}
