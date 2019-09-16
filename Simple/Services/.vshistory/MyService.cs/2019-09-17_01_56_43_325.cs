using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Simple.Data;
using Simple.Models;

namespace Simple.Services
{
    public class MyService
    {
        public MyService(ApplicationDbContext context) => Context = context ?? throw new System.ArgumentNullException(nameof(context));
        public ApplicationDbContext Context { get; }

        public async Task MyInitial(CancellationToken cancellationToken = default)
        {
            var entites = new List<MyEntity>
            {
                new MyEntity{ Id = 1 , FullName = "Sinjul MSBH" , Age = 27 },
                new MyEntity{ Id = 2 , FullName = "JackSlater" , Age = 26 },
            };

            await Context.Set<MyEntity>().AddRangeAsync(entites, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async IAsyncEnumerable<MyEntity> GetMyEntities(CancellationToken cancellationToken = default)
        {
            await MyInitial(cancellationToken);

            var result = Context.Set<MyEntity>().AsNoTracking().AsAsyncEnumerable();



        }
    }
}
