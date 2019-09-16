using System.Collections.Generic;
using System.Threading;

using Microsoft.AspNetCore.Mvc;

using Simple.Services;

namespace Simple.Controllers
{
    [ApiController, Route("[controller]")]
    public class MyControllers : ControllerBase
    {
        public MyControllers(MyService service) => Service = service ?? throw new System.ArgumentNullException(nameof(service));
        public MyService Service { get; }

        [HttpGet]
        public IAsyncEnumerable<MyEntity> GetAsync(CancellationToken cancellationToken = default)
        {
            return Service.GetMyEntities();
        }
    }
}
