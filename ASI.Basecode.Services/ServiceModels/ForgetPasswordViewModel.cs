using System.ComponentModel.DataAnnotations;

public class ForgetPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
