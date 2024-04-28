using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/bank")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankContext _context;

        public BankController(BankContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public List<BankBranch> GetAll()
        {
            return _context.BankBranches.ToList();
        }

        
        [HttpGet("{id}")]
        public ActionResult<BankBranch> GetBankBranch(int id)
        {
            var bankBranch = _context.BankBranches.FirstOrDefault(b => b.Id == id);

            if (bankBranch == null)
            {
                return NotFound();
            }

            
            bankBranch.Employees = _context.Employees.Where(e => e.BankBranchId == id).ToList();

            return bankBranch;
        }

        
        [HttpPost]
        public IActionResult Add(AddBankRequest req)
        {
            _context.BankBranches.Add(new BankBranch()
            {
                location = req.location,
                locationURL = req.locationURL,
                branchManager = ""
            });
            _context.SaveChanges();

            return Created();
        }
    }
}
