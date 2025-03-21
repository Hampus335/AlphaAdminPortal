﻿using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ProjectsController : Controller
{
    [HttpPost]
    public IActionResult Add(AddProjectForm form)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
                );

            return BadRequest(new { errors });
        }

        return Ok();
    }
}
