using System;
using System.Threading;

namespace lab18
{
    internal partial class Program
    {
        public interface IAbstractBrigade
        {
            IBoss CreateBoss();

            IBrigade CreateBrigade();
        }

        public interface IBoss
        {
            int SkillPoints { get; }

            void Notify();
        }

        public interface IBrigade
        {
            public void DoTask();
        }

        public class Boss : IBoss
        {
            public int SkillPoints => 10;

            public void Notify()

            {
                Thread.Sleep(200);
                Console.WriteLine("finished my work");
            }
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
                Thread.Sleep(400);
                Console.WriteLine("Doing the task");
            }
        }

        public class BrigadeFactory : IAbstractBrigade
        {
            public IBoss CreateBoss()
            {
                return new Boss();
            }

            public IBrigade CreateBrigade()
            {
                return new Brigade();
            }
        }

        public class ExpireincedBoss : IBoss
        {
            public int SkillPoints => 15;

            public void Notify()

            {
                Thread.Sleep(100);
                Console.WriteLine("finished my work");
            }
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
                Thread.Sleep(400);
                Console.WriteLine("Doing task quickly");
            }
        }

        public class ExtendedBrigadeFactory : IAbstractBrigade
        {
            public IBoss CreateBoss()
            {
                return new ExpireincedBoss();
            }

            public IBrigade CreateBrigade()
            {
                return new Extended();
            }
        }
    }
}