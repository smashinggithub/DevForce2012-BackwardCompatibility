using System.Collections.Generic;
using System.Linq;
using IdeaBlade.EntityModel;
using ClientUIDataApp2.DomainModel;

namespace ClientUIDataApp2.ModelServices
{
    /// <summary>
    /// Represents the Employees repository class for sample purpose.
    /// </summary>
    public class EmployeesRepository : DataRepository<Employee>
    {
        private static IDataRepository _repository;

        /// <summary>
        /// Initializes a new instance of <see cref="EmployeesRepository"/> class.
        /// </summary>
        /// <param name="context">A <see cref="DomainContext"/> instance, providing access to all functionality of the data service.</param>
        public EmployeesRepository(EntityManager context)
            : base(context)
        {
        }

        private static bool IsReusable
        {
            get { return true; }
        }

        private NorthwindEntities EntityContext
        {
            get
            {
                return ((NorthwindEntities)this.Context);
            }
        }

        /// <summary>
        /// Returns an instance of <see cref="EmployeesRepository"/>. 
        /// If the <see cref="IsReusable"/> is true, the property will return an existing cached copy of the instance.
        /// </summary>
        public static IDataRepository Instance
        {
            get
            {
                if (_repository == null || !IsReusable)
                    _repository = new EmployeesRepository(RepositoryManager.Create());

                return _repository;
            }
        }

        /// <summary>
        /// Gets the <see cref="EntitySet"/> that provides access to a collection of entities as the results of the entity query.
        /// </summary>
        public override List<Employee> EntitySet
        {
            get
            {
                return this.EntityQuery.ToList();
            }
        }

        /// <summary>
        /// Gets the <see cref="EntityQuery"/> that represents the entity's LINQ query.
        /// </summary>
        public override EntityQuery<Employee> EntityQuery
        {
            get
            {
                return this.EntityContext.Employees;
            }
        }
    }
}
