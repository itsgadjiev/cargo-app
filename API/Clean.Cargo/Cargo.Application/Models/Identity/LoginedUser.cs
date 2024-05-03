namespace Cargo.Application.Models.Identity
{
    public class LoginedUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string PinCode { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }
        public List<string> Roles { get; set; }
    }
}
