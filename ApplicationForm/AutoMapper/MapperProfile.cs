using AutoMapper;
using DTOs.DataTransferObjects;
using Entities.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ApplicationForm.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Answer, AnswerDto>().ReverseMap();

            CreateMap<Answer, CreateAnswerDto>().ReverseMap();

            CreateMap<Question, QuestionDto>().ReverseMap();

            CreateMap<Question, QuestionCreateDto>().ReverseMap();

            CreateMap<Applicant, ApplicantDto>().ReverseMap();

            CreateMap<Applicant, CreateApplicantDto>().ReverseMap();
        }
    }
}
