using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.ViewModels
{
    public class AuthorVM
    {
        public List<Author> Authors { get; set; }
        public PageNationVM pageNation { get; set; }
    }
}
