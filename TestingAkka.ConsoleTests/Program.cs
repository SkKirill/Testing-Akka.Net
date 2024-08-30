using Akka.Actor;
using TestingAkka.ConsoleTests.TestIotSupervisor;
using TestingAkka.ConsoleTests.TestsCreateActors;
using TestingAkka.ConsoleTests.TestStartStopActor;
using TestingAkka.ConsoleTests.TestSupervisingActor;

namespace TestingAkka.ConsoleTests
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CreateActorTest();
            //StartStopActorTest();
            //SupervisingActorTest();
            TestIotSupervisor();
        }

        private static void TestIotSupervisor()
        {
            using (var system = ActorSystem.Create("iot-system"))
            {
                // Create top level supervisor
                var supervisor = system.ActorOf(IotSupervisor.Props(), "iot-supervisor");
                // Exit the system after ENTER is pressed
                Console.ReadLine();
            }
        }

        private static void SupervisingActorTest()
        {
            var Sys = ActorSystem.Create("MySystemActor");
            var supervisingActor = Sys.ActorOf(Props.Create<SupervisingActor>(), "supervising-actor");
            supervisingActor.Tell("failChild");

            Thread.Sleep(2000);
        }

        private static void StartStopActorTest()
        {
            var Sys = ActorSystem.Create("MySystemActor");
            var first = Sys.ActorOf(Props.Create<StartStopActor1>(), "first");
            first.Tell("stop");

            Thread.Sleep(100);
        }

        private static void CreateActorTest()
        {
            var Sys = ActorSystem.Create("MySystemActor");
            var firstRef = Sys.ActorOf(Props.Create<PrintMyActorRefActor>(), "first-actor");
            Console.WriteLine($"First: {firstRef}");
            firstRef.Tell("printit", ActorRefs.NoSender);
        }
    }
}
