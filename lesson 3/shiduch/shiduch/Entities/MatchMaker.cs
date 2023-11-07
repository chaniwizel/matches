namespace Matches.Entities
{
    public enum Status { single, widow, divorcee }
    public class MatchMaker
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int id { get; set; }
    }
}
