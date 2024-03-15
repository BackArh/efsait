using EfSait.Entity.EmploeeDivision;
using EfSait.Service.ModelsRequest.EmploeeDivision;
using EfSait.Service.Services.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfSait.API.Controllers;


public class DivisionController : BaseController<Division,DivisionRequest, IDivisionService>
{
    public DivisionController(IDivisionService service) : base(service)
    {
    }
}