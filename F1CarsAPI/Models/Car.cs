namespace F1CarsAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Horsepower { get; set; }
        public int teamId { get; set; }
        public Team Team { get; set; }
    }
}
