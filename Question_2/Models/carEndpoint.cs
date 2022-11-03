namespace carterAPI.Models
{
    public class carEndpoint
    {
        // properties for the car table
        public int car_id { get; set; }
        public string car_name { get; set; }
        public string car_model { get; set; }
        public string car_image { get; set; }
        public int year_released { get; set; }
        public decimal no_of_liters { get; set; }
        public string transmission { get; set; }
        public decimal price { get; set; }
        public decimal monthly_installment { get; set; }
        public int insurance { get; set; }
        public int warrenty { get; set; }
        public string good_features { get; set; }
        public string bad_features { get; set; }

    }
}
