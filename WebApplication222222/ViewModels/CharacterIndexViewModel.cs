using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication222222.Models;


namespace WebApplication222222.ViewModels
{
    public class CharacterIndexViewModel
    {
        public IPagedList<Character> Characters { get; set; }
        // public IQueryable<Character> Characters { get; set; }
        public string Search { get; set; }
        public IEnumerable<ElementWithCount> CatsWithCount { get; set; }
        public string Element { get; set; }
        public string SortBy { get; set; }
        public Dictionary<string, string> Sorts { get; set; }
        public IEnumerable<SelectListItem> CatFilterItems
        {
            get
            {
                var allCats = CatsWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.ElementName,
                    Text = cc.CatNameWithCount
                });
                return allCats;
            }
        }

    }

    public class ElementWithCount
    {
        public int CharacterCount { get; set; }
        public string ElementName { get; set; }
        public string CatNameWithCount
        {
            get
            {
                return ElementName + " (" +
                CharacterCount.ToString() + ")";
            }
        }
    }


}