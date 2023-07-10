using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediadorFacil.Domain.Account;
using MediadorFacil.Infrastructure.Context;

namespace MediadorFacil.Api.Pages.Cliente
{
    public class IndexModel : PageModel
    {
        private readonly MediadorFacil.Infrastructure.Context.MediadorFacilContext _context;

        public IndexModel(MediadorFacil.Infrastructure.Context.MediadorFacilContext context)
        {
            _context = context;
        }

        public IList<Empresa> Empresa { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Empresas != null)
            {
                Empresa = await _context.Empresas
                .Include(e => e.User).ToListAsync();
            }
        }
    }
}
