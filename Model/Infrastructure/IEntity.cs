using System;
using System.Collections.Generic;
using System.Text;
using DGQ.Code;

namespace Model.Infrastructure
{
    public class IEntity<TEntity>
    {
        public void Create(string userId)
        {
            var entity = this as ICreationAudited;
            entity.F_Id = Common.GuId();
            entity.F_CreatorUserId = userId;
            entity.F_CreatorTime = DateTime.Now;
        }

        public void Modify(string userId)
        {
            var entity = this as IModificationAudited;
            entity.F_LastModifyUserId = userId;
            entity.F_LastModifyTime = DateTime.Now;
        }

        public void Remove(string userId)
        {
            var entity = this as IDeleteAudited;
            entity.F_DeleteUserId = userId;
            entity.F_DeleteTime = DateTime.Now;
            entity.F_DeleteMark = true;
        }
    }
}
