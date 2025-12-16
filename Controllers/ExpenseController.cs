using FinanceTracker.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        public static readonly List<Expense> _expenses = new()
        {
            new Expense { Id = 1, Category = "Food", Amount = 300, Date = DateTime.Now.AddDays(-1) },
            new Expense { Id = 2, Category = "Transport", Amount = 120, Date = DateTime.Now.AddDays(-2) }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_expenses);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Expense expense)
        {
            if (expense == null)
                return BadRequest("Expense data is required");

            expense.Id = _expenses.Count + 1;
            _expenses.Add(expense);

            return Ok(expense);
        }
    
        [HttpPut("{id}")]
        public IActionResult UpdateExpense(int id, Expense updatedExpense)
        {
            var expense = _expenses.FirstOrDefault(x => x.Id == id);
            if (expense == null)
                return NotFound("Expense not found");

            expense.Category = updatedExpense.Category;
            expense.Amount = updatedExpense.Amount;
            expense.Date = updatedExpense.Date;

            return Ok(expense);
}

        [HttpDelete("{id}")]
        public IActionResult DeleteExpense(int id)
        {
            var expense = _expenses.FirstOrDefault(x => x.Id == id);
            if (expense == null)
                return NotFound("Expense not found");

            _expenses.Remove(expense);
             return Ok(new { message = "Expense deleted" });
        }
    
    }
}