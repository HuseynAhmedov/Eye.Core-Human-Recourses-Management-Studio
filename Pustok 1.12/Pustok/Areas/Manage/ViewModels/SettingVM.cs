using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.ViewModels
{
    public class SettingVM
    {
        public List<Setting> Settings { get; set; }
        public int PageCount { get; set; }
        public int PageSelected { get; set; }
        public PageNationVM pageNation { get; set; }
    }
}
