using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebAPIByVSPurple.Entities;
using TestWebAPIByVSPurple.Models;

namespace TestWebAPIByVSPurple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyShopContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(MyShopContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _context.Categories.ToList();
            return Ok(_mapper.Map<List<CategoryModel>>(categories));
        }
    }
}
