namespace EuroTrans.API.DTOs
{
    public class HeartCreateDto
    {
        public string BloodType { get; set; } = string.Empty;
        public double DonorBodyweight { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public bool IsMatched { get; set; } = false;
    }
}
