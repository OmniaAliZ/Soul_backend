using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;
namespace sda_onsite_2_csharp_backend_teamwork.src.Controller;

[Route("api/v1/addresses")]// s removed : Address becomes addresss - category becomes catecorys 😒
public class AddressController : BaseController
{
    private IAddressService _addressService;
    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<AddressReadDto?> FindOne(Guid id)
    {
        AddressReadDto? foundAddress = _addressService.FindOne(id);

        if (foundAddress is null)
        {
            return NotFound();
        }

        return Ok(foundAddress);
    }

    [HttpGet]
    public IEnumerable<AddressReadDto> FindAll()
    {
        return _addressService.FindAll();
    }

    [HttpGet("user/{id}")]
    public IEnumerable<AddressReadDto> FindByUserId(Guid id)
    {
        return _addressService.FindByUserId(id);
    }

    // [Authorize(Roles = "Admin,Customer")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public AddressReadDto? CreateOne([FromBody] AddressCreateDto address)
    {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        return _addressService.CreateOne(address, userId!);

    }
    [HttpPatch("{id}")]
    public ActionResult<AddressReadDto> UpdateOne(Guid id, Address address)
    {
        AddressReadDto? updatedAddress = _addressService.UpdateOne(id, address);
        if (updatedAddress is not null)
        {
            return CreatedAtAction(nameof(UpdateOne), updatedAddress);
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteOne(Guid id)
    {
        bool isDeleted = _addressService.DeleteOne(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
