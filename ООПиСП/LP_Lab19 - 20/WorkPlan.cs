using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab18
{
    internal partial class Program
    {
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
    }
}