using Core;
using Core.Seguridad.Cifrado;
using DR.ManagmentSales.Application;
using DR.ManagmentSales.Application.Interfaces;
using DR.ManagmentSales.Domain;
using DR.ManagmentSales.Infrastructure;
using DR.ManagmentSales.Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DR.ManagmentSales.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class InitController : Controller
    {
        

       
    }
}
