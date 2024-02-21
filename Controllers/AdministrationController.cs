using INTEXAPP2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace INTEXAPP2.Controllers
{
    
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult userAuth()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(string userId)
        {
            //find user by userId
            //Add UserName to ViewBag
            //get userRole of users and send to view
            var user = await userManager.FindByIdAsync(userId);

            ViewBag.UserName = user.UserName;

            var userRoles = await userManager.GetRolesAsync(user);

            return View(userRoles);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult ManageRoles()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult AddRole()
        //{
        //    return RedirectToAction(nameof(DisplayRoles));
        //}

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddRole(string role)
        {
            //create new role using roleManager
            //return to displayRoles
            await roleManager.CreateAsync(new IdentityRole(role));
            return RedirectToAction(nameof(DisplayRoles));
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult DisplayRoles()
        {
            //get all roles and pass to view
            var roles = roleManager.Roles.ToList();

            return View(roles);
        }


        //[HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AddUserToRole()
        {
            //get all users
            //get all roles
            //create selectlist and pass using viewBag
            var users = userManager.Users.ToList();
            var roles = roleManager.Roles.ToList();

            ViewBag.Users = new SelectList(users, "Id", "UserName");
            ViewBag.Roles = new SelectList(roles, "Name", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddUserToRole(UserRole userRole)
        {
            //find user from userRole.UserId
            //assign role to user
            //redirect to index

            var user = await userManager.FindByIdAsync(userRole.UserId);

            await userManager.AddToRoleAsync(user, userRole.RoleName);

            return RedirectToAction(nameof(userAuth));
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RemoveUserRole(string role, string userName)
        {
            //get user from userName
            //remove role of user using userManager
            //return to details with parameter userId

            var user = await userManager.FindByNameAsync(userName);

            var result = await userManager.RemoveFromRoleAsync(user, role);

            return RedirectToAction(nameof(Details), new { userId = user.Id });
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RemoveUser(string userName)
        {
            //get role to delete using role Name
            //delete role using roleManager
            //redirect to displayroles

            var userToDelete = await userManager.FindByNameAsync(userName);
            var result = await userManager.DeleteAsync(userToDelete);

            return RedirectToAction(nameof(userAuth));
        }

    }
}
