namespace MVC_Event.ViewModel
{
    public class EventVM
    {

        public int Id { get; set; }   

        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? OrganizerName { get; set; }
        public bool UserHasBooked { get; set; }


    }
}
