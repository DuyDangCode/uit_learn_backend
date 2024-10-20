using Microsoft.AspNetCore.Mvc;
using uit_learn_backend.Dbs;

namespace uit_learn_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController : ControllerBase
    {
        public SubjectsController(IMongoDbService service)
        {
        }

    }
}
