# Finance Tracker API

This is the backend API for the **Finance Tracker** application, built with **ASP.NET Core Web API**. It provides endpoints to manage income and expense records, enabling full CRUD operations and integration with the Angular frontend.

---

## 📦 Tech Stack

- ASP.NET Core 7.0+
- C#
- In-memory data storage (for now)
- RESTful API design
- CORS enabled for frontend integration

---

## 📁 Project Structure
finance-tracker-api/ 
  ├── Controllers/ │   
    ├── IncomeController.cs 
    |── ExpenseController.cs 
  ├── Models/ │   
    ├── Income.cs │   
    |── Expense.cs 
  ├── Program.cs 
  |── ...
---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/<your-username>/<repo-name>.git
cd finance-tracker/finance-tracker-api

### **2. Restore Dependencies**
dotnet restore

### **3. Run the API**
dotnet run

The API will be available at: http://localhost:5254

📌 Notes
• 	This version uses in-memory lists for data storage.
• 	Future versions will integrate with a SQL database using Entity Framework Core.
• 	Designed to work seamlessly with the Finance Tracker Angular frontend.

📜 License
This project is for educational and personal development purposes.
