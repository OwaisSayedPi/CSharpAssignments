using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HW
{
    public class Home : Menu
    {
        public Home(Menu PreviousPage)
        {
            this.PreviousPage = PreviousPage;
            PageName = "Home";
            menu = new List<Menu>
            {
                new AddProd(this),
                new DelProd(this),
                new UpdateProd(this),
                new ViewAllProd(this),
                new ShowHistory(this)
            };
        }
    }
}
