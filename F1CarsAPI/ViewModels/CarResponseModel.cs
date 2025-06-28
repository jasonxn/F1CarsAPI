namespace F1CarsAPI.ViewModels
{
    public class CarResponseModel
    {
        public int Id { get; set; }
        public string Model { get; set; } = default!;
        public int Year { get; set; }
        public int Horsepower { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
