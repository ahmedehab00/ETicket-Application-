using etickets.Service.UnitOfWork;
using eTickets.service.service;
using eTickets.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Threading.Tasks;
using ZendeskApi_v2.Models.Constants;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]

        public async Task< IActionResult> Index()
        {
            var data=await _unitOfWork.Actors.GetAllAsync();
            return View(data);
        }
        // Ger   Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _unitOfWork.Actors.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Details/id
        [AllowAnonymous]

        public async Task<IActionResult>Details(int id)
        {
            var ActorDetails=await _unitOfWork.Actors.GetByIdAsync(id);
            if (ActorDetails == null)
            {
                return View("NotFound");
            }
            return View(ActorDetails);
                    
           
        }
        // Get :  Actors/Edit/id
        public async Task< IActionResult> Edit(int id)
        {
            var ActorDetails = await _unitOfWork.Actors.GetByIdAsync(id);
            if (ActorDetails == null)
            {
                return View("NotFound");
            }
            return View(ActorDetails);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("id,FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _unitOfWork.Actors.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ActorDetails = await _unitOfWork.Actors.GetByIdAsync(id);
            if (ActorDetails == null)
            {
                return View("NotFound");
            }
            return View(ActorDetails);
        }
        
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ActorDetails = await _unitOfWork.Actors.GetByIdAsync(id);
            if (ActorDetails == null)
            {
                return View("NotFound");
            }
            await _unitOfWork.Actors.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
