using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Simple.Models;
using Simple.Services;

namespace Simple.Controllers
{
    public class MyControllers : ControllerBase
    {
        public MyControllers(
            //MyGenericService<MyService> myGenericService,
            MyService service,
            IServiceProvider provider)
        {
            //MyGenericService = myGenericService ?? throw new ArgumentNullException(nameof(myGenericService));
            Service = service ?? throw new System.ArgumentNullException(nameof(service));
            _service = provider.GetRequiredService<MyService>();
        }

        //public MyGenericService<MyService> MyGenericService { get; }
        public MyService Service { get; }

        private readonly MyService _service;

        public async Task<ActionResult<IEnumerable<MyEntity>>> GetDataAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<MyEntity> result = await Service.GetMyEntities(cancellationToken);
            return Ok(result);
        }

        [HttpGet(nameof(GetFakeData))]
        public ActionResult<IEnumerable<MyEntity>> GetFakeData(/*[FromServices]MyService service*/)
        {
            IEnumerable<MyEntity> result = Service.GetMyFakeEntities();
            IEnumerable<MyEntity> resultWithServiceLocator = _service.GetMyFakeEntities();
            return Ok(result);
        }
    }
}
