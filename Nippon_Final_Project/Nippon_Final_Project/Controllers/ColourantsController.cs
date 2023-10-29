using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Nippon_Final_Project.Models;

namespace Nippon_Final_Project.Controllers
{
    [ApiController]
    [EnableCors("corspolicy")]
    public class ColourantsController : ControllerBase
    {
        private TintingRecordsContext trc;
        private IMemoryCache _memoryCache;
        public ColourantsController(TintingRecordsContext trc, IMemoryCache memoryCache)
        {
            this.trc = trc;
            this._memoryCache = memoryCache;
        }

        [HttpPost]
        [Route("api/colourants/post")]
        public async void AddContact([FromBody] ColourantsRequest colourants)
        {

            string requestNumber = GenerateRequestNumber();

            Colourant ob = new Colourant
            {
               
                Colourants = colourants.Colourants,
                BatchNo = colourants.BatchNo,
                Quantity = colourants.Quantity,
                DispensingMachine = colourants.DispensingMachine,
                Status = 1,
                Date = colourants.Date,
                Mfg = colourants.Mfg,
                RequestId = requestNumber,
                EntryDate=DateTimeOffset.Now
            };
            trc.Colourants.Add(ob);
            trc.SaveChanges();
        }


        private string GenerateRequestNumber()
        {
            if (!_memoryCache.TryGetValue<DateTime>("LastRequestDate", out var lastRequestDate))
            {
                lastRequestDate = DateTime.MinValue;
            }

            if (lastRequestDate.Date != DateTime.Now.Date)
            {
                // If the date has changed, reset the number
                lastRequestDate = DateTime.Now.Date;
                _memoryCache.Set("LastRequestDate", lastRequestDate);
                _memoryCache.Set("LastRequestNumber", 0);
            }

            var lastRequestNumber = _memoryCache.Get<int>("LastRequestNumber") + 1;
            _memoryCache.Set("LastRequestNumber", lastRequestNumber);

            if (lastRequestNumber <= 999)
            {
                return $"{lastRequestDate.ToString("ddMMyy")}{lastRequestNumber:D3}";
            }
            else if (lastRequestNumber >= 1000 && lastRequestNumber <= 9999)
            {
                return $"{lastRequestDate.ToString("ddMMyy")}{lastRequestNumber:D4}";
            }
            else if (lastRequestNumber >= 10000 && lastRequestNumber <= 99999)
            {
                return $"{lastRequestDate.ToString("ddMMyy")}{lastRequestNumber:D5}";
            }
            else
            {
                return $"{lastRequestDate.ToString("ddMMyy")}{lastRequestNumber:D6}";
            };
        }




    }
}
