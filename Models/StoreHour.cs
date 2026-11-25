namespace final_project.Models
{
    public class StoreHour
    {
        public string StoreId { get; set; } = string.Empty;

        public DayOfWeek DayOfWeek { get; set; }

        public TimeOnly? OpenTime { get; set; }

        public TimeOnly? CloseTime { get; set; }

        public bool IsClosed { get; set; }

        public Store Store { get; set; } = null!;
    }
}