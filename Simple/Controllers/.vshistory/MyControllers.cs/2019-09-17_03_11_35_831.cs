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

        public MyControllers(
            MyService service,
            IServiceProvider provider,
            MyGenericService<MyService> myGenericService)
        {
            Service = service ?? throw new System.ArgumentNullException(nameof(service));
            MyGenericService = myGenericService ?? throw new ArgumentNullException(nameof(myGenericService));
            _service = provider.GetRequiredService<MyService>();
        }

        public MyService Service { get; }
        public MyGenericService<MyService> MyGenericService { get; }

        private readonly MyService _service;

        //public async Task<ActionResult<IEnumerable<MyEntity>>> GetDataAsync(CancellationToken cancellationToken = default)
        //{
        //    IEnumerable<MyEntity> result = await Service.GetMyEntities(cancellationToken);
        //    return Ok(result);
        //}

        [HttpGet(nameof(GetFakeData))]
        public ActionResult<IEnumerable<MyEntity>> GetFakeData(/*[FromServices]MyService service*/)
        {
            IEnumerable<MyEntity> result = Service.GetMyFakeEntities();
            IEnumerable<MyEntity> resultWithServiceLocator = _service.GetMyFakeEntities();
            return Ok(result);
        }
    }
}
