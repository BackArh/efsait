using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EfSait.API.Controllers;
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/[controller]")]
[EnableCors("MyPolicy")]
public class ApiBaseController: ControllerBase
{
    
}