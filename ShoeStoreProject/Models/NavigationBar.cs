using Microsoft.AspNetCore.Mvc;

namespace ShoeStoreProject.Models
{
    public class NavigationBar : ViewComponent
    {
        public IViewComponentResult Invoke(){
            return View(); 
        }
    }
}
