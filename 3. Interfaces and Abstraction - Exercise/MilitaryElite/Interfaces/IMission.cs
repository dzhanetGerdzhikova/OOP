namespace MilitaryElite
{
    public interface IMission
    {
        StateMission StateMission { get; }

        string CodeName { get; }

        void CompleteMission();
    }
}