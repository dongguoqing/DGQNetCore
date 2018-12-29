﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace Model.Migrations
{
    [DbContext(typeof(ApiDBContent))]
    partial class ApiDBContentModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Items", b =>
                {
                    b.Property<string>("F_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("F_CreatorTime");

                    b.Property<string>("F_CreatorUserId");

                    b.Property<string>("F_DeleteMark");

                    b.Property<string>("F_DeleteTime");

                    b.Property<string>("F_DeleteUserId");

                    b.Property<string>("F_Description");

                    b.Property<string>("F_EnCode");

                    b.Property<string>("F_EnabledMark");

                    b.Property<string>("F_FullName");

                    b.Property<string>("F_IsTree");

                    b.Property<DateTime?>("F_LastModifyTime");

                    b.Property<string>("F_LastModifyUserId");

                    b.Property<string>("F_Layers");

                    b.Property<string>("F_ParentId");

                    b.Property<string>("F_SortCode");

                    b.HasKey("F_Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Model.ItemsDetail", b =>
                {
                    b.Property<string>("F_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("F_CreatorTime");

                    b.Property<string>("F_CreatorUserId");

                    b.Property<string>("F_DeleteMark");

                    b.Property<string>("F_DeleteTime");

                    b.Property<string>("F_DeleteUserId");

                    b.Property<string>("F_Description");

                    b.Property<string>("F_EnabledMark");

                    b.Property<string>("F_IsDefault");

                    b.Property<string>("F_ItemCode");

                    b.Property<string>("F_ItemId");

                    b.Property<string>("F_ItemName");

                    b.Property<DateTime?>("F_LastModifyTime");

                    b.Property<string>("F_LastModifyUserId");

                    b.Property<string>("F_Layers");

                    b.Property<string>("F_ParentId");

                    b.Property<string>("F_SimpleSpelling");

                    b.Property<string>("F_SortCode");

                    b.HasKey("F_Id");

                    b.ToTable("ItemsDetail");
                });

            modelBuilder.Entity("Model.Module", b =>
                {
                    b.Property<string>("F_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("F_AllowDelete");

                    b.Property<bool?>("F_AllowEdit");

                    b.Property<DateTime?>("F_CreatorTime");

                    b.Property<string>("F_CreatorUserId");

                    b.Property<bool?>("F_DeleteMark");

                    b.Property<DateTime?>("F_DeleteTime");

                    b.Property<string>("F_DeleteUserId");

                    b.Property<string>("F_Description");

                    b.Property<string>("F_EnCode");

                    b.Property<bool?>("F_EnabledMark");

                    b.Property<string>("F_FullName");

                    b.Property<string>("F_Icon");

                    b.Property<bool?>("F_IsExpand");

                    b.Property<bool?>("F_IsMenu");

                    b.Property<bool?>("F_IsPublic");

                    b.Property<DateTime?>("F_LastModifyTime");

                    b.Property<string>("F_LastModifyUserId");

                    b.Property<int?>("F_Layers");

                    b.Property<string>("F_ParentId");

                    b.Property<int?>("F_SortCode");

                    b.Property<string>("F_Target");

                    b.Property<string>("F_UrlAddress");

                    b.HasKey("F_Id");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("Model.ModuleButton", b =>
                {
                    b.Property<string>("F_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("F_AllowDelete");

                    b.Property<bool?>("F_AllowEdit");

                    b.Property<DateTime?>("F_CreatorTime");

                    b.Property<string>("F_CreatorUserId");

                    b.Property<bool?>("F_DeleteMark");

                    b.Property<DateTime?>("F_DeleteTime");

                    b.Property<string>("F_DeleteUserId");

                    b.Property<string>("F_Description");

                    b.Property<string>("F_EnCode");

                    b.Property<bool?>("F_EnabledMark");

                    b.Property<string>("F_FullName");

                    b.Property<string>("F_Icon");

                    b.Property<bool?>("F_IsPublic");

                    b.Property<string>("F_JsEvent");

                    b.Property<DateTime?>("F_LastModifyTime");

                    b.Property<string>("F_LastModifyUserId");

                    b.Property<int?>("F_Layers");

                    b.Property<int?>("F_Location");

                    b.Property<string>("F_ModuleId");

                    b.Property<string>("F_ParentId");

                    b.Property<int?>("F_SortCode");

                    b.Property<bool?>("F_Split");

                    b.Property<string>("F_UrlAddress");

                    b.HasKey("F_Id");

                    b.ToTable("ModuleButton");
                });

            modelBuilder.Entity("Model.Organize", b =>
                {
                    b.Property<string>("F_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("F_Address");

                    b.Property<bool?>("F_AllowDelete");

                    b.Property<bool?>("F_AllowEdit");

                    b.Property<string>("F_AreaId");

                    b.Property<string>("F_CategoryId");

                    b.Property<DateTime?>("F_CreatorTime");

                    b.Property<string>("F_CreatorUserId");

                    b.Property<bool?>("F_DeleteMark");

                    b.Property<DateTime?>("F_DeleteTime");

                    b.Property<string>("F_DeleteUserId");

                    b.Property<string>("F_Description");

                    b.Property<string>("F_Email");

                    b.Property<string>("F_EnCode");

                    b.Property<bool?>("F_EnabledMark");

                    b.Property<string>("F_Fax");

                    b.Property<string>("F_FullName");

                    b.Property<DateTime?>("F_LastModifyTime");

                    b.Property<string>("F_LastModifyUserId");

                    b.Property<int?>("F_Layers");

                    b.Property<string>("F_ManagerId");

                    b.Property<string>("F_MobilePhone");

                    b.Property<string>("F_ParentId");

                    b.Property<string>("F_ShortName");

                    b.Property<int?>("F_SortCode");

                    b.Property<string>("F_TelePhone");

                    b.Property<string>("F_WeChat");

                    b.HasKey("F_Id");

                    b.ToTable("Organize");
                });

            modelBuilder.Entity("Model.RoleAuthorize", b =>
                {
                    b.Property<string>("F_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("F_CreatorTime");

                    b.Property<string>("F_CreatorUserId");

                    b.Property<string>("F_ItemId");

                    b.Property<int?>("F_ItemType");

                    b.Property<string>("F_ObjectId");

                    b.Property<int?>("F_ObjectType");

                    b.Property<int?>("F_SortCode");

                    b.HasKey("F_Id");

                    b.ToTable("RoleAuthorize");
                });

            modelBuilder.Entity("Model.UserInfo", b =>
                {
                    b.Property<string>("F_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("F_Account");

                    b.Property<DateTime?>("F_Birthday");

                    b.Property<DateTime?>("F_CreatorTime");

                    b.Property<string>("F_CreatorUserId");

                    b.Property<bool?>("F_DeleteMark");

                    b.Property<DateTime?>("F_DeleteTime");

                    b.Property<string>("F_DeleteUserId");

                    b.Property<string>("F_DepartmentId");

                    b.Property<string>("F_Description");

                    b.Property<string>("F_DutyId");

                    b.Property<string>("F_Email");

                    b.Property<bool?>("F_EnabledMark");

                    b.Property<bool?>("F_Gender");

                    b.Property<string>("F_HeadIcon");

                    b.Property<bool?>("F_IsAdministrator");

                    b.Property<DateTime?>("F_LastModifyTime");

                    b.Property<string>("F_LastModifyUserId");

                    b.Property<string>("F_ManagerId");

                    b.Property<string>("F_MobilePhone");

                    b.Property<string>("F_NickName");

                    b.Property<string>("F_OrganizeId");

                    b.Property<string>("F_RealName");

                    b.Property<string>("F_RoleId");

                    b.Property<int?>("F_SecurityLevel");

                    b.Property<string>("F_Signature");

                    b.Property<int?>("F_SortCode");

                    b.Property<string>("F_WeChat");

                    b.HasKey("F_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Model.UserLogOn", b =>
                {
                    b.Property<string>("F_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("F_AllowEndTime");

                    b.Property<DateTime?>("F_AllowStartTime");

                    b.Property<string>("F_AnswerQuestion");

                    b.Property<DateTime?>("F_ChangePasswordDate");

                    b.Property<int?>("F_CheckIPAddress");

                    b.Property<DateTime?>("F_FirstVisitTime");

                    b.Property<string>("F_Language");

                    b.Property<DateTime?>("F_LastVisitTime");

                    b.Property<DateTime?>("F_LockEndDate");

                    b.Property<DateTime?>("F_LockStartDate");

                    b.Property<int?>("F_LogOnCount");

                    b.Property<int?>("F_MultiUserLogin");

                    b.Property<DateTime?>("F_PreviousVisitTime");

                    b.Property<string>("F_Question");

                    b.Property<string>("F_Theme");

                    b.Property<string>("F_UserId");

                    b.Property<int?>("F_UserOnLine");

                    b.Property<string>("F_UserPassword");

                    b.Property<string>("F_UserSecretkey");

                    b.HasKey("F_Id");

                    b.ToTable("UserLogOn");
                });

            modelBuilder.Entity("Model.UserRole", b =>
                {
                    b.Property<string>("F_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("F_AllowDelete");

                    b.Property<bool?>("F_AllowEdit");

                    b.Property<int?>("F_Category");

                    b.Property<DateTime?>("F_CreatorTime");

                    b.Property<string>("F_CreatorUserId");

                    b.Property<bool?>("F_DeleteMark");

                    b.Property<DateTime?>("F_DeleteTime");

                    b.Property<string>("F_DeleteUserId");

                    b.Property<string>("F_Description");

                    b.Property<string>("F_EnCode");

                    b.Property<bool?>("F_EnabledMark");

                    b.Property<string>("F_FullName");

                    b.Property<DateTime?>("F_LastModifyTime");

                    b.Property<string>("F_LastModifyUserId");

                    b.Property<string>("F_OrganizeId");

                    b.Property<int?>("F_SortCode");

                    b.Property<string>("F_Type");

                    b.HasKey("F_Id");

                    b.ToTable("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
