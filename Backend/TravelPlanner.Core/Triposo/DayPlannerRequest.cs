namespace TravelPlanner.Core.Triposo
{
    public class DayPlannerRequest
    {
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string HotelPoiId { get; set; }
        public int? ItemsPerDay { get; set; }
        public int? MaxDistance { get; set; }
        public string LocationId{ get; set; }
    }
}
