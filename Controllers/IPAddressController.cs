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
                using (var httpClient = new HttpClient())
                {
                    var ipv6Address = httpClient.GetStringAsync("https://ipv6.icanhazip.com/").Result;
                    var ipv4 = HttpContext.Connection.RemoteIpAddress?.MapToIPv4()?.ToString();

                    var result = new
                    {
                        IPv4 = ipv4,
                        IPv6 = ipv6Address.Trim(),
                        AccessDate = accessDate.ToString()
                    };

                    return Ok(result);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro ao fazer a solicitação HTTP: {ex.Message}");

                var ipv4 = HttpContext.Connection.RemoteIpAddress?.MapToIPv4()?.ToString();

                var result = new
                {
                    IPv4 = ipv4,
                    IPv6 = (string)null,
                    AccessDate = accessDate.ToString()
                };

                return Ok(result);
            }
        }
    }
}
