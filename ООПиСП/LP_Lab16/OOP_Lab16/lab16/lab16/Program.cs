namespace lab16
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }

        public class ApartmentConsumer
        {
            private Request _request;
            public Request CurrentRequest => this._request;

            public void createRequest(string deadline, string typeofwork, string volume)
            {
                this._request = new Request
                {
                    Deadline = deadline,
                    TypeOfWork = typeofwork,
                    Volume = volume
                };
            }

            public class Request
            {
                private string deadline;
                private string typeOfWork;
                private string volume;

                public string Deadline
                {
                    get => this.deadline;
                    set => this.deadline = value;
                }

                public string TypeOfWork
                {
                    get => this.typeOfWork;
                    set => this.typeOfWork = value;
                }

                public string Volume
                {
                    get => this.volume;
                    set => this.volume = value;
                }
            }
        }

        private static class Dispatcher
        {
            private static ApartmentConsumer _currentCustomer;

            public static ApartmentConsumer CurrentCustomer
            {
                get;
                set;
            }

            public static Brigade registerBrigade(ApartmentConsumer currentCustomer)
            {
                Brigade brigade = new Brigade();
                brigade.currentCustomer.CurrentRequest;
            }
        }

        private static class WorkPlan
        {
        }

        private class Brigade
        {
            //private
        }
    }
}