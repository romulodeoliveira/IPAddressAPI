using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Sockets;

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
            
            if (remoteIpAddress.AddressFamily == AddressFamily.InterNetworkV6 &&
                ipv6.IsIPv4MappedToIPv6)
            {
                ipv6 = ipv6.MapToIPv4();
            }

            var accessDate = DateTime.Now;

            return Ok(new
            {
                IPv4 = ipv4.ToString(),
                IPv6 = ipv6.ToString(),
                AccessDate = accessDate.ToString()
            });
        }
    }
}
