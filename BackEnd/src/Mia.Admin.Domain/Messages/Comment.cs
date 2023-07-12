using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Mia.Admin.Messages
{
    public class Comment : AggregateRoot<Guid>
    {
        public string TxtResponse { get; set; } = string.Empty;
        public int C4LikeCount { get; set; }
        public List<C4LikeStaff> C4LikeStaff { get; set; } = new List<C4LikeStaff>();
        public void Like(string staffId, string staffName)
        {
            C4LikeStaff.Add(new C4LikeStaff()
            {
                StaffId = staffId,
                StaffName = staffName,
                ActionTime = DateTime.Now,
            });
            C4LikeCount = C4LikeStaff.Count;
        }

        public void RemoveLike(string staffId)
        {
            C4LikeStaff = C4LikeStaff.Where(x => x.StaffId == staffId).ToList();
            C4LikeCount = C4LikeStaff.Count;
        }

        public void ModifyComment(string txtResponse)
        {
            TxtResponse = txtResponse;
        }
    }

    public class C4LikeStaff
    {
        public string StaffId { get; set; } = string.Empty;
        public string StaffName { get; set; } = string.Empty;
        public DateTime ActionTime { get; set; }
    }
}
