using FinanceTracker.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController : ControllerBase
    {
        public static readonly List<Income> _incomes = new()
        {
            new Income { Id = 1, Source = "Salary", Amount = 50000, Date = DateTime.Now.AddDays(-5) },
            new Income { Id = 2, Source = "Freelancing", Amount = 12000, Date = DateTime.Now.AddDays(-2) }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_incomes);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Income income)
        {
            if (income == null)
                return BadRequest("Income data is required");

            // Simple auto-increment ID
            income.Id = _incomes.Count + 1;

            // Add to in-memory list
            _incomes.Add(income);

            return Ok(income);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateIncome(int id, Income updatedIncome)
        {
            var income = _incomes.FirstOrDefault(x => x.Id == id);
            if (income == null)
                return NotFound("Income not found");
            income.Source = updatedIncome.Source;
            income.Amount = updatedIncome.Amount;
            income.Date = updatedIncome.Date;

            return Ok(income);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIncome(int id)
        {
            var income = _incomes.FirstOrDefault(x => x.Id == id);
            if (income == null)
                return NotFound("Income not found");

            _incomes.Remove(income);
            return Ok(new { message = "Income deleted" });
        }
    }
}