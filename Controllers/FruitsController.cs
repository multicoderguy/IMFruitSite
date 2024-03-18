using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FruitIMSite.Models;
using IMFruitSite.DAL;
using Microsoft.Extensions.Caching.Memory;

namespace IMFruitSite.Controllers
{
    public class FruitsController : Controller
    {
        private readonly FruitContext _context;
        private readonly IMemoryCache _cache;

        public FruitsController(FruitContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: Fruits
        public async Task<IActionResult> Index(string dateFilter)
        {
            ViewData["DateFilter"] = dateFilter;
            if(!_cache.TryGetValue("fruits", out List<Fruit> allFruits))
            {
                allFruits = await _context.Fruits.ToListAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                };
                _cache.Set("fruits", allFruits, cacheEntryOptions);
            }
            if (!_cache.TryGetValue("colors", out List<Color> allColors))
            {
                allColors = await _context.Colors.ToListAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                };
                _cache.Set("colors", allColors, cacheEntryOptions);
            }
            if (!_cache.TryGetValue("fruitTypes", out List<FruitType> allFruitTypes))
            {
                allFruitTypes = await _context.FruitTypes.ToListAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                };
                _cache.Set("fruitTypes", allFruitTypes, cacheEntryOptions);
            }

            List<Fruit> fruits;
            if(!String.IsNullOrEmpty(dateFilter))
            {
                fruits = allFruits.Where(f => f.DatePicked > Convert.ToDateTime(dateFilter)).ToList();
            } else
            {
                fruits = allFruits;
            }
            
            foreach (Fruit f in fruits)
            {
                f.Color = allColors.FirstOrDefault(c => c.ColorId == f.ColorId);
                f.FruitType = allFruitTypes.FirstOrDefault(t => t.FruitTypeId == f.FruitTypeId);
            }
            return View(fruits);
        }

    }
}
