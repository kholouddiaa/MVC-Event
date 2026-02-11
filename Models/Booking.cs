using System;
using System.Collections.Generic;

namespace MVC_Event.Models;

public partial class Booking
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int EventId { get; set; }

    public  Event Event { get; set; } = null!;

    public  User User { get; set; } = null!;
}
