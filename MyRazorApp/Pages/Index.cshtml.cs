using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorApp.Pages;

public class Index : PageModel
{

    public List<Category> Categories {get;set;} = new();
    public async Task OnGet([FromRoute]int? skip, [FromRoute]int? take) 
    {


        if (!skip.HasValue || !take.HasValue)
        {
            Response.Redirect("/0/25");
            return;
        }

        var Temp = new List<Category>();
        await Task.Delay(5000);
        for (int i = 0; i <= 100; i++)
        {
            Temp.Add(new Category(i, $"Category {i}", i * 18.5M));
        }

        Categories = Temp
            .Skip(skip.GetValueOrDefault(0))
            .Take(take.GetValueOrDefault(25))
            .ToList();
    }

    public void OnPost() 
    {

    }
}


public record Category(int Id, string Title, decimal Price);