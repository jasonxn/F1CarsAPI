namespace F1CarsAPI.ViewModels
{
    public class CreateCarModel
    {
        public string Model { get; set; } = default!;
        public int Year { get; set; }
        public int Horsepower { get; set; }
        public int TeamId { get; set; }
    }
}
