using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Repositories
{
    /// <summary>
    /// It contains all repositories. By this way, we don't need to inject each repository wherever we want to use it, 
    /// but will just access it from the unit of work. Also we will manage transactions calling the saveAsync method inside this class.
    /// </summary>
    public interface IUnitOfWork
    {
        IDemandsRepository DemandsRepository { get; }
        ICategoriesRepository CategoriesRepository { get; }
        IProductTypesRepository ProductTypesRepository { get; }
        IAttributesRepository AttributesRepository { get; }

        // We don't need SaveChangesAsync because using aggregates we save all changes of one aggregate at once. 
        // If the changes done over one aggregate requires changing something on a different aggregate we will publish
        // an event.
        //Task<int> SaveChangesAsync();
    }
}
