using chedid.DataBase;
using chedid.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Ensure this namespace is imported

namespace chedid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorQuotaionController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public MotorQuotaionController(ApplicationDbContext context) { 
            _context = context; 
        }

        [HttpPost("QuotationData")]
        public ActionResult QuotationData([FromBody]Quotation qt )
        {
            Quotation quotation =new Quotation();
            quotation.QuotationStatus = qt.QuotationStatus;
            quotation.CreationDate = qt.CreationDate;
            quotation.PolicyOwner=qt.PolicyOwner;
            quotation.CarMake=qt.CarMake;
            quotation.CarYear=qt.CarYear;
            _context.Add(quotation);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("AllQuotations")]
        public ActionResult<IEnumerable<Quotation>> AllQuotations()
        {
            var quotations = _context.Quotation
                .Select(q => new
                {
                    q.QuotationNumber,
                    q.PolicyOwner,
                    q.CarMake,
                    q.CarYear,
                    q.QuotationStatus,
                    CreationDate = q.CreationDate.ToString("yyyy-MM-dd")
                })
                .ToList();
            return Ok(quotations); 
        }
    }
}
