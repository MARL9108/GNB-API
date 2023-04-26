using AutoMapper;
using GNB_Data.Data;
using GNB_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Service.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Rate, RateDTO>()
                    .ForMember(d => d.Rate, opt => opt.MapFrom(src => src.RateValue))
                    .ForMember(d => d.From, opt => opt.MapFrom(src => src.From))
                    .ForMember(d => d.To, opt => opt.MapFrom(src => src.To));
            CreateMap<Transaction, TransactionDTO>()
                     .ForMember(d => d.Sku, opt => opt.MapFrom(src => src.Sku))
                     .ForMember(d => d.Currency, opt => opt.MapFrom(src => src.Currency))
                     .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount));
        }
    }
}
