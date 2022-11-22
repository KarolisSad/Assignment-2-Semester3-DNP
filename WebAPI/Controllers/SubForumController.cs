using Application.ILogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SubForumController : ControllerBase
{
    private ISubForumLogic subForumLogic;

    public SubForumController(ISubForumLogic subForumLogic)
    {
        this.subForumLogic = subForumLogic;
    }

    [HttpPost]
    public async Task<ActionResult<SubForum>> createSubForum(SubForumCreationDto subForumCreationDto)
    {
        try
        {
            SubForum createdForum = await subForumLogic.CreateSubForum(subForumCreationDto);
            return Created($"/subForums/{createdForum.Id}", createdForum);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubForum>>> getSubTopics([FromQuery] string? topic)
    {
        try
        {
            SearchSubForumDto subForumDto = new SearchSubForumDto(topic);
            IEnumerable<SubForum> subForums = await subForumLogic.GetSubTopics(subForumDto);
            return Ok(subForums);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SubForum>> GetSubTopicById([FromRoute] int id)
    {
        try
        {
            SubForum? subForum = await subForumLogic.GetSubForumById(id);
            return Ok(subForum);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}