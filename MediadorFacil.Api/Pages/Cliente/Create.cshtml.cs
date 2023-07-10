using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediadorFacil.Domain.Account;
using MediadorFacil.Infrastructure.Context;

namespace MediadorFacil.Api.Pages.Cliente
{
    public class CreateModel : PageModel
    {
        private readonly MediadorFacil.Infrastructure.Context.MediadorFacilContext _context;

        public CreateModel(MediadorFacil.Infrastructure.Context.MediadorFacilContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Empresa Empresa { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Empresas == null || Empresa == null)
            {
                return Page();
            }

            _context.Empresas.Add(Empresa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
