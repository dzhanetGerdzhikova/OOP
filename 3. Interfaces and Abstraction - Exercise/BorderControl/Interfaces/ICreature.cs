namespace BorderControl
{
    public interface ICreature
    {
        string Id { get; }

        bool IsValidId(string number);
    }
}