
using DTO.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace identityService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    //[EnableCors("MyCorsPolicyCustomable")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {

        protected async Task<ObjectResult> GetReponseAnswer(object response)
        {
            return await Task.Run(
                () =>
                {
                    return new ObjectResult(new HttpResponseDto { Data = response })
                    { StatusCode = (int)HttpStatusCode.OK };
                });
        }

    }
}
