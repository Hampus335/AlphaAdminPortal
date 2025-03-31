using Business.Factories;
using Business.Models;
using Data.DTOs;
using Data.Repositories;

namespace Business.Services;

public class ProjectService(ProjectRepository projectRepository)
{
    private readonly ProjectRepository _projectRepository = projectRepository;

    public async Task<bool> AddProject(AddProjectForm project)
    {
        if (project == null)
            return false;

        var projectEntity = ProjectFactory.Create(project);

        return await _projectRepository.AddAsync(projectEntity);
    }


    public async Task<IEnumerable<ProjectDTO>> GetAllProjects()
    {
        var projects = await _projectRepository.GetAllAsync();
        var projectList = new List<ProjectDTO>();
        foreach (var project in projects)
        {
            projectList.Add(ProjectFactory.Create(project));
        }

        return projectList;
    }

    public async Task<ProjectDTO?> GetProject(int id)
    {
        var project = await _projectRepository.GetAsync(x => x.Id == id);
        if (project == null)
            return null;
        return ProjectFactory.Create(project);
    }

    public async Task<bool> UpdateProject(int id, ProjectDTO updatedProject)
    {
        if (updatedProject == null)
            return false;

        var project = await _projectRepository.GetAsync(x => x.Id == id);
        if (project == null)
            return false;

        project.ProjectName = updatedProject.Name;
        project.Description = updatedProject.Description;

        project.StartDate = updatedProject.StartDate ?? project.StartDate;
        project.EndDate = updatedProject.EndDate ?? project.EndDate;
        project.ClientName = updatedProject.ClientName ?? project.ClientName;

        return await _projectRepository.UpdateAsync(project);
    }
}
