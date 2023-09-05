using API_Test.DataContext;
using API_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Test.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
   private readonly DbDataContext _dbDataContext;

   public CustomerController(DbDataContext dbDataContext)
   {
      _dbDataContext = dbDataContext;
   }

   [HttpGet]
   [Route("CustomerList")]
   public async Task<IActionResult> GetCustomerList()
   {
      var customerlist =await _dbDataContext.Customer.ToListAsync();
      return Ok(customerlist);
   }
   
   [HttpGet]
   [Route("CustomerById/{Id}")]
   public async Task<IActionResult> GetCustomerList(int Id)
   {
      var customer =await _dbDataContext.Customer.FindAsync(Id);
      return Ok(customer);
   }

   [HttpPost]
   [Route("SaveCustomer")]
   public async Task<IActionResult> AddCustomer(Customer customer)
   {
      await _dbDataContext.Customer.AddAsync(customer);
      await _dbDataContext.SaveChangesAsync();
      return Ok(new{sucess = true, message = "Customer Added Sucessfully"});
   }
   
   [HttpGet]
   [Route("Delete/{Id}")]
   public async Task<IActionResult> DeleteCustomer(int Id)
   {
      
      var customer =await _dbDataContext.Customer.FindAsync(Id);
      if (customer != null)
      {
          _dbDataContext.Customer.Remove(customer);
         await _dbDataContext.SaveChangesAsync();
      }

      return Ok(new{sucess = true, message = "Customer Deleted Sucessfully"});
   }
   
}