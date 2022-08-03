using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class PizzasController : BaseApiController
    {
        private readonly StoreContext _context;
        public PizzasController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<Pizza>>> GetPizzas([FromQuery]PizzaParams pizzaParams)
        {
            var query = _context.Pizzas
                .Sort(pizzaParams.OrderBy)
                .Search(pizzaParams.SearchTerm)
                .Filter(pizzaParams.Crusts, pizzaParams.Types)
                .AsQueryable();

            var pizzas = await PagedList<Pizza>.ToPagedList(query, 
                pizzaParams.PageNumber, pizzaParams.PageSize);

            Response.AddPaginationHeader(pizzas.MetaData);

            return pizzas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);

            if (pizza == null) return NotFound();

            return pizza;
        }

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            var crusts = await _context.Pizzas.Select(p => p.Crust).Distinct().ToListAsync();
            var types = await _context.Pizzas.Select(p => p.Type).Distinct().ToListAsync();

            return Ok(new {crusts, types});
        }
    }
}