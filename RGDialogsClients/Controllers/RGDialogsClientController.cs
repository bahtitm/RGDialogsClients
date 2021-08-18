using GetDialog.Entitties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetDialog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RGDialogsClientController : ControllerBase
    {


        private readonly ILogger<RGDialogsClientController> _logger;
        private List<RGDialogsClients> _rgDialogsClients;

        public RGDialogsClientController(ILogger<RGDialogsClientController> logger)
        {
            _logger = logger;
            var rgDialogsClients = new RGDialogsClients();
            _rgDialogsClients = rgDialogsClients.Init();
        }

        [HttpPost]
        public Guid GetDialog(IEnumerable<Guid> idClients)
        {
            var result = idClients.Where(p => _rgDialogsClients.Any(a => a.IDClient.Equals(p)));
            if (result != null)
            {
                return result.FirstOrDefault();
            }


            return Guid.Empty;
        }
    }
}
