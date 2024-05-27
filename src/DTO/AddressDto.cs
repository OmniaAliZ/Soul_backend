using System.ComponentModel.DataAnnotations;

namespace sda_onsite_2_csharp_backend_teamwork.src.DTO;

public class AddressReadDto
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public int Zip_code { get; set; }
    public string Street { get; set; }
}
public class AddressCreateDto
{
    [Required]
    public string Country { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Street { get; set; }
    public int Zip_code { get; set; }
}
