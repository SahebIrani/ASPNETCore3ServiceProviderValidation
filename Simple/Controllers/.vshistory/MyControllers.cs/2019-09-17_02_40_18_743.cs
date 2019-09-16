using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Simple.Models;
using Simple.Services;

namespace Simple.Controllers
{
    public class MyControllers : ControllerBase
    {
        public MyControllers(MyService service) => Service = service ?? throw new System.ArgumentNullException(nameof(service));
        public MyService Service { get; }

        //public async Task<ActionResult<IEnumerable<MyEntity>>> GetDataAsync(CancellationToken cancellationToken = default)
        //{
        //    IEnumerable<MyEntity> result = await Service.GetMyEntities(cancellationToken);
        //    return Ok(result);
        //}

        public ActionResult<IEnumerable<MyEntity>> GetFakeData()
        {
            IEnumerable<MyEntity> result = Service.GetMyFakeEntities();
            return Ok(result);
        }
    }
}
