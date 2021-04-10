namespace MosquitoLab.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTablesNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Roles", newName: "Roles");
            RenameTable(name: "dbo.UserRoles", newName: "UserRoles");
            RenameTable(name: "dbo.Users", newName: "Users");
            RenameTable(name: "dbo.UserClaims", newName: "UserClaims");
            RenameTable(name: "dbo.UserLogins", newName: "UserLogins");
            RenameColumn(table: "dbo.Roles", name: "Id", newName: "Id");
            RenameColumn(table: "dbo.Users", name: "Id", newName: "Id");
            RenameColumn(table: "dbo.UserClaims", name: "Id", newName: "Id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.UserClaims", name: "UserClaimId", newName: "Id");
            RenameColumn(table: "dbo.Users", name: "UserId", newName: "Id");
            RenameColumn(table: "dbo.Roles", name: "RoleId", newName: "Id");
            RenameTable(name: "dbo.UserLogins", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.UserClaims", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
            RenameTable(name: "dbo.UserRoles", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.Roles", newName: "AspNetRoles");
        }
    }
}
