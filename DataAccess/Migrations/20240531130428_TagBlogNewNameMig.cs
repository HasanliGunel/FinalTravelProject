using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TagBlogNewNameMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagConfiguration_Blogs_BlogId",
                table: "TagConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_TagConfiguration_Tags_TagID",
                table: "TagConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagConfiguration",
                table: "TagConfiguration");

            migrationBuilder.RenameTable(
                name: "TagConfiguration",
                newName: "TagBlogs");

            migrationBuilder.RenameIndex(
                name: "IX_TagConfiguration_TagID",
                table: "TagBlogs",
                newName: "IX_TagBlogs_TagID");

            migrationBuilder.RenameIndex(
                name: "IX_TagConfiguration_BlogId_TagID",
                table: "TagBlogs",
                newName: "IX_TagBlogs_BlogId_TagID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagBlogs",
                table: "TagBlogs",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TagBlogs_Blogs_BlogId",
                table: "TagBlogs",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagBlogs_Tags_TagID",
                table: "TagBlogs",
                column: "TagID",
                principalTable: "Tags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagBlogs_Blogs_BlogId",
                table: "TagBlogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TagBlogs_Tags_TagID",
                table: "TagBlogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagBlogs",
                table: "TagBlogs");

            migrationBuilder.RenameTable(
                name: "TagBlogs",
                newName: "TagConfiguration");

            migrationBuilder.RenameIndex(
                name: "IX_TagBlogs_TagID",
                table: "TagConfiguration",
                newName: "IX_TagConfiguration_TagID");

            migrationBuilder.RenameIndex(
                name: "IX_TagBlogs_BlogId_TagID",
                table: "TagConfiguration",
                newName: "IX_TagConfiguration_BlogId_TagID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagConfiguration",
                table: "TagConfiguration",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TagConfiguration_Blogs_BlogId",
                table: "TagConfiguration",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagConfiguration_Tags_TagID",
                table: "TagConfiguration",
                column: "TagID",
                principalTable: "Tags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
