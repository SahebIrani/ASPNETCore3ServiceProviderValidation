using System.Collections.Generic;
using System.Threading;

using Simple.Data;
using Simple.Models;

namespace Simple.Services
{
    public class MyService
    {
        public MyService(ApplicationDbContext context) => Context = context ?? throw new System.ArgumentNullException(nameof(context));
        public ApplicationDbContext Context { get; }

        public IAsyncEnumerable<MyEntity> GetMyEntities(CancellationToken cancellationToken = default)
        {


        }
    }
}
