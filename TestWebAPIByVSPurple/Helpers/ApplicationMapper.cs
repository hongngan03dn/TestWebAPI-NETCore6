using AutoMapper;
using TestWebAPIByVSPurple.Entities;
using TestWebAPIByVSPurple.Models;

namespace TestWebAPIByVSPurple.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            //Map from Cate to CateModel and Reverse
            CreateMap<Category, CategoryModel>().ReverseMap();
        }
    }
}
