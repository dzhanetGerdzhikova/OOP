namespace Robots.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        private string robotName = "Gosho";
        private int robotBattery = 100;
        private int managercapacity = 500;

        [SetUp]
        public void SetUpVariabls()
        {
            robot = new Robot(robotName, robotBattery);
            robotManager = new RobotManager(managercapacity);
        }

        [Test]
        public void SetUpNameCorrectly()
        {
            Assert.That(robot.Name, Is.EqualTo(robotName));
        }

        [Test]
        public void SetUpMaxBatteryCorrectly()
        {
            Assert.That(robot.MaximumBattery, Is.EqualTo(robotBattery));
        }

        [Test]
        public void SetUpCorrectlyThatMaxBatteryIsEqualToBattery()
        {
            Assert.That(robot.Battery, Is.EqualTo(robotBattery));
        }

        [Test]
        public void SetUpCorrectlyCapacityInCtro()
        {
            Assert.That(robotManager.Capacity, Is.EqualTo(managercapacity));
        }

        [Test]
        public void IsCountZeroByInitialRobot()
        {
            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void SetOfCapacityLessZeroThrowException()
        {
            Assert.That(() => new RobotManager(-50), Throws.ArgumentException);
        }

        [Test]
        public void ExsistRobotInCollectionThrowsException()
        {
            robotManager.Add(robot);
            Assert.That(() => robotManager.Add(robot), Throws.InvalidOperationException.And.Message.EqualTo($"There is already a robot with name {robotName}!"));
        }

        [Test]
        public void IsCapacityIsEqualToManagerCollection()
        {
            RobotManager secondMenager = new RobotManager(1);
            secondMenager.Add(robot);
            Robot secondRobot = new Robot("Ivan", 50);
            Assert.That(() => secondMenager.Add(secondRobot), Throws.InvalidOperationException.And.Message.EqualTo("Not enough capacity!"));
        }

        [Test]
        public void SuccsesfullyAdded()
        {
            Assert.That(() => robotManager.Add(robot), Throws.Nothing);
            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveRobotNullThrowException()
        {
            Robot secondRobot = new Robot("Djani", 10);
            Assert.That(() => robotManager.Remove(secondRobot.Name), Throws.InvalidOperationException.And.Message.EqualTo($"Robot with the name {secondRobot.Name} doesn't exist!"));
        }

        [Test]
        public void RemoveSuccsesfully()
        {
            robotManager.Add(robot);
            robotManager.Remove(robot.Name);
            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void ChargedRobotWithNameNullthrowException()
        {
            robotManager.Add(robot);
            Assert.That(() => robotManager.Charge("Djani"), Throws.InvalidOperationException.And.Message.EqualTo($"Robot with the name Djani doesn't exist!"));
        }

        [Test]
        public void SuccsesfullyChargedRobot()
        {
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "", 20);
            robotManager.Charge(robotName);
            Assert.That(robot.Battery, Is.EqualTo(robot.MaximumBattery));
        }

        [Test]
        public void RobotWithNameNullWorkThrowException()
        {
            Assert.That(() => robotManager.Work(null, "", 2), Throws.InvalidOperationException.And.Message.EqualTo($"Robot with the name {null} doesn't exist!"));
        }
        [Test]
        public void RobotWorkWithBatteryLessThanNeededBatteryThrowException()
        {
            robotManager.Add(robot);
            Assert.That(() => robotManager.Work(robot.Name, "", 110), Throws.InvalidOperationException.And.Message.EqualTo($"{robot.Name} doesn't have enough battery!"));
        }
        [Test]
        public void SuccsesfullyWork()
        {
            robotManager.Add(robot);
            int neededBattery = 20;
            int lessBattery = robot.Battery - neededBattery;
            robotManager.Work(robot.Name, "", neededBattery);
            Assert.That(robot.Battery, Is.EqualTo(lessBattery));
        }
    }
}