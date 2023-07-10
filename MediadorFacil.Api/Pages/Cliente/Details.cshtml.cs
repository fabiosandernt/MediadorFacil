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
    public class DetailsModel : PageModel
    {
        private readonly MediadorFacil.Infrastructure.Context.MediadorFacilContext _context;

        public DetailsModel(MediadorFacil.Infrastructure.Context.MediadorFacilContext context)
        {
            _context = context;
        }

      public Empresa Empresa { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Empresas == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }
            else 
            {
                Empresa = empresa;
            }
            return Page();
        }
    }
}
