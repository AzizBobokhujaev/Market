using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category {Id = 1, Name = "Обувь", ParentId = 0},
                new Category {Id = 2, Name = "Кожа", ParentId = 0},
                new Category {Id = 3, Name = "Подошвы", ParentId = 0},
                new Category {Id = 4, Name = "Ремни", ParentId = 0},
                new Category {Id = 5, Name = "Мужской", ParentId = 1},
                new Category {Id = 6, Name = "Военный", ParentId = 1},
                new Category {Id = 7, Name = "Подростковый", ParentId = 1},
                new Category {Id = 8, Name = "Классик", ParentId = 5},
                new Category {Id = 9, Name = "Охотничий", ParentId = 5},
                new Category {Id = 10, Name = "Рабочий", ParentId = 5},
                new Category {Id = 11, Name = "Сапоги", ParentId = 5},
                new Category {Id = 12, Name = "Спортивный", ParentId = 5},
                new Category {Id = 13, Name = "Мокасины", ParentId = 5},
                new Category {Id = 14, Name = "Берцы", ParentId = 6},
                new Category {Id = 15, Name = "Военный", ParentId = 4}
            );
        }
    }
}