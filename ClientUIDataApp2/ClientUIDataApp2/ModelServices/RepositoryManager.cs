using ClientUIDataApp2.DomainModel;

namespace ClientUIDataApp2.ModelServices
{
    public class RepositoryManager
    {
        public static NorthwindEntities Create()
        {
            return new NorthwindEntities();
        }
    }
}
