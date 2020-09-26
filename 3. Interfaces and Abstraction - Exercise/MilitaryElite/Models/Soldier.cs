namespace MilitaryElite
{
    public abstract class  Soldier : ISoldier
    {
        protected  Soldier(int id,string firstName, string lastName )
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}