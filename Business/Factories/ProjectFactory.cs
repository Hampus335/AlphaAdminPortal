using Business.Models;
using Data.DTOs;
using Data.Entities;

namespace Business.Factories
{
    public static class ProjectFactory
    {
        public static ProjectEntity Create(AddProjectForm form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            return new ProjectEntity
            {
                ProjectName = form.ProjectName,
                ClientName = form.ClientName,
                Description = form.Description,
                StartDate = form.StartDate,
                EndDate = form.EndDate,
                Budget = form.Budget,
                Status = form.Status
            };
        }

        public static ProjectDTO Create(ProjectEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return new ProjectDTO
            {
                Id = entity.Id,
                Name = entity.ProjectName,
                ClientName = entity.ClientName,
                Description = entity.Description,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Budget = entity.Budget
            };
        }
    }
}
