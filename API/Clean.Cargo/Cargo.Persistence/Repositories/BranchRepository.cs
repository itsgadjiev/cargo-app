using Cargo.Application.Contracts.Percistance;
using Cargo.Domain;
using Cargo.Persistence.Context;

namespace Cargo.Persistence.Repositories
{
    public class BranchRepository : GenericRepository<Branch>,IBranchRepository
    {
        public BranchRepository(AppDbContext context) : base(context)
        {
        }
    }
}
