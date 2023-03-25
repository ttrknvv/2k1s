using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab18
{
    internal partial class Program
    {
        public interface IBiuldRequest
        {
            DateTime CreateDeadline();

            int typeOfWork(int typeNumber);

            int volume(int volumeOfWork);
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

        public class Password
        {
            public bool CheckPassword(string password)
            {
                if (password.Length <= 8)
                {
                    Console.WriteLine("password is too short");
                    return false;
                }
                else
                {
                    return true;
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

        public class UserName
        {
            public bool CheckUserName(string userName)
            {
                if (userName.Length > 10)
                {
                    Console.WriteLine("user name is too long");
                    return false;
                }
                else if (userName.Any(char.IsDigit))
                {
                    Console.WriteLine("user name can not contain digits");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}