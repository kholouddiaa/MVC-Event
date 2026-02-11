using Microsoft.AspNetCore.Mvc;
using MVC_Event.Models;
using MVC_Event.ViewModel;

namespace MVC_Event.Controllers
{
    public class EventController : Controller
    {
        private readonly EventDBContext _bookContext;

        
       
        public EventController(EventDBContext bookContext)
        {
            _bookContext = bookContext;
        }

       
        public IActionResult Index()
        {
            List<Event> events = _bookContext.Events.ToList();
            return View("GetAllEvents", events);
        }

    
        public IActionResult Details(int eventId)
        {

            var Event = _bookContext.Events.FirstOrDefault(e => e.Id== eventId);
            if (Event == null)
            {
                return NotFound();
            }
            EventVM eventt = new EventVM()
            {
                Id = Event.Id,                   
                Title = Event.Title,
                Description = Event.Description,
                Date = Event.Date,
                OrganizerName = Event.OrganizerName, 
            };
            return View(eventt);

        }


     
        public IActionResult NewEvent()
        {
            return View(new Event());
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult SaveEvent(Event e)
        {
            if (ModelState.IsValid)
            {
                _bookContext.Events.Add(e);
                _bookContext.SaveChanges();

                return RedirectToAction("Index");
            }

          
            return View("NewEvent", e);
        }



        public IActionResult EditEvent(int id)
        {
            Event e = _bookContext.Events.FirstOrDefault(e => e.Id == id);
            return View(e);
        }

        [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(Event ev)
        {
            if (ModelState.IsValid)
            {
                Event ee = _bookContext.Events.FirstOrDefault(e => e.Id == ev.Id);
                if (ee == null) return NotFound();

                ee.Title = ev.Title;
                ee.Description = ev.Description;
                ee.Date = ev.Date;
                ee.OrganizerName = ev.OrganizerName;

                _bookContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("EditEvent", ev);
        }

        public IActionResult Remove(int id)
        {
            Event ev = _bookContext.Events.FirstOrDefault(e => e.Id == id);
            if (ev != null)
            {
                _bookContext.Events.Remove(ev);
                _bookContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }

}
