using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Data
{
    public partial class HistoryView
    {
        public string InSale
        {
            get 
            {
                if (IsDeleted == true)
                {
                    return "Снят с продажи";
                }
                else
                {
                    return "В продаже";
                }
            }
        }
    }
}
