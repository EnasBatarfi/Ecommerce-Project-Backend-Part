using System.ComponentModel.DataAnnotations;

public class Admin
{
  public Guid AdminId { get; set; }

  [Required(ErrorMessage = "First name is required")]
  [MaxLength(100), MinLength(2)]
  public string FirstName { get; set; } = string.Empty;

  [Required(ErrorMessage = "Last name is required")]
  [MaxLength(100), MinLength(2)]
  public string LastName { get; set; } = string.Empty;

  [Required(ErrorMessage = "Email is required")]
  [MaxLength(100), MinLength(6)]
  [EmailAddress(ErrorMessage = "Email address is not valid")]
  public string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = "Password is required")]
  [MaxLength(25), MinLength(8)]
  public string Password { get; set; } = string.Empty;

  [Required(ErrorMessage = "Mobile number is required")]
  // [MinLength(9)]
  public int Mobile { get; set; }

  public string Image { get; set; } = string.Empty;

  public DateTime CreatedAt { get; set; }

  // Relations
  // public ICollection<Product> Products { get; set; }
}
