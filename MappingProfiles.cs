using AutoMapper;
using Capital.DTOs;
using Capital.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Capital
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Question, QuestionDTO>().ReverseMap();
            // Add more mappings for other models and DTOs as needed
        }
    }
}
