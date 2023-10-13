using Mamma.Mia.Pizzeria.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mamma.Mia.Pizzeria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Response<TResult>(Response<TResult> response) where TResult : new()
        {
            if (!response.IsSuccessfull)
                //{
                //    return BadRequest(response);
                //}
                return BadRequest(response);
            return Ok(response.Result);
        }

        protected IActionResult Response(Response response)
        {
            if (!response.IsSuccessfull)
                return BadRequest(response);
            return Ok();
        }
    }
}
