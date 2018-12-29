using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Items
    {
        [Key]
        public string F_Id { get; set; }
        public string F_ParentId { get; set; }
        public string F_EnCode { get; set; }
        public string F_FullName { get; set; }
        public string F_IsTree { get; set; }
        public string F_Layers { get; set; }
        public string F_SortCode { get; set; }
        public string F_DeleteMark { get; set; }
        public string F_EnabledMark { get; set; }
        public string F_Description { get; set; }
        public string F_CreatorTime { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public string F_DeleteTime { get; set; }
        public string F_DeleteUserId { get; set; }
    }
}
