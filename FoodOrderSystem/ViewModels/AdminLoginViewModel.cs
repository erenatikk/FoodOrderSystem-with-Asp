using System.ComponentModel.DataAnnotations;

public class AdminLoginViewModel
{
    [Required(ErrorMessage = "Admin kullanıcı adı gereklidir.")]
    public string AdminUserName { get; set; }

    [Required(ErrorMessage = "Admin şifresi gereklidir.")]
    [DataType(DataType.Password)]
    public string AdminPassword { get; set; }
}
