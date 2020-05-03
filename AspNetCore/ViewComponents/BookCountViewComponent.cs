using AspNetCore.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.ViewComponents
{
    public class BookCountViewComponent : ViewComponent
    {
        private readonly IBookAction bookAction;

        public BookCountViewComponent(IBookAction bookAction)
        {
            this.bookAction = bookAction;
        }

        public IViewComponentResult Invoke()
        {
            var count = bookAction.GetCountOfBooks();
            return View(count);
        }
    }
}
