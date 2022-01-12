using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels
{
    public class StatusVM 
    {
        public int StatusId { get; set; } = (int)Statuses.Active;
        public string Name { get; set; } = string.Empty;
    }
}
