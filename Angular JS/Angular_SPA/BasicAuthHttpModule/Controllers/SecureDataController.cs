using System.Web.Http;

[Authorize]
public class SecureDataController : ApiController
{
    public IHttpActionResult Get()
    {
        return Ok(new {secureData = "You have to be authenticated to access this!"});
    }
}