using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Bibliotek.Migrations
{
    /// <inheritdoc />
    public partial class firsttry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Year = table.Column<int>(type: "int", maxLength: 75, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "IsAvailable", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Tony Hawk", "Wanna kick it, but cant kick IT, learn to pop shove, kick flip and more rad stuff!", "Lifestyle", true, "Skate", 1995 },
                    { 2, "Danny McBride", "What really happaend durring the filming?? I'll tell you, fuck all", "Facts", false, "Thunders Tropic", 2009 },
                    { 3, "Dennis Raynolds", "How did he go from Nightman to The Golden God? Read and find out!!", "biography", true, "The Golden God", 2016 },
                    { 4, "MacGuffin", "DO NOT READ", "Religon", true, "The Elder Scrolls", 1123 },
                    { 5, "Roboute Guilliman", "They shall be pure of heart and strong of body, untainted by doubt and unsullied by self-aggrandisement.", "Religon", true, "Codex Astartes", 40403 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
