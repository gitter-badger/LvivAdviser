﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LvivAdviser.Domain.Abstract;
using LvivAdviser.Domain.Entities;
using LvivAdviser.Domain.Abstract.Interfaces;
using LvivAdviser.WebUI.Models;

namespace LvivAdviser.WebUI.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        private IContentRepository repository;
        public int PageSize = 4;

        public ContentController(IContentRepository contentRepository)
        {
            this.repository = contentRepository;
        }

        public ViewResult List(string type, int page = 1)
        {
            ContentListViewModel model = new ContentListViewModel
            {
                Contents = repository.Content.Where(p => type == null || p.Type.ToString() == type).OrderBy(p => p.ID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = type == null ? repository.Content.Count() : repository.Content.Where(e => e.Type.ToString() == type).Count()
                },
                CurrentType = type
            };
            return View(model);
        }
    }
}