using Microsoft.AspNetCore.Identity;

namespace MarvelShopping.IdentityServer.DataModel
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
