namespace SOLID.TypeFormating
{
    public class XmlFormating : IFormating
    {
        public string TypeFormat =>
           @"
            <log>
            <date>{0}</date>
            <level>{1}</level>
            <message>{2}</message>
            ";
    }
}