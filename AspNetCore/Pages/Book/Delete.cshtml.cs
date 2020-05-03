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
    public class DeleteModel : PageModel
    {
        public Book Book { get; set; }
        private readonly IBookAction bookAction;

        public DeleteModel(IBookAction bookAction)
        {
            this.bookAction = bookAction;
        }
        public IActionResult OnGet(int bookId)
        {
            Book = bookAction.GetById(bookId);
            if (Book == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int bookId)
        {
            var restaurant = bookAction.Delete(bookId);
            bookAction.Commit();

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return RedirectToPage("./List");
        }
    }
}