using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAB.App.Catalog.Bill;
using TAB.ViewModels.Catalog.Bill;

namespace TAB.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly InterfaceBillService _billService;

        public BillController(InterfaceBillService billService)
        {
            _billService = billService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BillCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var billId = await _billService.Create(request);
            if (billId == 0)
                return BadRequest("Cannot create bill");

            var bill = await _billService.GetBillById(billId);
            return CreatedAtAction(nameof(GetById), new { id = billId }, billId);
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var bill = await _billService.GetBillAll();
            return Ok(bill);
        }
        [HttpGet("{billId}")]
        public async Task<IActionResult> GetById(int billId)
        {
            var bill = await _billService.GetBillById(billId);
            if (bill == null)
                return BadRequest("Cannot find bill");
            return Ok(bill);
        }
    }
}
