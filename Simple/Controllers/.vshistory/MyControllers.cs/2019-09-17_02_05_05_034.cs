using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
        public async Task<OkObjectResult> GetAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Models.MyEntity> result = await Service.GetMyEntities();
            return Ok(result);
        }
    }
}
