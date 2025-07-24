using System.Linq;
using ProductApi.Application.DTOs.ProductGroup;
using ProductApi.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApi.Domain.Interfaces;
using System;

namespace ProductApi.Application.Services
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly IProductGroupRepository _groupRepository;
        public ProductGroupService(IProductGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<ProductGroupReadDto> CreateAsync(ProductGroupCreateDto dto)
        {
            var group = new ProductGroup
            {
                Name = dto.Name!,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };
            var created = await _groupRepository.AddAsync(group);
            return new ProductGroupReadDto
            {
                Id = created.Id,
                Name = created.Name,
                Description = created.Description,
                CreatedAt = created.CreatedAt
            };
        }

        public async Task<IEnumerable<ProductGroupReadDto>> GetAllAsync()
        {
            var groups = await _groupRepository.GetAllAsync();
            return groups.Select(g => new ProductGroupReadDto
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                CreatedAt = g.CreatedAt
            });
        }

        public async Task<ProductGroupReadDto> GetByIdAsync(int id)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            if (group == null) return null;
            return new ProductGroupReadDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                CreatedAt = group.CreatedAt
            };
        }

        public async Task<ProductGroupReadDto> UpdateAsync(int id, ProductGroupUpdateDto dto)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            if (group == null) return null;
            group.Name = dto.Name!;
            group.Description = dto.Description;
            var updated = await _groupRepository.UpdateAsync(group);
            return new ProductGroupReadDto
            {
                Id = updated.Id,
                Name = updated.Name,
                Description = updated.Description,
                CreatedAt = updated.CreatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _groupRepository.DeleteAsync(id);
        }
    }
}
