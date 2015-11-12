﻿namespace Habitat.News.Controller
{
  using System.Web.Mvc;
  using Habitat.Framework.SitecoreExtensions.Extensions;
  using Habitat.News.Repositories;
  using Sitecore.Mvc.Presentation;

  public class NewsController : Controller
  {
    private readonly INewsRepository _newsRepository;

    public NewsController() : this(new NewsRepository(RenderingContext.Current.Rendering.Item))
    {
    }

    public NewsController(INewsRepository newsRepository)
    {
      this._newsRepository = newsRepository;
    }

    public ActionResult NewsList()
    {
      var items = this._newsRepository.Get();
      return this.View("NewsList", items);
    }

    public ActionResult LatestNews()
    {
      var count = RenderingContext.Current.Rendering.GetIntegerParameter("count", 5);
      var items = this._newsRepository.GetLatestNews(count);
      return this.View("LatestNews", items);
    }
  }
}