﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Controllers;
using HongGia.Core.Models;
using HongGia.Core.Models.Base;
using HongGia.Models;

namespace HongGia.Controllers
{
    public class PhotoController : DefaultController
    {

        private AllPhotoViewModel temp = new AllPhotoViewModel()
        {
            Categories = new List<string>() { "cat1", "cat2", "cat3", "cat4", "cat5" },
            AllPhoto = new List<Photo>()
            {
                new Photo() {Id = 1, Name = "1", Path = "https://www.aviary.com/img/photo-landscape.jpg", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Photo() {Id = 2, Name = "2", Path = "http://static.bigstockphoto.com/images/homepage/2016_popular_photo_categories.jpg", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Photo() {Id = 3, Name = "3", Path = "https://iso.500px.com/wp-content/uploads/2016/06/stock-photo-142869191-1-1500x1000.jpg", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Photo() {Id = 4, Name = "4", Path = "https://lh3.googleusercontent.com/-jkGsCQ_VDm4/AAAAAAAAAAI/AAAAAAAAAAA/ZEhC2NmPfcw/photo.jpg", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 5, Name = "5", Path = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcRNcoFR6Sq-nv7-cPwmapzH62_KhmAeFFV7UHtjourdNwleyaTQ", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 6, Name = "6", Path = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR6oSBLS9DxvENlC-Mwoi72wNsa80Dr5mU2KEt5txnStztL8FLa", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 7, Name = "7", Path = "7", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 8, Name = "8", Path = "8", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 9, Name = "9", Path = "9", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 10, Name = "10", Path = "10", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 11, Name = "11", Path = "11", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Photo() {Id = 12, Name = "12", Path = "12", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Photo() {Id = 13, Name = "13", Path = "13", Categories = new List<string>() { "cat2" }},
                new Photo() {Id = 14, Name = "14", Path = "14", Categories = new List<string>() { "cat2" }},
                new Photo() {Id = 15, Name = "15", Path = "15", Categories = new List<string>() { "cat4" }},
                new Photo() {Id = 16, Name = "16", Path = "16", Categories = new List<string>() { "cat4" }},
                new Photo() {Id = 17, Name = "17", Path = "17", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 18, Name = "18", Path = "18", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 19, Name = "19", Path = "19", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 20, Name = "20", Path = "20", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 21, Name = "21", Path = "21", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 22, Name = "22", Path = "22", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 23, Name = "23", Path = "23", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 24, Name = "24", Path = "24", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 25, Name = "25", Path = "25", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 26, Name = "26", Path = "26", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 27, Name = "27", Path = "27", Categories = new List<string>() { "cat1" }},
                new Photo() {Id = 28, Name = "28", Path = "28", Categories = new List<string>() { "cat1" }}
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