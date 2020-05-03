using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Core;
using AspNetCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AspNetCore
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IBookAction bookAction;

        public string Message { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public ListModel(IConfiguration config, IBookAction bookAction)
        {
            this.config = config;
            this.bookAction = bookAction;
        }

        public void OnGet()
        {
            Books = bookAction.GetList().ToList();
        }
    }
}