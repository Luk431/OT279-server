﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models.DTOs.NewsDTO;
using OngProject.Core.Models.DTOs.PagedListDTO;
using OngProject.Entities;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class NewsController : ControllerBase
    {

        private readonly INewsBusiness _service;

        public NewsController(INewsBusiness service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNews([FromQuery(Name = "numberPage")] int numberPage = 1, [FromQuery(Name = "quantityPage")] int quantityPage = 10)
        {
            var host = HttpContext.Request.Host.Value;
            var path = HttpContext.Request.Path.Value;
            var newsDTO = await _service.GetAllNews();

            if (newsDTO != null)
            {
                PagedListHelper<GetNewsDto> page = PagedListHelper<GetNewsDto>.Create(newsDTO, numberPage, quantityPage);
                PagedListDTO<GetNewsDto> listNews = new(page, host, path);
                if (listNews.totalPage < numberPage)
                {
                    return Ok("Pagina Actual inexistente");
                }
                return Ok(listNews);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromForm] InserNewDto inserNewDto)
        {
            var news = await _service.CreateNews(inserNewDto);
            if (news != null)
            {
                return Ok(new {message= "News  saved successfully" });
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveNews([FromQuery(Name = "id")] int id)
        {

            bool news = await _service.RemoveNews(id);

            if (news)
            {
                return Ok("News deleted");
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNews([FromRoute] int id, [FromForm] InserNewDto newsDTO)
        {
            try
            {
                var news = await _service.UpdateNews(id, newsDTO);
                if (news != null)
                {
                    return Ok(news);
                }
                else
                {
                    return NotFound(400);
                }
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetNewById([FromQuery(Name = "id")] int id)
        {

            var news = await _service.GetNewsById(id);

            if (news != null)
            {
                return Ok(news);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetNewByIdComments( int id)
        {
            var news = await _service.GetNewsByIdComments(id);

            if (news != null)
            {  
                return Ok(news);
            }
            else
            {
                return NotFound();
            }

        }

    }
}
