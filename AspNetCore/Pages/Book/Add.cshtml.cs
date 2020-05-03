using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Core;
using AspNetCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCore
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }
        private readonly IBookAction bookAction;

        public AddModel(IBookAction bookAction)
        {
            this.bookAction = bookAction;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                bookAction.Add(Book);
            }
            bookAction.Commit();
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("./List");
        }
    }
}