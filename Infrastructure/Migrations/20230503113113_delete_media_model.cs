using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace instagram_story.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class delete_media_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_Story_Storyid",
                table: "Reaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Story_Media_MediaId",
                table: "Story");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Story_MediaId",
                table: "Story");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Story");

            migrationBuilder.RenameColumn(
                name: "Storyid",
                table: "Reaction",
                newName: "StoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Reaction_Storyid",
                table: "Reaction",
                newName: "IX_Reaction_StoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "Story",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaUrl",
                table: "Story",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comment",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450);

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_Story_StoryId",
                table: "Reaction",
                column: "StoryId",
                principalTable: "Story",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_Story_StoryId",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "Story");

            migrationBuilder.RenameColumn(
                name: "StoryId",
                table: "Reaction",
                newName: "Storyid");

            migrationBuilder.RenameIndex(
                name: "IX_Reaction_StoryId",
                table: "Reaction",
                newName: "IX_Reaction_Storyid");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "Story",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaId",
                table: "Story",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comment",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Story_MediaId",
                table: "Story",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_Story_Storyid",
                table: "Reaction",
                column: "Storyid",
                principalTable: "Story",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Story_Media_MediaId",
                table: "Story",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
