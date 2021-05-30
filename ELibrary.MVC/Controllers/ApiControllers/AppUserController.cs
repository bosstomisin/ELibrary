
using ELibrary.Dtos.Automapper;

namespace ELibrary.MVC.Controllers.ApiControllers
{
 
    public class AppUserController : BaseApiController
    {
        private readonly MappingProfile _mapper;
        public AppUserController(MappingProfile mapper)
        {
            _mapper = mapper;
        }
    }
}
