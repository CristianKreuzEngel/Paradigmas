using ApiWebDB.BaseDados.Models2;
using ApiWebDB.DTO;
using AutoMapper;
using TrabalhoFinal.Services;

namespace Trabalho_Final.Services.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<TbProduct, ProductDTO>();
            CreateMap<TbPromotion, PromotionDTO>();
            CreateMap<TbSale, SaleDTO>();
            CreateMap<TbStockLog, StockLogDTO>();
            CreateMap<SaleReportDTO, SaleDTO>();
        }
    }
}