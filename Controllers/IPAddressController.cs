using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace IPAddressAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IPAddressController : ControllerBase
    {
        [HttpGet("GetIPAddresses")]
        public IActionResult GetIPAddresses()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;

            var ipv4 = remoteIpAddress.MapToIPv4();
            var ipv6 = remoteIpAddress.MapToIPv6();
            
            if (remoteIpAddress.AddressFamily == AddressFamily.InterNetwork)
            {
                ipv4 = remoteIpAddress;
            }
            else if (remoteIpAddress.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ipv6 = remoteIpAddress;
            }
            
            var accessDate = DateTime.Now;

            return Ok(new
            {
                IPv4 = ipv4.ToString(),
                IPv6 = ipv6.ToString(),
                AccessDate = accessDate.ToString()
            });
        }

        [HttpGet("GetServerInfo")]
        public IActionResult GetServerInfo()
        {
            var serverName = HttpContext.Request.Host.Host;
            var serverPort = HttpContext.Request.Host.Port;
            var clientIp = HttpContext.Connection.RemoteIpAddress;

            string ipv6String = clientIp.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6
                ? clientIp.ToString()
                : clientIp.MapToIPv6().ToString();

            return Ok(new
            {
                ServerName = serverName,
                ServerPort = serverPort,
                ClientIp = ipv6String
            });
        }
    }
}
