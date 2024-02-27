// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using LeantIt.Web.Data;
using LeantIt.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LeantIt.Web.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AplicacaoUser> _signInManager;
        private readonly UserManager<AplicacaoUser> _userManager;
        private readonly IUserStore<AplicacaoUser> _userStore;
        private readonly IUserEmailStore<AplicacaoUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private AppDbContext _context;

        public RegisterModel(
            UserManager<AplicacaoUser> userManager,
            IUserStore<AplicacaoUser> userStore,
            SignInManager<AplicacaoUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager, AppDbContext appContext)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _context = appContext;

            Input = new InputModel
            {
                SelectRoles = roleManager.Roles.Select(role => new SelectListItem
                {
                    Value = role.Name,
                    Text = role.Name
                }).ToList()
            };
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public InputModel NomeExibicao { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public AluguelCarros Aluguel {  get; set; }
        public class InputModel
        {
            public string NomeExibicao { get; set; }
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Este campo deve ser preenchido")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Este campo deve ser preenchido")]
            [StringLength(100, ErrorMessage = "A senha deve ter no mínimo 2 caracteres, sendo uma letra maiúscula, 1 especial e 1 número.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "As credenciais devem ser iguais")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Este campo deve ser preenchido")]
            [MinLength(11, ErrorMessage = "A CNH deve ter no mínimo 11 caracteres")]
            [MaxLength(11, ErrorMessage = "A CNH deve ter no máximo 11 caracteres")]
            [Display(Name = "Digite a CNH")]
            public string CNH { get; set; }

            [Required(ErrorMessage = "Este campo deve ser preenchido")]
            [MinLength(14, ErrorMessage = "O CPF deve ter no mínimo 11 caracteres")]
            [MaxLength(14, ErrorMessage = "O CPF deve ter no máximo 11 caracteres")]
            [Display(Name = "Digite a CPF")]
            public string CPF { get; set; }

            [BindProperty]
            [Display(Name = "Escolha o sexo")]
            public string Sexo { get; set; }

            [Display(Name = "Digite o telefone")]
            public string Telefone { get; set; }

            [Display(Name = "Digite o nome")]
            public string Nome { get; set; }

            [Display(Name = "Data nascimento")]
            public string DataNascimento { get; set; }

            [Display(Name = "Celular")]
            public string Celular { get; set; }

            public bool ConfirmarCelular { get; set; }

            public string SelecionarRole { get; set; }

            [BindProperty]
            public List<SelectListItem> SelectRoles { get; set; }

        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                var idParaEncontrar = _signInManager.UserManager.GetUserId(User);
                var usuarioComNomeDeExibicao = _userManager.Users.FirstOrDefault(x => x.Id == idParaEncontrar);
                if (usuarioComNomeDeExibicao != null)
                {
                    NomeExibicao = new InputModel
                    {
                        NomeExibicao = usuarioComNomeDeExibicao.Nome
                    };
                }
                var user = User.Identity.Name;
                var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);

                var pendente = _context.AlguelCarros.FirstOrDefault(aluguelSelecionado => aluguelSelecionado.User == users.Id && aluguelSelecionado.Pendente == true);
                Aluguel = pendente;
            }

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {

                var user = new AplicacaoUser { 
                    UserName = Input.Email, 
                    Email = Input.Email, 
                    CNH = Input.CNH, 
                    CPF = Input.CPF, 
                    Sexo = Input.Sexo ?? "Desconhecido", 
                    Telefone = Input.Telefone, 
                    DataNascimento = Input.DataNascimento,
                    PhoneNumber = Input.Celular, 
                    Nome = Input.Nome };

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (!string.IsNullOrEmpty(Input.SelecionarRole))
                {
                    var roleExists = await _roleManager.RoleExistsAsync(Input.SelecionarRole);
                    if (roleExists)
                    {
                        await _userManager.AddToRoleAsync(user, Input.SelecionarRole);
                    }
                }

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);



                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, "Todos os campos devem ser preenchidos corretamente");
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private AplicacaoUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<AplicacaoUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(AplicacaoUser)}'. " +
                    $"Ensure that '{nameof(AplicacaoUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<AplicacaoUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<AplicacaoUser>)_userStore;
        }
    }
}
