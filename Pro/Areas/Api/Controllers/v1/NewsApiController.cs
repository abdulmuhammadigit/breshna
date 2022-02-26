﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;


//namespace Hassab.Areas.Api.Controllers.v1
//{
//    [Route("api/v{version:apiVersion}/[controller]")]
//    [ApiVersion("1")]
//    [ApiResultFilter]
//    public class NewsApiController : Controller
//    {
//        public readonly IUnitOfWork _uw;
//        public NewsApiController(IUnitOfWork uw)
//        {
//            _uw = uw;
//        }

//        [HttpGet]
//        public async Task<ApiResult<List<NewsViewModel>>> Get(string search, int offset, int limit, string sort)
//        {
//            if (!search.HasValue())
//                search = "";
//            return Ok(await _uw.NewsRepository.GetPaginateNewsAsync(offset, limit,sort, search, true, null));
//        }

//        [HttpGet("{newsId}")]
//        public async Task<ApiResult<NewsViewModel>> Get(string newsId, int userId, string ipAddress)
//        {
//            if (!newsId.HasValue())
//                return NotFound();
//            else
//            {
//                var news = await _uw.NewsRepository.GetNewsByIdAsync(newsId, userId);
//                if (news == null)
//                    return NotFound();
//                else
//                {
//                    await _uw.NewsRepository.InsertVisitOfUserAsync(newsId, ipAddress);
//                    return Ok(news);
//                }
//            }
//        }
//    }
//}
