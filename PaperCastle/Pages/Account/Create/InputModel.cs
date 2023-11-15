// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;
namespace PaperCastle.WebUI.Pages.Account.Create;
public class InputModel
{
    [Required]
    public string Username { get; set; }

    [Required, MinLength(8)]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? ReturnUrl { get; set; }
    public string Button { get; set; }
}