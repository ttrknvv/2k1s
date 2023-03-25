using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab18
{
    internal partial class Program
    {
        public class AdaptedRequestInfo : IBiuldRequest
        {
            private readonly NormalRequest _request;
            private readonly UrgentRequest _urgentRequest;

            public AdaptedRequestInfo(NormalRequest request)
            {
                this._request = request;
            }

            public AdaptedRequestInfo(UrgentRequest request)
            {
                this._urgentRequest = request;
            }

            public String ConvertRequestForClient()
            {
                return this._request.CreateDeadline().ToString();
            }

            public String ConvertUrgentForClient()
            {
                return this._urgentRequest.CreateDeadline().ToString();
            }

            public DateTime CreateDeadline()
            {
                return this._request.CreateDeadline();
            }

            public int typeOfWork(int typeNumber)
            {
                return typeNumber;
            }

            public int volume(int volumeOfWork)
            {
                return volumeOfWork;
            }
        }
    }
}