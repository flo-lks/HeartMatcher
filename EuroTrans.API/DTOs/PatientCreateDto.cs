namespace EuroTrans.API.DTOs
{
    public class PatientCreateDto
    {
            public string Firstname { get; set; } = string.Empty;
            public string Lastname { get; set; } = string.Empty;
            public string Bloodtype { get; set; } = string.Empty;
            public double Bodyweight { get; set; }
            public int Hospital { get; set; }
    }
}
