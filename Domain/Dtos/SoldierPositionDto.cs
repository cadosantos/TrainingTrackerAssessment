namespace Domain.Dtos
{
    public class SoldierPositionDto
    {
        public SoldierPositionDto(string soldierName, decimal longitude, decimal latitude)
        {
            SoldierName = soldierName;
            Longitude = longitude;
            Latitude = latitude;
        }

        public string SoldierName { get; }
        public decimal Longitude { get; }
        public decimal Latitude { get; }
    }
}