/*using System.Collections.Generic;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var shoes = new Dictionary<string, string>(); shoes.Add("en", "Shoes"); shoes.Add("ru", "Обувь"); shoes.Add("tj", "Пойафзол"); shoes.Add("ch", "Shoes");
            var leather = new Dictionary<string, string>(); leather.Add("en", "Leather"); leather.Add("ru", "Кожа"); leather.Add("tj", "Чарм"); leather.Add("ch", "Shoes");
            var soles = new Dictionary<string, string>(); soles.Add("en", "Soles"); soles.Add("ru", "Подошвы"); soles.Add("tj", "Тагчарми пойафзол"); soles.Add("ch", "Shoes");
            var belts = new Dictionary<string, string>(); belts.Add("en", "Belts"); belts.Add("ru", "Ремни"); belts.Add("tj", "Камарбандхо"); belts.Add("ch", "Shoes");
            var male = new Dictionary<string, string>(); male.Add("en", "Male"); male.Add("ru", "Мужской"); male.Add("tj", "Мардона"); male.Add("ch", "Shoes");
            var military = new Dictionary<string, string>(); military.Add("en", "Military"); military.Add("ru", "Военный"); military.Add("tj", "Харби"); military.Add("ch", "Shoes");
            var teenage = new Dictionary<string, string>(); teenage.Add("en", "Teenage"); teenage.Add("ru", "Подростковый"); teenage.Add("tj", "Наврасона"); teenage.Add("ch", "Shoes");
            var classic = new Dictionary<string, string>(); classic.Add("en", "Classic"); classic.Add("ru", "Классик"); classic.Add("tj", "Классик"); classic.Add("ch", "Shoes");
            var hunting = new Dictionary<string, string>(); hunting.Add("en", "Hunting"); hunting.Add("ru", "Охотничий"); hunting.Add("tj", "Шикори"); hunting.Add("ch", "Shoes");
            var workingShoes = new Dictionary<string, string>(); workingShoes.Add("en", "Working Shoes"); workingShoes.Add("ru", "Рабочий"); workingShoes.Add("tj", "Пойафзоли кори"); workingShoes.Add("ch", "Shoes");
            var boots = new Dictionary<string, string>(); boots.Add("en", "Boots"); boots.Add("ru", "Сапоги"); boots.Add("tj", "Муза"); boots.Add("ch", "Shoes");
            var sport = new Dictionary<string, string>(); sport.Add("en", "Sports"); sport.Add("ru", "Спортивный"); sport.Add("tj", "Варзиши"); sport.Add("ch", "Shoes");
            var moccasins = new Dictionary<string, string>(); moccasins.Add("en", "Moccasins"); moccasins.Add("ru", "Мокасины"); moccasins.Add("tj", "Мокасинхо"); moccasins.Add("ch", "Shoes");
            var bertsy = new Dictionary<string, string>(); bertsy.Add("en", "Bertsy"); bertsy.Add("ru", "Берцы"); bertsy.Add("tj", "Берцы"); bertsy.Add("ch", "Shoes");
            builder.HasData(
                new Category {Id = 1, Name = "shoes", ParentId = 0},
                new Category {Id = 2, Name = "leather", ParentId = 0},
                new Category {Id = 3, Name = "soles", ParentId = 0},
                new Category {Id = 4, Name = "belts", ParentId = 0},
                new Category {Id = 5, Name = "male", ParentId = 1},
                new Category {Id = 6, Name = "military", ParentId = 1},
                new Category {Id = 7, Name = "teenage", ParentId = 1},
                new Category {Id = 8, Name = "classic", ParentId = 5},
                new Category {Id = 9, Name = "hunting", ParentId = 5},
                new Category {Id = 10, Name = "workingShoes", ParentId = 5},
                new Category {Id = 11, Name = "boots", ParentId = 5},
                new Category {Id = 12, Name = "sport", ParentId = 5},
                new Category {Id = 13, Name = "moccasins", ParentId = 5},
                new Category {Id = 14, Name = "bertsy", ParentId = 6},
                new Category {Id = 15, Name = "military", ParentId = 4}
            );
        }
    }
}*/