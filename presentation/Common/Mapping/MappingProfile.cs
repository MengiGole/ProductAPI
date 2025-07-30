using AutoMapper;
using ProductApi.Application.DTOs.Product;
using ProductApi.Application.DTOs.ProductCategory;
using ProductApi.Application.DTOs.ProductGroup;
using ProductApi.Application.DTOs.User;
using ProductApi.Application.DTOs.Auth;

namespace ProductApi.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product mappings
            CreateMap<Product, ProductReadDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => 0m)) // Default value since Price is not in entity
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => 0)) // Default value since Stock is not in entity
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => string.Empty)) // Default value since Description is not in entity
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow)); // Default value since CreatedAt is not in entity

            CreateMap<ProductCreateDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id as it's auto-generated
                .ForMember(dest => dest.ProductCategory, opt => opt.Ignore()) // Navigation property
                .ForMember(dest => dest.ProductGroup, opt => opt.Ignore()); // Navigation property

            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.ProductCategory, opt => opt.Ignore()) // Navigation property
                .ForMember(dest => dest.ProductGroup, opt => opt.Ignore()); // Navigation property

            // ProductCategory mappings
            CreateMap<ProductCategory, ProductCategoryReadDto>();
            CreateMap<ProductCategoryCreateDto, ProductCategory>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            CreateMap<ProductCategoryUpdateDto, ProductCategory>()
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            // ProductGroup mappings
            CreateMap<ProductGroup, ProductGroupReadDto>();
            CreateMap<ProductGroupCreateDto, ProductGroup>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            CreateMap<ProductGroupUpdateDto, ProductGroup>()
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            // User mappings
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UserUpdateDto, User>();

            // Auth mappings - Fixed to match actual DTOs and User entity
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