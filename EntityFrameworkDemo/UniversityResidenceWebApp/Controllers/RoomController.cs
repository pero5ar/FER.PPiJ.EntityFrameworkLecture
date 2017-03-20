using Microsoft.AspNetCore.Mvc;
using UniversityResidence.Interfaces;

namespace UniversityResidenceWebApp.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _rooms;

        public RoomController(IRoomRepository roomRepository)
        {
            _rooms = roomRepository;
        }

        public IActionResult Index()
        {
            return View(_rooms.GetWithOccupants());
        }
    }
}
