namespace ESportTeamControll.Models
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string FantasyName { get; set; }
        public string Cnpj { get; set; }
        public User User { get; set; }
    }
}