using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Api.Controllers;


namespace FinanceTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSummary()
        {
            // Access static lists from IncomeController & ExpenseController
            var totalIncome = IncomeController._incomes.Sum(x => x.Amount);
            var totalExpense = ExpenseController._expenses.Sum(x => x.Amount);
            var balance = totalIncome - totalExpense;

            var summary = new
            {
                totalIncome,
                totalExpense,
                balance
            };

            return Ok(summary);
        }
    }
}