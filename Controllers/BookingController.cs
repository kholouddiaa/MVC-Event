using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Event.Models;
using MVC_Event.ViewModel;
using System.Linq;

namespace MVC_Event.Controllers
{
    public class BookingController : Controller
    {
        private readonly EventDBContext _context;

        public BookingController(EventDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Book(int id)
        {
            var @event = _context.Events.FirstOrDefault(e => e.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            
            int userId = 1; 

         
            var existingBooking = _context.Bookings
                .FirstOrDefault(b => b.EventId == id && b.UserId == userId);

            if (existingBooking == null)
            {
                Booking booking = new Booking()
                {
                    EventId = @event.Id,
                    Event = @event,
                    UserId = userId
                };

                _context.Bookings.Add(booking);
                _context.SaveChanges();
            }

         
            var myBookings = _context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.Event)
                .Select(b => new EventVM
                {
                    Id = b.Event.Id,
                    Title = b.Event.Title,
                    Description = b.Event.Description,
                    Date = b.Event.Date,
                    OrganizerName = b.Event.OrganizerName,
                    UserHasBooked = true,
                })
                .ToList();

            return View("MyBookings", myBookings);
        }

        public IActionResult MyBookings()
        {
            int userId = 1;

            var myBookings = _context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.Event)
                .Select(b => new EventVM
                {
                    Id = b.Event.Id,
                    Title = b.Event.Title,
                    Description = b.Event.Description,
                    Date = b.Event.Date,
                    OrganizerName = b.Event.OrganizerName,
                    UserHasBooked = true
                })
                .ToList();

            return View(myBookings);
        }
    }
}
