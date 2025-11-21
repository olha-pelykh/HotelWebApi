namespace HotelWebApi.Models
{
    public class AddHotelDto
    {
        public string HotelName { get; set; } = string.Empty;
        public string HotelDescription { get; set; } = string.Empty;
        public string HotelAddress { get; set; } = string.Empty;
        public string HotelPhone { get; set; } = string.Empty;
        public string HotelEmail { get; set; } = string.Empty;
    }
}
