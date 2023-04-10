namespace InstargramCreator.Entities
{
    public class Accounts
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Proxy { get; set; }
        public string FullName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}