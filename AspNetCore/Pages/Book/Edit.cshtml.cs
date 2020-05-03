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
    public class EditModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }
        private readonly IBookAction bookAction;

        public EditModel(IBookAction bookAction)
        {
            this.bookAction = bookAction;
        }

        public void OnGet(int? bookId)
        {
            if (bookId.HasValue)
                Book = bookAction.GetById(bookId.Value);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                bookAction.Update(Book);
            }
            bookAction.Commit();
            return RedirectToPage("./List");
        }
    }
}