namespace Bomtrato.ProcessManager.App.WebAPI.Domain.Domain
{
    public class ApproverDomain : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string OAB { get; set; }       
    }
}