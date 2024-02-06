namespace Entites
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Account { get; set; }
        public string AccountType { get; set; }
        public DateTime DataCreated { get; set; }

        public ICollection<Character>Characters { get; set; }

        public Player() 
        {
            DataCreated = DateTime.Now;
        }
    }
}
