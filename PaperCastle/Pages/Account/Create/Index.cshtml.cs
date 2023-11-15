using Duende.IdentityServer;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Duende.IdentityServer.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using PaperCastle.Core.Entity;
using PaperCastle.WebUI.Pages;
using System.Security.Claims;

namespace PaperCastle.WebUI.Pages.Account.Create
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class Index : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly TestUserStore _users;

       [BindProperty]
        public InputModel Input { get; set; }

        public Index(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IIdentityServerInteractionService interaction,
            TestUserStore users)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _users = users;
        }

        public IActionResult OnGet(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            Input = new InputModel { ReturnUrl = returnUrl };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var context = await _interaction.GetAuthorizationContextAsync(Input.ReturnUrl);


             if (Input.Button != "create")
        {
            if (context != null)
            {
                // if the user cancels, send a result back into IdentityServer as if they 
                // denied the consent (even if this client does not require consent).
                // this will send back an access denied OIDC error response to the client.
                await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);

                // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                if (context.IsNativeClient())
                {
                    // The client is native, so this change in how to
                    // return the response is for better UX for the end user.
                    return this.LoadingPage(Input.ReturnUrl);
                }

                return Redirect(Input.ReturnUrl);
            }
            else
            {
                // since we don't have a valid context, then we just go back to the home page
                return Redirect("~/");
            }
        }

            if (_users.FindByUsername(Input.Username) != null)
            {
                ModelState.AddModelError("Input.Username", "Invalid username");
            }

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Username,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    // Sign in the user after creating the account
                    var claims = new List<Claim>
                    {
                        new Claim("sub", user.Id)
                         // other claims...
                    };

                    await _userManager.AddClaimsAsync(user, claims);
                    await _signInManager.PasswordSignInAsync(user, Input.Password, false, lockoutOnFailure: false);

                    // Redirect to the return URL or a default page
                    return Redirect(string.IsNullOrEmpty(Input.ReturnUrl) ? "~/Home" : Input.ReturnUrl);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return Page();
        }
    }
}
