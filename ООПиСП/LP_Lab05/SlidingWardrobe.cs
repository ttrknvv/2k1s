using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab04
{
    partial class SlidingWardrobe : Furniture, ICount
    {
        private int _count;
        private string _nameOfSlidingWardrobe;
        public string NameOfBed
        {
            get
            {
                return _nameOfSlidingWardrobe;
            }
            set
            {
                _nameOfSlidingWardrobe = value;
            }
        }
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }
        public override partial string ToString();
        public override partial void GetInfoOfProduct();
        
        public partial void Refund();

        public partial void Buy();
        
    }
}
