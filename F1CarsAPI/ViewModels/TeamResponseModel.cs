namespace F1CarsAPI.ViewModels
{
    public class TeamResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Country { get; set; } = default!;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public List<CarResponseModel> Cars { get; set; } = new List<CarResponseModel>();

    }
}
