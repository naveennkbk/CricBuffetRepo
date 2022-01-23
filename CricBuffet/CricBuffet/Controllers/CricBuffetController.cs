using CricBuffet.Areas.Media.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricBuffet.Controllers
{
    public class CricBuffetController : Controller
    {
        private readonly CricDbContext cricDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CricBuffetController(CricDbContext cricDbContexts, IWebHostEnvironment hostEnvironment)
        {
            cricDbContext = cricDbContexts;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetFirstSlot()
        {
            try
            {
                var mediaDetailList = cricDbContext.MediaDetail.Where(x => x.IsActive == 0).First();

                return Json(mediaDetailList);
            }
            catch (Exception ex)
            {
                return Json(data: ex);
            }
        }

        [HttpGet]
        public ContentResult GetBuddyName(int BuddyId)
        {
            var buddyName = cricDbContext.Buddy.Where(x => x.ID == BuddyId).Select(x => x.BuddyName).FirstOrDefault();
            return Content(buddyName);
        }

        [HttpGet]
        public ContentResult GetMediaTagName(int TagId)
        {
            var mediaTagName = cricDbContext.MediaTag.Where(x => x.ID == TagId).Select(x => x.TagName).FirstOrDefault();
            return Content(mediaTagName);
        }

        public IActionResult GetMediaDetailView(MediaDetail mediaDetail)
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetMediaDetailViewDetails(MediaDetail mediaDetail)
        {
            int MediaDetailId;
            MediaDetailId = int.Parse(TempData["ID"].ToString());
            var mediaDetails = cricDbContext.MediaDetail.Where(x => x.ID == MediaDetailId).FirstOrDefault();
            return Json(mediaDetails);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}