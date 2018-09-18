using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Infrastructure
{
    public interface IModificationAudited
    {
        string F_Id { get; set; }
        string F_LastModifyUserId { get; set; }
        DateTime? F_LastModifyTime { get; set; }
    }
}
