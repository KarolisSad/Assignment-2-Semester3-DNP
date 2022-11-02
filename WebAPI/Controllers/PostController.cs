using Application.ILogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PostController : ControllerBase
{
    private IPostLogic PostLogic;

    public PostController(IPostLogic postLogic)
    {
        PostLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> createPost(PostCreationDto dto)
    {
        try
        {
            Post post = await PostLogic.createPost(dto);
            return Created($"/post/{post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet ("{id:int}"), AllowAnonymous]
    public async Task<ActionResult<Post>> getPostById([FromRoute] int id)
    {
        try
        {
            Post? post = await PostLogic.getPostById(id);
            return Ok(post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, AllowAnonymous]
    public async Task<ActionResult<IEnumerable<Post>>> getAllPosts()
    {
        try
        {
            IEnumerable<Post> post = await PostLogic.getAllPosts();
            return Ok(post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    // This method returns "GetPostsBySubPostID" it's not best approach, 
    // Way to solve it would be to add extra variable in SearchDTO,
    // Which would tell to send back "GetPostsBySubPostID" :)
}
    
    
    