using Microsoft.EntityFrameworkCore.Migrations;

namespace ULABITOHelpDesk.DataAccess.Migrations
{
    public partial class AddSPForUSerType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //CREATE SCRIPT:
            migrationBuilder.Sql(@"CREATE PROC usp_GetUserTypes 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.UserTypes 
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_GetUserType 
                                    @Id int 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.UserTypes  WHERE  (Id = @Id) 
                                    END ");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateUserType
	                                @Id int,
	                                @Name varchar(100),
                                    @PriorityLevel int,
                                    @IsActive bit,
                                    @QueryId uniqueidentifier,
                                    @CreatedBy nvarchar(50),
                                    @CreatedIp nvarchar(50),
                                    @CreatedDate datetime,
                                    @UpdatedBy nvarchar(50),
                                    @UpdatedIp nvarchar(50),
                                    @UpdatedDate datetime,
                                    @IsDeleted bit
                                    AS 
                                    BEGIN 
                                     UPDATE dbo.UserTypes
                                     SET  Name = @Name,
                                          PriorityLevel=@PriorityLevel,
                                          IsActive=@IsActive,
                                          QueryId=@QueryId,
                                          CreatedBy=@CreatedBy,
                                          CreatedIp=@CreatedIp,
                                          CreatedDate=@CreatedDate,
                                          UpdatedBy=@UpdatedBy,
                                          UpdatedIp=@UpdatedIp,
                                          UpdatedDate=@UpdatedDate,
                                          IsDeleted=@IsDeleted
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_DeleteUserType
	                                @Id int
                                    AS 
                                    BEGIN 
                                     DELETE FROM dbo.UserTypes
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateUserType
                                    @Name varchar(50),
                                    @PriorityLevel int,
                                    @IsActive bit,
                                    @QueryId uniqueidentifier,
                                    @CreatedBy nvarchar(50),
                                    @CreatedIp nvarchar(50),
                                    @CreatedDate datetime,
                                    @UpdatedBy nvarchar(50),
                                    @UpdatedIp nvarchar(50),
                                    @UpdatedDate datetime,
                                    @IsDeleted bit
                                   AS 
                                   BEGIN 
                                    INSERT INTO dbo.UserTypes(Name,PriorityLevel,IsActive,QueryId,CreatedBy,CreatedIp,CreatedDate,UpdatedBy,UpdatedIp,UpdatedDate,IsDeleted)
                                    VALUES (@Name,@PriorityLevel,@IsActive,@QueryId,@CreatedBy,@CreatedIp,@CreatedDate,@UpdatedBy,@UpdatedIp,@UpdatedDate,@IsDeleted)
                                   END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetUserTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetUserType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateUserType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteUserType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateUserType");
        }
    }
}
