using PublicTransport.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Contracts
{
    public interface IAdminService
    {
        public int PendingPhotosCount();

        public IEnumerable<AdminAllPendingPhotosModel> AllPendingPhotos();

        public AdminApproveDisapprovePhotoModel ApproveDisapproveViewData(Guid id);

        public bool Approve(Guid id, string? adminMessage);

        public bool DisApprove(Guid id, string? adminMessage);

    }
}
