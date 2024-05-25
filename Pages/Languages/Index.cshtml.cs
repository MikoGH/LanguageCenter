using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LanguageCenter.Data;
using LanguageCenter.Models;

namespace LanguageCenter.Pages.Languages
{
    public class LanguagesModel : PageModel
    {
        private readonly Context _context;

        public LanguagesModel(Context context)
        {
            _context = context;
        }

        public IList<LanguageEntity> Language { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Languages != null)
            {
                Language = await _context.Languages.ToListAsync();
            }
        }
    }
}
