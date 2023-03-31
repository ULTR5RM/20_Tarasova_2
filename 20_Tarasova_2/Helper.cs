using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Tarasova_2
{
    class Helper
    {
            private static Entity.Entities Entityy;
            public static Entity.Entities getContext()
            {
                if (Entityy == null)
                {
                    Entityy = new Entity.Entities();
                }
                return Entityy;
            }
           
           
       
    }
}
