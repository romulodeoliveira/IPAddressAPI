using Microsoft.AspNetCore.Mvc;

namespace IPAddressAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IPAddressController : ControllerBase
    {
        [HttpGet("GetIPAddresses")]
        public IActionResult GetIPAddresses()
        {
            var accessDate = DateTime.Now;

            try
            {
                var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;
                var ipv4 = remoteIpAddress.MapToIPv4();
                var ipv6 = remoteIpAddress.MapToIPv6();

                var result = new
                {
                    IPv4 = ipv4.ToString(),
                    IPv6 = ipv6.ToString(),
                    AccessDate = accessDate.ToString()
                };

                return Ok(result);
            }
            catch (HttpRequestException error)
            {
                return StatusCode(500, $"Ops... Não conseguimos verificar seu ip.\nDetalhe do erro: {error.Message}");
            }
        }
    }
}
