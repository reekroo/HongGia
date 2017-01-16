﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HongGia.Core.Constants;
using HongGia.Core.Models;
using HongGia.Models;

namespace HongGia.Controllers
{
    public class PhotoController : Controller
    {

        private AllPhotoViewModel temp = new AllPhotoViewModel()
        {
            Categories = new List<string>() { "cat1", "cat2", "cat3", "cat4", "cat5" },
            AllPhoto = new List<Photo>()
            {
                new Photo() {Id = 1, Name = "1", Path = "1", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Photo() {Id = 2, Name = "2", Path = "2", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Photo() {Id = 3, Name = "3", Path = "3", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Photo() {Id = 4, Name = "4", Path = "4", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 5, Name = "5", Path = "5", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 6, Name = "6", Path = "6", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 7, Name = "7", Path = "7", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 8, Name = "8", Path = "8", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 9, Name = "9", Path = "9", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 10, Name = "10", Path = "10", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 11, Name = "11", Path = "11", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Photo() {Id = 12, Name = "12", Path = "12", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Photo() {Id = 13, Name = "13", Path = "13", Categories = new List<string>() { "cat2" }},
                new Photo() {Id = 14, Name = "14", Path = "14", Categories = new List<string>() { "cat2" }},
                new Photo() {Id = 15, Name = "15", Path = "15", Categories = new List<string>() { "cat4" }},
                new Photo() {Id = 16, Name = "16", Path = "16", Categories = new List<string>() { "cat4" }}
            }
        };

        // GET: Photo
        public ActionResult AllPhoto()
        {
            var result = temp;

            return View(result);
        }

        public ActionResult CategoryPhoto(string category,int pageNum = 0)
        {
            var result = new CategoryPhotoViewModel()
            {
                Category = category,
                CategoryPhoto = temp.AllPhoto.Where(x => x.Categories.Contains(category)).ToList()
            };

            ViewData["PageNum"] = pageNum;
            ViewData["ItemCount"] = result.CategoryPhoto.Count();
            ViewData["PageSize"] = PageConstants.PageCategoriesPhotoSize;

            result.CategoryPhoto = result.CategoryPhoto.OrderBy(p => p.Id).Skip(PageConstants.PageCategoriesPhotoSize * pageNum).Take(PageConstants.PageCategoriesPhotoSize).ToList();

            return View(result);
        }
    }
}