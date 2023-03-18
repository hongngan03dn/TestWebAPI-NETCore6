using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWebAPIByVSPurple.Models;

namespace TestWebAPIByVSPurple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>(); 

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if(hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hangHoa = new HangHoa
            {
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia,
                MaHangHoa = Guid.NewGuid(),
            };
            hangHoas.Add(hangHoa);

            return Ok(new {
                Success = true, Data = hangHoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, HangHoaVM hangHoaVM)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if(hangHoa == null)
                {
                    return NotFound();
                }
                //update
                hangHoa.TenHangHoa = hangHoaVM.TenHangHoa;
                hangHoa.DonGia = hangHoaVM.DonGia;

                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if(hangHoa == null)
                {
                    return NotFound();
                }
                //update
                hangHoas.Remove(hangHoa);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}