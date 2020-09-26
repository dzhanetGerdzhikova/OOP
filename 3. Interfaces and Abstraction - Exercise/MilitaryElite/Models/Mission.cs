namespace MilitaryElite
{
    public enum StateMission
    {
        inProgress = 1,
        Finished = 2
    }

    public class Mission : IMission
    {
        public Mission(string codeName, StateMission stateMission)
        {
            StateMission = stateMission;
            CodeName = codeName;
        }

        public StateMission StateMission { get; private set; }

        public string CodeName { get; private set; }

        public void CompleteMission()
        {
            StateMission = StateMission.Finished;
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {StateMission}";
        }
    }
}