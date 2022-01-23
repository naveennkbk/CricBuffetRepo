using CricBuffet.Areas.Media.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricBuffet.Areas.Media.Controllers
{
    [Area("Media")]
    public class MediaDetailController : Controller
    {
        private readonly CricDbContext cricDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MediaDetailController(CricDbContext cricDbContexts, IWebHostEnvironment hostEnvironment)
        {
            cricDbContext = cricDbContexts;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MediaDetailList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult MediaDetailListing()
        {
            List<MediaDetail> mediaDetails = new List<MediaDetail>();
            mediaDetails = cricDbContext.MediaDetail.Where(x => x.IsActive == 0).Select(c => c).ToList();
            return Json(new { data = mediaDetails });
        }

        [HttpGet]
        public IActionResult MediaDetailCreate()
        {
            ViewData["BuddyId"] = new SelectList(cricDbContext.Buddy, "ID", "BuddyName");
            ViewData["MediaTag"] = new SelectList(cricDbContext.MediaTag, "ID", "TagName");
            return View();
        }

        [HttpGet]
        public IActionResult MediaDetailEdit(int? id)
        {
            var mediaDetailList = cricDbContext.MediaDetail.Where(x => x.ID == id).FirstOrDefault();
            ViewData["BuddyId"] = new SelectList(cricDbContext.Buddy, "ID", "BuddyName");
            ViewData["MediaTag"] = new SelectList(cricDbContext.MediaTag, "ID", "TagName");
            return View(mediaDetailList);
        }

        [HttpPost]
        public IActionResult MediaDetailEdit(MediaDetail mediaDetail)
        {
            if (mediaDetail.ID == 0)
            {
                MediaDetail mediaDetail1 = new MediaDetail
                {
                    MediaDescription = mediaDetail.MediaDescription,
                    MediaTitle = mediaDetail.MediaTitle,
                    BuddyId = mediaDetail.BuddyId,
                    MediaTag = mediaDetail.MediaTag,
                    IsActive = 0
                };

                cricDbContext.Add(mediaDetail1);
                cricDbContext.SaveChanges();
            }
            else
            {
                MediaDetail mediaDetail1 = cricDbContext.MediaDetail.Find(mediaDetail.ID);
                MediaDetail mediaDetail2 = new MediaDetail
                {
                    MediaDescription = mediaDetail.MediaDescription,
                    MediaTitle = mediaDetail.MediaTitle,
                    BuddyId = mediaDetail.BuddyId,
                    MediaTag = mediaDetail.MediaTag,
                    IsActive = 0
                };

                
               
                cricDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(MediaDetailList));
        }

        [HttpPost]
        public IActionResult MediaDetailDelete(int id)
        {
            MediaDetail mediaDetail = cricDbContext.MediaDetail.Find(id);
            mediaDetail.IsActive = 1;
           
            cricDbContext.SaveChanges();

            return RedirectToAction(nameof(mediaDetail));
        }
    }
}