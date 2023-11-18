using AutoMapper;
using webapicruddatabase.Dtos;
using webapicruddatabase.Models;

namespace webapicruddatabase.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books,BookDTO>().ReverseMap();
        }
    }
}
