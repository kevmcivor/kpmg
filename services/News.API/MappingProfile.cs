using AutoMapper;
using News.API.Models;
using News.Domain.Entities.ArticleAggregate;

namespace News.API
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, ArticleDto>();

            CreateMap<Article, ArticleDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Content.Title))
                .ForMember(dest => dest.Headline, opt => opt.MapFrom(src => src.Content.Headline))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Content.Body))
                .ForMember(dest => dest.ImageUri, opt => opt.MapFrom(src => src.Content.ImageUri))
                .ForMember(dest => dest.RatingAverage, opt => opt.Ignore());
            CreateMap<Content, ArticleDto>();

            CreateMap<ArticleCreateDto, Article>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Author, opt => opt.Ignore());

            CreateMap<ArticleUpdateDto, Article>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Author, opt => opt.Ignore());
        }
    }
}
