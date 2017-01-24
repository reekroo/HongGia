using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Controllers;
using HongGia.Core.Models;
using HongGia.Models;

namespace HongGia.Controllers
{
    public class ArticleController : DefaultController
    {

        private AllArticlesViewModel temp = new AllArticlesViewModel()
        {
            Categories = new List<string>() { "cat1", "cat2", "cat3", "cat4", "cat5" },
            AllArticles = new List<Article>()
            {
                new Article() {Id = 1, Header = "1", HtmlText = "https://www.aviary.com/img/photo-landscape.jpg", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Article() {Id = 2, Header = "2", HtmlText = "http://static.bigstockphoto.com/images/homepage/2016_popular_photo_categories.jpg", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Article() {Id = 3, Header = "3", HtmlText = "https://iso.500px.com/wp-content/uploads/2016/06/stock-photo-142869191-1-1500x1000.jpg", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Article() {Id = 4, Header = "4", HtmlText = "https://lh3.googleusercontent.com/-jkGsCQ_VDm4/AAAAAAAAAAI/AAAAAAAAAAA/ZEhC2NmPfcw/photo.jpg", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 5, Header = "5", HtmlText = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcRNcoFR6Sq-nv7-cPwmapzH62_KhmAeFFV7UHtjourdNwleyaTQ", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 6, Header = "6", HtmlText = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR6oSBLS9DxvENlC-Mwoi72wNsa80Dr5mU2KEt5txnStztL8FLa", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 7, Header = "7", HtmlText = "7", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 8, Header = "8", HtmlText = "8", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 9, Header = "9", HtmlText = "9", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 10, Header = "10", HtmlText = "10", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 11, Header = "11", HtmlText = "11", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Article() {Id = 12, Header = "12", HtmlText = "12", Categories = new List<string>() { "cat1", "cat2", "cat3" }},
                new Article() {Id = 13, Header = "13", HtmlText = "13", Categories = new List<string>() { "cat2" }},
                new Article() {Id = 14, Header = "14", HtmlText = "14", Categories = new List<string>() { "cat2" }},
                new Article() {Id = 15, Header = "15", HtmlText = "15", Categories = new List<string>() { "cat4" }},
                new Article() {Id = 16, Header = "16", HtmlText = "16", Categories = new List<string>() { "cat4" }},
                new Article() {Id = 17, Header = "17", HtmlText = "17", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 18, Header = "18", HtmlText = "18", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 19, Header = "19", HtmlText = "19", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 20, Header = "20", HtmlText = "20", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 21, Header = "21", HtmlText = "21", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 22, Header = "22", HtmlText = "22", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 23, Header = "23", HtmlText = "23", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 24, Header = "24", HtmlText = "24", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 25, Header = "25", HtmlText = "25", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 26, Header = "26", HtmlText = "26", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 27, Header = "27", HtmlText = "27", Categories = new List<string>() { "cat1" }},
                new Article() {Id = 28, Header = "28", HtmlText = "28", Categories = new List<string>() { "cat1" }}
            }
        };


        public ActionResult AllArticles()
        {
            var result = temp;

            return View(result);
        }
        
        public ActionResult Article(int id)
        {
            var result = temp.AllArticles.FirstOrDefault(x => x.Id == id) as ArticleViewModel;

            return View(result);
        }
    }
}