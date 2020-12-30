using BuildingSite.Data.Entities.Base;

namespace BuildingSite.Data.Entities
{
    public class Admin : Entity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

    }
}
