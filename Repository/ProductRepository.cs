using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Repositories;
using Entities;
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
            var productImage = await _context.ProductImage.Select(pi => new ProductImage
            {
                Id = pi.Id,
                Color = pi.Color,
                ImagePath = pi.ImagePath,
                ProductId = pi.ProductId
            }).Where(p=>p.ProductId == id).ToListAsync();
            return await _context.Products.Select(p=>new Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Size = p.Size,
                Material = p.Material,
                Width = p.Width,
                Length = p.Length,
                CategoryId = p.CategoryId,
                UserId = p.UserId,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                DeletedAt = p.DeletedAt,
                IsNew = p.IsNew,
                IsSale = p.IsSale,
                Seasons = p.Seasons,
                ProductImages =new List<ProductImage>(productImage)
            }).Where(prod=>prod.Id==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();  
    }
}