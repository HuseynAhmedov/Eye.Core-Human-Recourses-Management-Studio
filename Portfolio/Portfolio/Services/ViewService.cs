using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public class ViewService
    {
        DataContext _context;
        public ViewService(DataContext context)
        {
            _context = context;
        }
        
        public List<Setting> GetSettings()
        {
            List<Setting> settingsList = _context.Settings.ToList();
            return settingsList;
        }
    }
}
