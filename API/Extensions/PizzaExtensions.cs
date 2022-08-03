using System.Collections.Generic;
using System.Linq;
using API.Entities;

namespace API.Extensions
{
    public static class PizzaExtensions
    {
        public static IQueryable<Pizza> Sort(this IQueryable<Pizza> query, string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy)) return query.OrderBy(p => p.Name); 

            query = orderBy switch
            {
                "price" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name)
            };

            return query;
        }

        public static IQueryable<Pizza> Search(this IQueryable<Pizza> query, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return query;

            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

            return query.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<Pizza> Filter(this IQueryable<Pizza> query, string crusts, string types)
        {
            var crustList = new List<string>();
            var typeList = new List<string>();

            if (!string.IsNullOrEmpty(crusts))
                crustList.AddRange(crusts.ToLower().Split(",").ToList());

            if (!string.IsNullOrEmpty(types))
                typeList.AddRange(types.ToLower().Split(",").ToList());

            query = query.Where(p => crustList.Count == 0 || crustList.Contains(p.Crust.ToLower()));
            query = query.Where(p => typeList.Count == 0 || typeList.Contains(p.Type.ToLower()));

            return query;
        }
    }
}