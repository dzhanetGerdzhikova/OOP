namespace BorderControl
{
    public interface ICitizen : ILivingCreature, ICreature, IBuyer
    {
        int Age { get; set; }
    }
}