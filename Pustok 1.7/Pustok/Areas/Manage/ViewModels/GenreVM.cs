using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.ViewModels
{
    public class GenreVM
    {
        public List<Genre> Genres { get; set; }
        public PageNationVM pageNation { get; set; }
    }
}
