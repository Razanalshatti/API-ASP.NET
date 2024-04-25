using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankContext _context;

        public BankController(BankContext context)
        {
            _context = context;
        }

        public List<BankBranch> getAll()
        {
            return _context.BankBranches.ToList();
        }

        [HttpPost]
        public IActionResult Add(AddBankRequest req)
        {
            _context.BankBranches.Add(new BankBranch(){
                location = req.location,
                locationURL = req.locationURL,
                branchManager = ""
            });
            _context.SaveChanges();

            return Created();
        }
    }
}
