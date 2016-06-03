using System.Web.Http;
using BasicAuthHttpModule.Models;

public class AuthenticationController : ApiController
{
    [Route("authenticate")]
    public IHttpActionResult Authenticate(AuthenticateViewModel viewModel)
    {
        /* REPLACE THIS WITH REAL AUTHENTICATION
        ----------------------------------------------*/
        if (!(viewModel.Username == "test" && viewModel.Password == "test"))
        {
            return Ok(new {success = false, message = "User code or password is incorrect"});
        }

        return Ok(new {success = true});
    }
}