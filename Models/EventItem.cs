namespace EventifyAPI.Models;

public class EventItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Date { get; set; } = "";
    public string Location { get; set; } = "";
    public string? Description { get; set; }
}