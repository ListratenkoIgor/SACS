using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using SACS_Server.Authentification.Data.Enums;
namespace SACS_Server.Areas.Identity.Pages.Account
{
    //[AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            foreach (var roleName in System.Enum.GetNames(typeof(SACS_Server.Authentification.Data.Enums.UserRole)))
            {
                _roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string UserName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            //[DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            //[Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            public List<SelectListItem> Options { get; set; }

            InputModel() : base()
            {
                Options = System.Enum.GetNames(typeof(SACS_Server.Authentification.Data.Enums.UserRole)).Select(a =>
                    new SelectListItem
                    {
                        Value = a.ToString(),
                        Text = a.ToString()
                    }).ToList();
            }
        }
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            await AddRoleToUserByEmail("85100093");
            if (false)
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.UserName, Email = Input.UserName };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        public async Task<IActionResult> AddRoleToUserByEmail(string Email) {
            var user1 = await _userManager.FindByEmailAsync(Email);
            if (user1 != null)
            {
                IdentityResult result = await _userManager.AddToRoleAsync(user1,UserRole.SuperAdmin.ToString());
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return null;//will be IMyResult
        }
        public async Task<IActionResult> DeleteUserByEmail(string Email)
        {
            var user1 = await _userManager.FindByEmailAsync(Email);
            if (user1 != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user1);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return null;//will be IMyResult
        }
    }
}
