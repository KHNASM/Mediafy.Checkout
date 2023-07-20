using Mediafy.Checkout.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Mediafy.Checkout.Business.Dtos;

public class OrderRequestDto
{
    public int OfferId { get; set; }

    [Required]
    [Display(Name = "First Name: ")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name: ")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Address: ")]
    public string Address { get; set; }

    [Required]
    [Display(Name = "Email: ")]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Display(Name = "ZIP Code: ")]
    public string ZipCode { get; set; }

    [Display(Name = "Telephone: ")]
    [DataType(DataType.PhoneNumber)]
    public string Telephone { get; set; }

    [Required]
    [Display(Name = "Country: ")]
    public Country? Country { get; set; }
}
