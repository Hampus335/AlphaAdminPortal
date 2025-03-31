using Business.Models;
using Business.Services;
using Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ProjectsController(ProjectService projectService) : Controller
{
    private ProjectService _projectService = projectService;

    [HttpPost]
    public async Task<IActionResult> Add(AddProjectForm form)
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
        var result = await _projectService.AddProject(form);
        return RedirectToAction("Admin", "Projects");
    }

    [HttpGet]
    [Route("admin/projects")]
    public async Task<IActionResult> Admin()
    {
        var projects = await _projectService.GetAllProjects();
        return View("/Views/Admin/Projects.cshtml", projects);
    }

    [HttpGet]
    [Route("admin/projects/edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var project = await _projectService.GetProject(id);
        if (project == null)
            return NotFound();

        return View("/Views/Admin/EditProject.cshtml", project);
    }

    [HttpPost]
    [Route("admin/projects/edit/{id}")]
    public async Task<IActionResult> Edit(int id, ProjectDTO project)
    {
        if (project == null)
            return BadRequest();

        var updatedProject = await _projectService.UpdateProject(id, project);
        if (updatedProject == null)
            return NotFound();

        return RedirectToAction("Admin", "Projects");
    }

}
