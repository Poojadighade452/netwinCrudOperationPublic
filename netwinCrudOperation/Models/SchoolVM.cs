using static netwinCrudOperation.Models.SchoolModel;

namespace netwinCrudOperation.Models
{
    public class SchoolVM
    {
        public ICollection<School> Schools { get; set; }
        public School SchoolObj { get; set; }

    }
}
