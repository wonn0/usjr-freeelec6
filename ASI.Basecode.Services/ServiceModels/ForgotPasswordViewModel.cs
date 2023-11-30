using System.ComponentModel.DataAnnotations;

public class ForgotPasswordViewModel
{
    [Required]
    public string Email { get; set; }
}
