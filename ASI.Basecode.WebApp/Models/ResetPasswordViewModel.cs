using System.ComponentModel.DataAnnotations;

public class ResetPasswordViewModel
{
    [Required]
    public string UserId { get; set; }

    [Required]
    public string Code { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }

    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}