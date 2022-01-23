using CricBuffet.Areas.Tag.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricBuffet.Areas.Tag.Controllers
{
    [Area("Tag")]
    public class MediaTagController : Controller
    {
        private readonly CricDbContext cricDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MediaTagController(CricDbContext cricDbContexts, IWebHostEnvironment hostEnvironment)
        {
            cricDbContext = cricDbContexts;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MediaTagList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult MediaTagListing()
        {
            List<MediaTag> menulist = new List<MediaTag>();
            menulist = cricDbContext.MediaTag.Where(x => x.IsActive == 0).Select(c => c).ToList();
            return Json(new { data = menulist });
        }

        [HttpGet]
        public IActionResult MediaTagCreate(int id = 0)
        {
            return View();
        }

        [HttpGet]
        public IActionResult MediaTagEdit(int? id)
        {
            var menuList = cricDbContext.MediaTag.Where(x => x.ID == id).FirstOrDefault();

            return View(menuList);
        }

        [HttpPost]
        public IActionResult MediaTagEdit(MediaTag mediaTag)
        {
            //if (ModelState.IsValid)
            //{
            if (mediaTag.ID == 0)
            {
                MediaTag mediaTag1 = new MediaTag
                {
                    TagName = mediaTag.TagName,
                    CreatedDate = DateTime.Now,
                    EditDate = DateTime.Now,
                    IsActive = 0
                };

                cricDbContext.Add(mediaTag1);
                cricDbContext.SaveChanges();
            }
            else
            {
                MediaTag mediaTag1 = cricDbContext.MediaTag.Find(mediaTag.ID);

                mediaTag1.TagName = mediaTag1.TagName;
                mediaTag1.EditDate = DateTime.Now;
                cricDbContext.Update(mediaTag1);
                cricDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(MediaTagList));
        }

        [HttpPost]
        public IActionResult MediaTagDelete(int id)
        {
            MediaTag mediaTag = cricDbContext.MediaTag.Find(id);
            mediaTag.IsActive = 1;
            cricDbContext.Update(mediaTag);
            cricDbContext.SaveChanges();

            return RedirectToAction(nameof(MediaTagList));
        }
    }
}