using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Simple.Data;
using Simple.Models;

namespace Simple.Services
{
    public class MyDataService
    {
        public IList<MyEntity> Initial()
        {
            IList<MyEntity> result = new List<MyEntity>
            {
                new MyEntity{ Id = 1 , FullName = "Sinjul MSBH" , Age = 27 },
                new MyEntity{ Id = 2 , FullName = "JackSlater" , Age = 26 },
            };

            return result;
        }
    }
    public class MyService
    {
        public MyService(ApplicationDbContext context) => Context = context ?? throw new System.ArgumentNullException(nameof(context));
        public ApplicationDbContext Context { get; }

        public async Task MyInitialDataService(CancellationToken cancellationToken = default)
        {
            IList<MyEntity> entites = new List<MyEntity>
            {
                new MyEntity{ Id = 1 , FullName = "Sinjul MSBH" , Age = 27 },
                new MyEntity{ Id = 2 , FullName = "JackSlater" , Age = 26 },
            };

            await Context.Set<MyEntity>().AddRangeAsync(entites, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<MyEntity>> GetMyEntities(CancellationToken cancellationToken = default)
        {
            await MyInitialDataService(cancellationToken);

            IReadOnlyList<MyEntity> result = await Context.Set<MyEntity>().AsNoTracking().ToListAsync(cancellationToken);

            return result.Count > 0 ? result : throw new SqlNullValueException();
        }
    }
}
