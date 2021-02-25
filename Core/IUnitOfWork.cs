using System.Threading.Tasks;

namespace COREMES.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}