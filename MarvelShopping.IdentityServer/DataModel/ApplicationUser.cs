using Microsoft.AspNetCore.Identity;

namespace MarvelShopping.IdentityServer.DataModel
{
    public class ApplicationUser : IdentityUser
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
    }
}
