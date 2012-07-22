#region

using System;
using System.Web.Mvc;
using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Services;
using TheNuggetList.WebUI.ViewModels;

#endregion

namespace TheNuggetList.WebUI.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberAuthenticationService _memberAuthenticationService;

        public MembersController(IServiceLocator serviceLocator)
        {
            _memberAuthenticationService = serviceLocator.Get<IMemberAuthenticationService>();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var emailInUse = _memberAuthenticationService.EmailAddressExists(viewModel.EmailAddress);
                var displayNameInUse = _memberAuthenticationService.DisplayNameExists(viewModel.DisplayName);

                if (!emailInUse && !displayNameInUse)
                {
                    _memberAuthenticationService.RegisterMember(new Member
                                                                    {
                                                                        EmailAddress = viewModel.EmailAddress,
                                                                        DisplayName = viewModel.DisplayName,
                                                                        Password = viewModel.Password
                                                                    });

                    return new RedirectResult("/");
                }
                else
                {
                    if (emailInUse)
                    {
                        ModelState.AddModelError("EmailAddress", "The email address specified is already in use");
                    }
                    if (displayNameInUse)
                    {
                        ModelState.AddModelError("DisplayName", "The display name specified is already in use");
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_memberAuthenticationService.LogInMember(viewModel.EmailAddress, viewModel.Password))
                {
                    return new RedirectResult("/");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login");
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            _memberAuthenticationService.LogOutMember();
            return new RedirectResult("/");
        }
    }
}