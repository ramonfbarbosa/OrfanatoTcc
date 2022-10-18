using OrfanatoAPI.DTOs;
using OrfanatoAPI.Models;

namespace OrfanatoAPI.Requests;

public class InsertOrfanatoRequest
{
    public string Name { get; set; }
    public string About { get; set; }
    public string Whatsapp { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string Instructions { get; set; }
    public string OpeningHours { get; set; }
    public bool OpenOnWeekends { get; set; }
    public List<BlobImagesDTO> Images { get; set; }

    public InsertOrfanatoRequest() { }

    public Orphanage GetEntity() =>
        new()
        {
            Name = Name,
            Whatsapp = Whatsapp,
            Latitude = Latitude,
            Longitude = Longitude,
            About = About,
            Instructions = Instructions,
            AbreAs = OpeningHours,
            AbertoFimDeSemana = OpenOnWeekends
        };
}
