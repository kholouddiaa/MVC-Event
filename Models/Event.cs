using System;
using System.Collections.Generic;

namespace MVC_Event.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public string OrganizerName { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    internal Event FirstOrDefault(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}
