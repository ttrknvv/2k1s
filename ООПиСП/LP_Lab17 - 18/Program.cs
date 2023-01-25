using System;

namespace lab17
{
    internal class Program
    {
        public enum TypeOfWork
        {
            installDoors = 1,
            installWindows = 2,
            paintWalls = 3,
            vyselitNafig = 4
        }

        public interface IAbstractBrigade
        {
            IBoss CreateBoss();

            IBrigade CreateBrigade();
        }

        public interface IBiuldRequest
        {
            DateTime CreateDeadline();

            int typeOfWork(int typeNumber);

            int volume(int volumeOfWork);
        }

        public interface IBiuldWorkPlan
        {
            IBrigade Brigade
            {
                get;
                set;
            }

            DateTime DeadLine
            {
                get;
                set;
            }

            int TypeOfWork
            {
                get;
                set;
            }

            int Volume
            {
                get;
                set;
            }
        }

        public interface IBoss
        {
            int SkillPoints { get; }
        }

        public interface IBrigade
        {
            public void DoTask();
        }

        private static void Main(string[] args)
        {
            //IBiuldRequest biuldRequest
            Dispatcher.GetInstance();
            //Console.WriteLine(Dispatcher.GetInstance());
            IBiuldRequest urgentRequest = new UrgentRequest();
            urgentRequest.CreateDeadline();
            urgentRequest.typeOfWork((int)TypeOfWork.installDoors);
            urgentRequest.volume(10);
            Dispatcher.Request = urgentRequest;

            ExtendedBrigadeFactory extendedBrigade = new ExtendedBrigadeFactory();
            Dispatcher.boss = extendedBrigade.CreateBoss();
            Dispatcher.brigade = extendedBrigade.CreateBrigade();
            //Dispatcher.boss = boss;
            //Dispatcher.brigade = brigade;
            Dispatcher.brigade.DoTask();
            Dispatcher.WorkPlan = new WorkPlan
            {
                Brigade = Dispatcher.brigade,
                DeadLine = Dispatcher.Request.CreateDeadline()
            };
        }

        public class ApartmentConsumer
        {
            //private Request _request;
        }

        public class Brigade : IBrigade
        {
            private int _amountOfWorkers = 10;
            public int Workers => this._amountOfWorkers;

            public Brigade CloneBrigade()
            {
                Brigade clone = (Brigade)MemberwiseClone();
                return clone;
            }

            public void DoTask()
            {
                Console.WriteLine("Doing the task");
            }
        }

        public class BrigadeFactory : IAbstractBrigade
        {
            public IBoss CreateBoss()
            {
                return new ExpiriencedBoss();
            }

            public IBrigade CreateBrigade()
            {
                return new Brigade();
            }

            //private
        }

        public class ExpireincedBoss : IBoss
        {
            public int SkillPoints => 10;
        }

        public class ExpiriencedBoss : IBoss
        {
            public int SkillPoints => 10;
        }

        public class Extended : IBrigade
        {
            private int _amountOfWorkers = 15;
            public int Workers => this._amountOfWorkers;

            public Extended CloneBrigade()
            {
                Extended clone = (Extended)MemberwiseClone();
                return clone;
            }

            public void DoTask()
            {
                Console.WriteLine("Doing task quickly");
            }
        }

        public class ExtendedBrigadeFactory : IAbstractBrigade
        {
            public IBoss CreateBoss()
            {
                return new ExpiriencedBoss();
            }

            public IBrigade CreateBrigade()
            {
                return new Extended();
            }
        }

        public class NormalRequest : IBiuldRequest
        {
            public DateTime CreateDeadline()
            {
                return DateTime.Now.AddDays(7);
            }

            public int typeOfWork(int typeNumber)
            {
                return typeNumber;
            }

            public int volume(int volumeOfWork)
            {
                if (volumeOfWork > 10)
                {
                    Console.WriteLine("ty cho, gde ya tebe stol'ko rabotnikov naidu?\n idi sam strol'ko raboty delai, umnik" +
                        "\n cho? hata nastol'ko bol'shaya, chto reshil sebe 10 dverei prisobachit'? a?\n" +
                        "ya tebe vot chto skazu, ya v svoyom poznanii nastol'ko preispolinlsya," +
                        "\n sho ya kak budto by uzhe sto trillionov milliardov let mlya prozhivay na\n" +
                        "trillionah takih zhe planet, ponimaesh' kak eta Zemlya,\n" +
                        "mne uzhe etot mir absolutno ponyaten, ya ischu tol'ko odnogo\n" +
                        "pokoya, umirotvorenia i vot etoi garmonii ot sliyaniya s beskonecho-vechnym...");
                    return 0;
                }
                else
                {
                    return volumeOfWork;
                }
            }
        }

        public class UrgentRequest : IBiuldRequest
        {
            public DateTime CreateDeadline()
            {
                return DateTime.Now.AddDays(1);
            }

            public int typeOfWork(int typeNumber)
            {
                return typeNumber;
            }

            public int volume(int volumeOfWork)
            {
                if (volumeOfWork > 10)
                {
                    Console.WriteLine("ty cho, gde ya tebe stol'ko rabotnikov naidu?\n idi sam strol'ko raboty delai, umnik" +
                        "\n cho? hata nastol'ko bol'shaya, chto reshil sebe 10 dverei prisobachit'? a?\n" +
                        "ya tebe vot chto skazu, ya v svoyom poznanii nastol'ko preispolinlsya," +
                        "\n sho ya kak budto by uzhe sto trillionov milliardov let mlya prozhivay na\n" +
                        "trillionah takih zhe planet, ponimaesh' kak eta Zemlya,\n" +
                        "mne uzhe etot mir absolutno ponyaten, ya ischu tol'ko odnogo\n" +
                        "pokoya, umirotvorenia i vot etoi garmonii ot sliyaniya s beskonecho-vechnym...");
                    return 0;
                }
                else
                {
                    return volumeOfWork;
                }
            }
        }

        public class WeekWorkPlan : IBiuldWorkPlan
        {
            private IBrigade _brigade;
            private DateTime _deadline;

            public IBrigade Brigade
            {
                set => this._brigade = value;
                get => this._brigade;
            }

            public DateTime DeadLine
            {
                get => this._deadline;
                set => this._deadline = value;
            }

            public int TypeOfWork
            {
                get;
                set;
            }

            public int Volume

            {
                get;
                set;
            }
        }

        public class WorkPlan : IBiuldWorkPlan
        {
            private IBrigade _brigade;
            private DateTime _deadline;

            public IBrigade Brigade
            {
                set => this._brigade = value;
                get => this._brigade;
            }

            public DateTime DeadLine
            {
                get => this._deadline;
                set => this._deadline = value;
            }

            public int TypeOfWork
            {
                get;
                set;
            }

            public int Volume

            {
                get;
                set;
            }
        }

        private sealed class Dispatcher
        {
            public static IBoss boss;
            public static IBrigade brigade;

            //public static IAbstractBrigade Brigade;
            public static IBiuldRequest Request;

            public static WorkPlan workplan;
            public static IBiuldWorkPlan WorkPlan;
            private static readonly Lazy<Dispatcher> Lazy = new Lazy<Dispatcher>(() => new Dispatcher());

            private Dispatcher()
            {
            }

            public static Dispatcher GetInstance()
            {
                return Lazy.Value;
            }
        }
    }
}