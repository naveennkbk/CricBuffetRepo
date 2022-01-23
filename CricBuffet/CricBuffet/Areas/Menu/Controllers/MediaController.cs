using CricBuffet.Areas.Menu.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricBuffet.Areas.Menu.Controllers
{
    [Area("Menu")]
    public class MediaController : Controller
    {
        private readonly CricDbContext cricDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MediaController(CricDbContext cricDbContexts, IWebHostEnvironment hostEnvironment)
        {
            cricDbContext = cricDbContexts;
            webHostEnvironment = hostEnvironment;
        }

      
        public IActionResult MediaList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult MenuListing()
        {
            List<MediaMenu> menulist = new List<MediaMenu>();
            menulist = cricDbContext.MediaMenu.Where(x => x.IsActive == 0).Select(c => c).ToList();
            return Json(new { data = menulist });
        }

        [HttpGet]
        public IActionResult MenuCreate(int id = 0)
        {
            return View();
        }

        [HttpGet]
        public IActionResult MenuView(int? id)
        {
            var menuList = cricDbContext.MediaMenu.Where(x => x.Id == id).FirstOrDefault();

            return View(menuList);
        }

        [HttpGet]
        public IActionResult MenuEdit(int? id)
        {
            var menuList = cricDbContext.MediaMenu.Where(x => x.Id == id).FirstOrDefault();

            return View(menuList);
        }

        [HttpPost]
        public IActionResult MenuEdit(MediaMenu mediaMenu)
        {
            //if (ModelState.IsValid)
            //{
            if (mediaMenu.Id == 0)
            {
                MediaMenu menuObj = new MediaMenu
                {
                    MediaMenuName = mediaMenu.MediaMenuName,
                    CreatedDate = DateTime.Now,
                    EditDate = DateTime.Now,
                    IsActive = 0
                };

                cricDbContext.Add(menuObj);
                cricDbContext.SaveChanges();
            }
            else
            {
                MediaMenu menuObj = cricDbContext.MediaMenu.Find(mediaMenu.Id);

                menuObj.MediaMenuName = mediaMenu.MediaMenuName;
                menuObj.EditDate = DateTime.Now;
                cricDbContext.Update(menuObj);
                cricDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(MediaList));
        }

        [HttpPost]
        public IActionResult MenuDelete(int id)
        {
            MediaMenu menu = cricDbContext.MediaMenu.Find(id);
            menu.IsActive = 1;
            cricDbContext.Update(menu);
            cricDbContext.SaveChanges();

            return RedirectToAction(nameof(MediaList));
        }
    }
}