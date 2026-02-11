using System;
using System.Collections.Generic;

namespace MVC_Event.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } 
}
