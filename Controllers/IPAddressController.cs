using Microsoft.AspNetCore.Mvc;

namespace IPAddressAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IPAddressController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetIPAddresses()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;

            var ipv4 = remoteIpAddress.MapToIPv4();
            var ipv6 = remoteIpAddress.MapToIPv6();

            return Ok(new
            {
                IPv4 = ipv4.ToString(),
                IPv6 = ipv6.ToString()
            });
        }
    }
}
