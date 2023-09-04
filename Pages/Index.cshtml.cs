using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CW.Pages
{
    public class CreateModel : PageModel
    {
        //[BindProperty]
        //public YourModelClass YourModel { get; set; }

        public void OnGet()
        {
            // This is called when the page is initially loaded.
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // If the form validation fails, return the same page with validation errors.
                return Page();
            }

            // Handle the form submission here.
            // Access form data using `YourModel` properties.
            // Example: var projectName = YourModel.ProjectName;

            // Process file uploads if needed.
            foreach (var file in Request.Form.Files)
            {
                if (file != null && file.Length > 0)
                {
                    // Handle the file here, e.g., save it to a location.
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine("your/upload/directory", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            // Redirect to a different page or return a success message.
            return RedirectToPage("SuccessPage");
        }
    }
}
