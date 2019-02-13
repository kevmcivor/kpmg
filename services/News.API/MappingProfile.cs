using AutoMapper;
using Microsoft.AspNetCore.Http;
using News.API.Models;
using News.Domain.Entities.ArticleAggregate;
using System.Linq;
using System.Security.Claims;

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

            CreateMap<ArticleCreateDto, Content>();
            CreateMap<ArticleCreateDto, Article>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Author, opt => opt.Ignore());

            CreateMap<ArticleUpdateDto, Article>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Author, opt => opt.Ignore());

            CreateMap<ClaimsPrincipal, Author>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Claims.Where(c => c.Type == "sub").First().Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Claims.Where(c => c.Type == "name").First().Value));
        }
    }
}
