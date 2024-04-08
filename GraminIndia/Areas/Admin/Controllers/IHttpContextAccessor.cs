using System.Web;

namespace GraminIndia.Areas.Admin.Controllers
{
    public interface IHttpContextAccessor
    {
        HttpContext HttpContext { get; }
    }
}