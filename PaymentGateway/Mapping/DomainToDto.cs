using AutoMapper;
using Entities.Model;
using PaymentGateway.ApiDto;

namespace PaymentGateway.Mapping
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            string maskcardnumber = "################";



            CreateMap<PaymentDetails, PaymentDetailsdto>()
                .ForMember(
                    dest => dest.cardnumber,
                    opt => opt.MapFrom(src => maskcardnumber))
                .ForMember(
                dest => dest.Id,

                opt => opt.MapFrom(src => src.PaymentID));


            CreateMap<Card, PaymentDetails>();

            CreateMap<Carddto, Card>();


        }
    }
}
