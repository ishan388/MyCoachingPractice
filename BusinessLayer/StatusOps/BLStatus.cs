using BusinessLayer.ViewModels;
using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.StatusOps
{
    public class BLStatus : IBLStatus
    {
        public bool IsStatusActive(int statusId)
        {
            if (statusId == (int)Statuses.Active)
                return true;
            else
                return false;
        }

        public async Task<Response<StatusVM>> Delete(int statusId)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    context.Statuses.Remove(GetStatus(statusId).Result);
                    await context.SaveChangesAsync();
                    return new Response<StatusVM>()
                    {
                        IsSuccess = true,
                        Message = "Status removed Successfully"
                    };
                }

            }
            catch (Exception)
            {
                return new Response<StatusVM>()
                {
                    IsSuccess = false,
                    Message = "Status can't be deleted"
                };
            }
        }

        public async Task<Response<StatusVM>> Get()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return new Response<StatusVM>()
                    {
                        IsSuccess = true,
                        Message = "Status data fetched successfully",
                        DataList = await context.Statuses
                                .Select(e => new StatusVM()
                                {
                                    Name = e.Name,
                                    StatusId = e.StatusId
                                })
                                .ToListAsync()
                    };
                }
            }
            catch (Exception)
            {
                return new Response<StatusVM>()
                {
                    IsSuccess = false,
                    Message = "Unable to fetch Statuses"
                };
            }
        }

        public async Task<Response<StatusVM>> Get(int statusId)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return new Response<StatusVM>()
                    {
                        IsSuccess = true,
                        Message = "Status data fetched successfully",
                        Data = await context.Statuses
                                .Where(e => e.StatusId == statusId)
                                .Select(e => new StatusVM()
                                {
                                    Name = e.Name
                                })
                                .SingleOrDefaultAsync()
                    };
                }
            }
            catch (Exception)
            {
                return new Response<StatusVM>()
                {
                    IsSuccess = false,
                    Message = "Status doesn't exist"
                };
            }
        }

        public async Task<Response<StatusVM>> Post(StatusVM status)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    context.Statuses.Add(new Status()
                    {
                        Name = status.Name
                    });
                    await context.SaveChangesAsync();
                    return new Response<StatusVM>()
                    {
                        IsSuccess = true,
                        Message = "Status Added Successfully",
                        Data = status
                    };
                }
            }
            catch (Exception)
            {
                return new Response<StatusVM>()
                {
                    IsSuccess = false,
                    Message = "Status Can't be added"
                };
            }
        }

        public async Task<Response<StatusVM>> Put(StatusVM status)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    Status ctxStatus = GetStatus(status.StatusId).Result;
                    ctxStatus.Name = status.Name;
                    await context.SaveChangesAsync();
                    return new Response<StatusVM>()
                    {
                        IsSuccess = true,
                        Message = "Status updated Successfully",
                        Data = status
                    };
                }
            }
            catch (Exception)
            {
                return new Response<StatusVM>()
                {
                    IsSuccess = false,
                    Message = "Status can't be Updated"
                };
            }
        }

        public async Task<Status> GetStatus(int statusId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return await context.Statuses
                        .Where(e => e.StatusId == statusId)
                        .SingleOrDefaultAsync();
            }
        }

    }
    
}
