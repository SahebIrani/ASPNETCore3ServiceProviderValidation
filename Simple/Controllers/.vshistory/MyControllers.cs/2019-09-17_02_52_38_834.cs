using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Simple.Models;
using Simple.Services;

namespace Simple.Controllers
{
    public class MyControllers : ControllerBase
    {

        public MyControllers(MyService service, IServiceProvider provider)
        {
            Service = service ?? throw new System.ArgumentNullException(nameof(service));
            _service = provider.GetRequiredService<MyService>();
        }

        public MyService Service { get; }
        private readonly MyService _service;

        //public async Task<ActionResult<IEnumerable<MyEntity>>> GetDataAsync(CancellationToken cancellationToken = default)
        //{
        //    IEnumerable<MyEntity> result = await Service.GetMyEntities(cancellationToken);
        //    return Ok(result);
        //}

        [HttpGet(nameof(GetFakeData))]
        public ActionResult<IEnumerable<MyEntity>> GetFakeData(/*[FromServices]MyService service*/)
        {
            IEnumerable<MyEntity> resultWithServiceLocator = Service.GetMyFakeEntities();
            IEnumerable<MyEntity> result = Service.GetMyFakeEntities();
            return Ok(result);
        }
    }
}
