using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace wumpus
{
    public class mybutton : Button
    {
       public bool isstench { get; set; }
       public bool isbreeze { get; set; }
       public bool isbump { get; set; }
       public bool isscream { get; set; }
       public bool iswumpus { get; set; }
       public bool ispit { get; set; }
       public bool isgold { get; set; }
       public bool isCurrent { get; set; }

        public  mybutton() 
        {
            
        }

    }


}
