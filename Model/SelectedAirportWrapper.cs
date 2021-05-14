namespace Model
{
    public class SelectedAirportWrapper
    {
        public AirportModel Airport { get; set; }
        public bool IsAllAirport { get; set; }
        public override string ToString()
        {
            return IsAllAirport ? "All" : Airport.Name + ", " + Airport.City + ", " + Airport.Country;
        }
    }
}
