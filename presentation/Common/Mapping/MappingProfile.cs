using AutoMapper;
using ProductApi.Application.DTOs.Product;
using ProductApi.Application.DTOs.ProductCategory;
using ProductApi.Application.DTOs.ProductGroup;
using ProductApi.Application.DTOs.User;
using ProductApi.Application.DTOs.Auth;
using domain.Entities;
using System;
using domain.Entities;

namespace ProductApi.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product mappings
            CreateMap<Product, ProductReadDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => 0m)) // Default placeholder
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => 0))  // Default placeholder
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => string.Empty)) // Default placeholder
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow)); // Consider persisting CreatedAt in entity

            CreateMap<ProductCreateDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ProductCategory, opt => opt.Ignore())
                .ForMember(dest => dest.ProductGroup, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.ProductCategory, opt => opt.Ignore())
                .ForMember(dest => dest.ProductGroup, opt => opt.Ignore())
                .ReverseMap();

            // ProductCategory mappings
            CreateMap<ProductCategory, ProductCategoryReadDto>().ReverseMap();

            CreateMap<ProductCategoryCreateDto, ProductCategory>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ProductCategoryUpdateDto, ProductCategory>()
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .ReverseMap();

            // ProductGroup mappings
            CreateMap<ProductGroup, ProductGroupReadDto>().ReverseMap();

            CreateMap<ProductGroupCreateDto, ProductGroup>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ProductGroupUpdateDto, ProductGroup>()
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .ReverseMap();

            // User mappings
            CreateMap<User, UserReadDto>();

            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());

            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());

            // Auth mappings
            CreateMap<LoginDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());

            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
        }
    }
}
