using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Simple.Models;
using Simple.Services;

namespace Simple.Controllers
{
    public class MyControllers : ControllerBase
    {
        public MyControllers(MyService service) => Service = service ?? throw new System.ArgumentNullException(nameof(service));
        public MyService Service { get; }

        public async Task<ActionResult<IReadOnlyList<MyEntity>>> GetAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<MyEntity> result = await Service.GetMyEntities(cancellationToken);
            return Ok(result);
        }

        public ActionResult<IEnumerable<MyEntity>> GetFakeEntites() => Service.GetMyFakeEntities();
    }
}