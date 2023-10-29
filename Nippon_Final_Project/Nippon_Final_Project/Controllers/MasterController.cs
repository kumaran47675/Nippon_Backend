using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nippon_Final_Project.Models;

namespace Nippon_Final_Project.Controllers
{
    [ApiController]
    [EnableCors("corspolicy")]
    public class MasterController : ControllerBase
    {
        private TintingRecordsContext trc;
        public MasterController(TintingRecordsContext trc)
        {
            this.trc = trc;
        }

        [HttpGet]
        [Route("api/login/get/{UserId}")]
        public List<MasterPage> GetUserId(string UserId)
        {

            if (UserId != null)
            {
                var records = trc.MasterPages.Where(x => x.UserId == int.Parse(UserId)).Select(x => new MasterPage()
                {
                     UserId = x.UserId,
                     UserName= x.UserName,
                     Depot=x.Depot
                }).ToList();
                return records;
            }
            return null;


        }
    }

   
}
