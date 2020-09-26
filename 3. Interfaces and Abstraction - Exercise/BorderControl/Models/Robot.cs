namespace BorderControl
{
    public class Robot : Creature, IRobot
    {
        public Robot(string model, string id) : base(id)
        {
            this.Model = model;
        }

        public string Model { get; set; }
    }
}