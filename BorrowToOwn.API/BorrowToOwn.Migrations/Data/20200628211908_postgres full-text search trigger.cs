using Microsoft.EntityFrameworkCore.Migrations;

namespace BorrowToOwn.API.BorrowToOwn.Migrations.Data
{
    public partial class postgresfulltextsearchtrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //            migrationBuilder.Sql(@"CREATE PROCEDURE SelectAllCustomers AS SELECT * FROM ""Products"" ");
            //            migrationBuilder.Sql(@"CREATE TABLE ""Testing"" (
            //    TestingID int,
            //    LastName varchar(255),
            //    FirstName varchar(255),
            //    Address varchar(255),
            //    City varchar(255)
            //);");
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                // Migrations for creation of the column and the index will appear here, all we need to do is set up the trigger to update the column:
                migrationBuilder.Sql(@"
                                        CREATE TRIGGER ""product_search_vector_update"" BEFORE INSERT OR UPDATE
                            ON ""Products"" FOR EACH ROW EXECUTE PROCEDURE
                            tsvector_update_trigger(""SearchVector"", 'pg_catalog.english', ""Name"", ""Description"", ""Model"");
                                                ");

                //// If you were adding a tsvector to an existing table, you should populate the column using an UPDATE
                //migrationBuilder.Sql("UPDATE \"Products\" SET \"Name\" = \"Name\", \"Description\" = \"Description\", \"Model\" = \"Model\";");
                migrationBuilder.Sql(@"
                                                    UPDATE ""Products"" SET ""Name"" = ""Name"", ""Description"" = ""Description"", ""Model"" = ""Model"" , ""CreatedBy"" = 'Joel';
                                                    ");

            }


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                // Migrations for dropping of the column and the index will appear here, all we need to do is drop the trigger:
                migrationBuilder.Sql("DROP TRIGGER product_search_vector_update");
            }
        }
    }
}
