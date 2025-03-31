using Data.Contexts;
using Data.DTOs;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext dataContext)
{
    private DataContext _context = dataContext;

    //create
    public async Task<bool> AddAsync(ProjectEntity entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            await _context.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return default;
        }
        return false;
    }
    //read

    //gets all projects
    public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        var entities = await _context.Projects.ToListAsync();
        return entities;
    }


    //gets a project by filter
    public async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var entity = await _context.Projects.FirstOrDefaultAsync(expression);
        return entity;
    }
    //update
    public async Task<bool> UpdateAsync(ProjectEntity entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            _context.Update(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return default;
        }
        return false;
    }
    //delete

    public async Task<bool> DeleteAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        if (expression == null)
            return false;

        try
        {
            var existingEntity = await GetAsync(expression);
            if (existingEntity == null)
            {
                return false;
            }

            _context.Projects.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting project entity, {ex.Message}");
            return false;
        }
    }

    public async Task<bool> ExistsAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        return await _context.Projects.AnyAsync(expression);
    }
}
