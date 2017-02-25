namespace CAPreperation.Models
{
    public class Weather
    {
        public string City { get; set; }
        public int Temperature { get; set; }
        public int WindSpeed { get; set; }
        public Conditions Condition { get; set; }
        public bool WeatherWarning { get; set; }

        public override string ToString()
        {
            return "City: " + City + "\nTemperature: " + Temperature + "\nWindspeed:" + WindSpeed +
                "\nCondition: " + Condition + "\nWarning: " + WeatherWarning + "\n=================";
        }
    }
}