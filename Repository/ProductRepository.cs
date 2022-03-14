using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Repositories;
using Entities;
using Entities.DataTransferObjects.Products;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductRepository:RepositoryBase<Product>,IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<Product> GetProductById(int id)
        {
            
            return await _context.Products.Select(p=>new Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Material = p.Material,
                Width = p.Width,
                Length = p.Length,
                CategoryId = p.CategoryId,
                UserId = p.UserId,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                IsNew = p.IsNew,
                IsSale = p.IsSale,
                Seasons = p.Seasons,
                Size = p.Size,
                Category = _context.Categories.FirstOrDefault(category => category.Id==p.CategoryId),
                ProductImages =_context.ProductImage.Where(pi=>pi.ProductId == id).ToList()
            }).Where(prod=>prod.Id==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Seasons = p.Seasons,
                Material = p.Material,
                Length = p.Length,
                Width = p.Width,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                DeletedAt = p.DeletedAt,
                IsNew = p.IsNew,
                IsSale = p.IsSale,
                CategoryId = p.CategoryId,
                UserId = p.UserId,
                Size = p.Size,
                ProductImages = _context.ProductImage.Where(pi => pi.ProductId == p.Id).ToList(),
                Category = _context.Categories.Select(c=>new Category
                {
                    Id =c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId
                }).FirstOrDefault(ct => ct.Id==p.CategoryId)
            }).ToListAsync();
        }

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();  
    }
}