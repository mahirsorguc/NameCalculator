using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NameCalculator.Migrations
{
    public partial class create_SP_MakeDecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        var query = @"SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PRC_MakeDecision] 
						@firstText nvarchar(100), @secondText nvarchar(100), @operationFlag nvarchar(36)
						AS

						declare @counter int=1;
						declare @total int = 101;

						CREATE TABLE #tmpTbl
						(
						   Id uniqueidentifier,
						   [Counter] int,
						   Result nvarchar(250),
						   ExtraProperties nvarchar(max),
						   ConcurrencyStamp nvarchar(40),
						   OperationFlag uniqueidentifier
						)

						while @counter < @total
						begin 
						
						insert into Results
						values
						(	NEWID(),
							@counter,
						    CASE  
								when @counter % 15 = 0 then @firstText + ' ' + @secondText
								when @counter % 5 = 0 then @secondText
								when @counter %3 = 0 then @firstText
								else CAST(@counter AS varchar)
							END,
							CAST(@operationFlag as uniqueidentifier),
							null,
							null							
						)
							SET @counter = @counter + 1;
						end
GO";

	        migrationBuilder.Sql(query);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        var query = @"DROP PROCEDURE [dbo].[PRC_MakeDecision];  
													GO  ";

	        migrationBuilder.Sql(query);
        }
    }
}
