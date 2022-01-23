using Microsoft.AspNetCore.Mvc;
using CricBuffet.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CricBuffet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BuddyController : Controller
    {
        private readonly CricDbContext cricDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BuddyController(CricDbContext cricDbContexts, IWebHostEnvironment hostEnvironment)
        {
            cricDbContext = cricDbContexts;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult BuddyList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult BuddyListing()
        {
            List<Buddy> buddys = new List<Buddy>();
            buddys = cricDbContext.Buddy.Where(x => x.IsActive == 0).Select(c => c).ToList();
            return Json(new { data = buddys });
        }

        [HttpGet]
        public IActionResult BuddyCreate(int id = 0)
        {
            return View();
        }

        [HttpGet]
        public IActionResult BuddyView(int? id)
        {
            var buddyList = cricDbContext.Buddy.Where(x => x.ID == id).FirstOrDefault();

            var buddyListView = new BuddyViewModel
            {
                BuddyName = buddyList.BuddyName,
                BuddyPicture = buddyList.BuddyPicture,
                ID = buddyList.ID
            };

            return View(buddyListView);
        }

        [HttpGet]
        public IActionResult BuddyEdit(int? id)
        {
            var buddyList = cricDbContext.Buddy.Where(x => x.ID == id).FirstOrDefault();

            var buddyListEdit = new BuddyViewModel
            {
                BuddyName = buddyList.BuddyName,
                BuddyPicture = buddyList.BuddyPicture,
                ID = buddyList.ID,
            };

            return View(buddyListEdit);
        }

        [HttpPost]
        public IActionResult BuddyEdit(BuddyViewModel buddy)
        {
            //if (ModelState.IsValid)
            //{
            string uniqueFileName = UploadedFile(buddy);
            if (buddy.ID == 0)
            {
                Buddy buddyObj = new Buddy
                {
                    BuddyName = buddy.BuddyName,
                    CreatedDate = DateTime.Now,
                    EditDate = DateTime.Now,
                    BuddyPicture = uniqueFileName,
                    IsActive = 0
                };

                cricDbContext.Add(buddyObj);
                cricDbContext.SaveChanges();
            }
            else
            {
                uniqueFileName = UploadedFile(buddy);
                Buddy buddyObj = cricDbContext.Buddy.Find(buddy.ID);

                buddyObj.BuddyName = buddy.BuddyName;
                buddyObj.EditDate = DateTime.Now;
                buddyObj.BuddyPicture = uniqueFileName;
                cricDbContext.Update(buddyObj);
                cricDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(BuddyList));
            //}
            //return View(buddy);
        }

        private string UploadedFile(BuddyViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpPost]
        public IActionResult BuddyDelete(int id)
        {
            Buddy buddy = cricDbContext.Buddy.Find(id);
            buddy.IsActive = 1;
            cricDbContext.Update(buddy);
            cricDbContext.SaveChanges();

            return RedirectToAction(nameof(BuddyList));
        }
    }
}