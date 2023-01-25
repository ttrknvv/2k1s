using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab13
{
    interface ISerialize
    {
        void SOAPSerialize(object obj, string path);
        void XMLSerialize(Hanger obj, string path);
        void BinarySerialize(object obj, string path);
        void JSONSerialize(Hanger obj, string path);
        Hanger SOAPDeserialize(string path);
        Hanger XMLDeserialize(string path);
        Hanger BinaryDeserialize(string path);
        Hanger JSONDeserialize(string path);

    }
}
