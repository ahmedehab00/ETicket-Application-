using etickets.Service.UnitOfWork;
using eTickets.Data;
using eTickets.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ZendeskApi_v2.Models.Constants;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]

    public class CinemasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CinemasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        public async Task< IActionResult> Index()
        {
            var allCinemas =  await _unitOfWork.Cinemas.GetAllAsync();
            return View(allCinemas);
        }
        //get:Cinemas/Create
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _unitOfWork.Cinemas.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        //Get:Cinemas/Details/id
        [AllowAnonymous]

        public async Task<IActionResult> Details(int id)
        {
            var CinemaDetails=await _unitOfWork.Cinemas.GetByIdAsync(id);
            if (CinemaDetails == null) 
            {
                return View("Not Found");
            }
            return View(CinemaDetails);
        }

        //Get:Cinemas/Edit/id
        public async Task<IActionResult>Edit(int id)
        {
            var CinemaDetails= await _unitOfWork.Cinemas.GetByIdAsync(id);
            if (CinemaDetails == null) return View("NotFound");
            return View(CinemaDetails);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(int id, [Bind("id,Logo,Name,Description")]Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _unitOfWork.Cinemas.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));

        }
        // Get: Cinemas/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var CinemaDetails = await _unitOfWork.Cinemas.GetByIdAsync(id);
            if (CinemaDetails == null) return View("NotFound");
            return View(CinemaDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CinemaDetails = await _unitOfWork.Cinemas.GetByIdAsync(id);
            if (CinemaDetails == null) return View("NotFound");
            await _unitOfWork.Cinemas.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
