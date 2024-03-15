using EfSait.Entity.EmploeeDivision;
using EfSait.Entity.UserActivity;
using EfSait.Service.ModelsRequest.EmploeeDivision;
using EfSait.Service.ModelsRequest.UserActivity;
using EfSait.Service.Services.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfSait.API.Controllers;


public class StaffController : BaseController<Staff,StaffRequest, IStaffService>
{
    public StaffController(IStaffService service) : base(service)
    {
    }
}