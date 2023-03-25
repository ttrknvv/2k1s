using System;

namespace lab18
{
    internal partial class Program
    {
        public enum TypeOfWork
        {
            installDoors = 1,
            installWindows = 2,
            paintWalls = 3,
            vyselitNafig = 4
        }

        public interface IDispatcher
        {
            static void Notify(object sender, string msg)
            {
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            UserName validator = new UserName();
            if (validator.CheckUserName(name)
)
            {
                Console.WriteLine("Enter your password");
                string password = Console.ReadLine();
                Password passwordValidator = new Password();
                passwordValidator.CheckPassword(password);
            }

            Dispatcher.GetInstance();
            IBiuldRequest urgentRequest = new UrgentRequest();
            urgentRequest.CreateDeadline();
            urgentRequest.typeOfWork((int)TypeOfWork.installDoors);
            urgentRequest.volume(10);
            Dispatcher.Request = urgentRequest;

            ExtendedBrigadeFactory extendedBrigade = new ExtendedBrigadeFactory();
            Dispatcher.boss = extendedBrigade.CreateBoss();
            Dispatcher.brigade = extendedBrigade.CreateBrigade();
            Dispatcher.brigade.DoTask();
            Dispatcher.WorkPlan = new WorkPlan
            {
                Brigade = Dispatcher.brigade,
                DeadLine = Dispatcher.Request.CreateDeadline()
            };
        }

        public class Client
        {
            private string _deadeline;

            public string Dealine
            {
                get => this._deadeline;
                set => this._deadeline = value;
            }
        }

        public abstract class DecoratedBrigade : Brigade
        {
            protected Brigade _brigade;

            public DecoratedBrigade(Brigade brigade)
            {
                this._brigade = brigade;
            }
        }

        public sealed class Dispatcher : IDispatcher
        {
            public static IBoss boss;

            public static IBrigade brigade;

            public static IBiuldRequest Request;

            public static WorkPlan workplan;

            public static IBiuldWorkPlan WorkPlan;

            private static readonly Lazy<Dispatcher> Lazy = new Lazy<Dispatcher>(() => new Dispatcher());

            public Dispatcher(IBoss boss, IBrigade brigade)
            {
                boss = boss;
                brigade = brigade;
            }

            private Dispatcher()
            {
            }

            public static Dispatcher GetInstance()
            {
                return Lazy.Value;
            }

            public static void Nofity(object sender, string msg)
            {
                Console.WriteLine("brigade notified");
                brigade.DoTask();
            }
        }

        public class NotifyBrigade : DecoratedBrigade
        {
            public NotifyBrigade(Brigade brigade) : base(brigade)
            {
            }

            public void NotifyDispatcher()
            {
                Console.WriteLine("Dispatcher has been notified");
            }
        }
    }
}