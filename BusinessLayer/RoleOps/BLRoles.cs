using BusinessLayer.ViewModels;
using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.RoleOps
{
    public class BLRoles : IBLRoles
    {
        public async Task<Response<RolesVM>> Delete(int roleId)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    context.Roles.Remove(GetRole(roleId).Result);
                    await context.SaveChangesAsync();
                    return new Response<RolesVM>()
                    {
                        IsSuccess = true,
                        Message = "Role removed Successfully"
                    };
                }

            }
            catch (Exception)
            {
                return new Response<RolesVM>()
                {
                    IsSuccess = false,
                    Message = "Role can't be deleted"
                };
            }
        }

        public async Task<Response<RolesVM>> Get()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return new Response<RolesVM>()
                    {
                        IsSuccess = true,
                        Message = "Role data fetched successfully",
                        DataList = await context.Roles
                                .Select(e => new RolesVM()
                                {
                                    Name = e.Name,
                                    RoleId = e.RoleId,
                                    StatusId = e.StatusId
                                })
                                .ToListAsync()
                    };
                }
            }
            catch (Exception)
            {
                return new Response<RolesVM>()
                {
                    IsSuccess = false,
                    Message = "Unable to fetch Roles"
                };
            }
        }

        public async Task<Response<RolesVM>> Get(int roleId)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return new Response<RolesVM>()
                    {
                        IsSuccess = true,
                        Message = "Role data fetched successfully",
                        Data = await context.Roles
                                .Where(e => e.RoleId == roleId)
                                .Select(e => new RolesVM()
                                {
                                    Name = e.Name,
                                    RoleId = e.RoleId,
                                    StatusId = e.StatusId
                                })
                                .SingleOrDefaultAsync()
                    };
                }
            }
            catch (Exception)
            {
                return new Response<RolesVM>()
                {
                    IsSuccess = false,
                    Message = "Role doesn't exist"
                };
            }
        }

        public async Task<Response<RolesVM>> Post(RolesVM role)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    context.Roles.Add(new Role()
                    {
                        Name = role.Name,
                        StatusId = role.StatusId,
                    });
                    await context.SaveChangesAsync();
                    return new Response<RolesVM>()
                    {
                        IsSuccess = true,
                        Message = "Role Added Successfully",
                        Data = role
                    };
                }
            }
            catch (Exception)
            {
                return new Response<RolesVM>()
                {
                    IsSuccess = false,
                    Message = "Role Can't be added"
                };
            }
        }

        public async Task<Response<RolesVM>> Put(RolesVM role)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    Role ctxRole = GetRole(role.RoleId).Result;
                    ctxRole.StatusId = role.StatusId;
                    ctxRole.Name = role.Name;
                    await context.SaveChangesAsync();
                    return new Response<RolesVM>()
                    {
                        IsSuccess = true,
                        Message = "Role updated Successfully",
                        Data = role
                    };
                }
            }
            catch (Exception)
            {
                return new Response<RolesVM>()
                {
                    IsSuccess = false,
                    Message = "Role can't be Updated"
                };
            }
        }

        public async Task<Role> GetRole(int roleId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return await context.Roles
                        .Where(e => e.RoleId == roleId)
                        .SingleOrDefaultAsync();
            }
        }

        public bool IsAdmin(int roleId)
        {
            if (roleId == (int)Roles.Admin)
                return true;
            else
                return false;
        }

        public bool IsTeacher(int roleId)
        {
            if (roleId == (int)Roles.Teacher)
                return true;
            else
                return false;
        }

        public bool IsPrincipal(int roleId)
        {
            if (roleId == (int)Roles.Principal)
                return true;
            else
                return false;
        }

        public bool IsStudent(int roleId)
        {
            if (roleId == (int)Roles.Student)
                return true;
            else
                return false;
        }
    }
}
