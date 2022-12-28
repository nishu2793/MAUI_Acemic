using DocumentFormat.OpenXml.Bibliography;

namespace AceMicEV.Models.Response;

public class MachineResponse
{
    public string? did { get; set; }

    public string? address1 { get; set; }

    public string? address2 { get; set; }

    public string? city { get; set; }

    public string? state { get; set; }

    public string? zipcode { get; set; }

    public string? latitude { get; set; }

    public string? longitude { get; set; }

    public string? barcodeNumber { get; set; }

    public string? active { get; set; }

    public string? status { get; set; }

    public string? serialNumber { get; set; }

}