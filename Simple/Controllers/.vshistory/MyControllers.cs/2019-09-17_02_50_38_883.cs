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

        [HttpGet(nameof(GetFakeData))]
        public ActionResult<IEnumerable<MyEntity>> GetFakeData(/*[FromServices]MyService service*/)
        {
            IEnumerable<MyEntity> result = Service.GetMyFakeEntities();
            return Ok(result);
        }
    }
}
