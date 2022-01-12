using BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.StatusOps
{
    public interface IBLStatus
    {
        public bool IsStatusActive(int statusId);
        public Task<Response<StatusVM>> Post(StatusVM status);
        public Task<Response<StatusVM>> Put(StatusVM status);
        public Task<Response<StatusVM>> Delete(int statusId);
        public Task<Response<StatusVM>> Get();
        public Task<Response<StatusVM>> Get(int statusId);
    }
}
