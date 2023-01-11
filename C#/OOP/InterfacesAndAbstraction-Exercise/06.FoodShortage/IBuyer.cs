using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    interface IBuyer
    {
        public int Food { get; set; }

        public void BuyFood();
    }
}
