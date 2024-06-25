using Core.Entities.Abstract;

namespace Entities.Concrete.TableModel
{
    public class Advantage : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }

    }
}
