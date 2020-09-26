namespace BorderControl
{
    public class Creature : ICreature
    {
        public Creature(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }

        public bool IsValidId(string number)
        {
            return Id.EndsWith(number);
        }
    }
}