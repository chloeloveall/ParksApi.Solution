using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksApi.Migrations
{
    public partial class seeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "ParkCategory", "ParkDescription", "ParkName", "ParkState" },
                values: new object[,]
                {
                    { 1, "National", "Yellowstone National Park is a nearly 3,500-sq.-mile wilderness recreation area atop a volcanic hot spot. Mostly in Wyoming, the park spreads into parts of Montana and Idaho too. Yellowstone features dramatic canyons, alpine rivers, lush forests, hot springs and gushing geysers, including its most famous, Old Faithful. It's also home to hundreds of animal species, including bears, wolves, bison, elk and antelope.", "Yellowstone National Park", "Wyoming" },
                    { 2, "National", "Yosemite National Park is in California’s Sierra Nevada mountains. It’s famed for its giant, ancient sequoia trees, and for Tunnel View, the iconic vista of towering Bridalveil Fall and the granite cliffs of El Capitan and Half Dome. In Yosemite Village are shops, restaurants, lodging, the Yosemite Museum and the Ansel Adams Gallery, with prints of the photographer’s renowned black-and-white landscapes of the area.", "Yosemite National Park", "California" },
                    { 3, "State", "Lake Sammamish State Park is a park at the south end of Lake Sammamish, in King County, Washington, United States. The park, which is administered by the Washington State Park System, covers an area of 512 acres and has 6,858 feet of waterfront; Issaquah Creek meets with Lake Sammamish within the park.", "Lake Sammamish State Park", "Washington" },
                    { 4, "National", "Zion National Park is a southwest Utah nature preserve distinguished by Zion Canyon’s steep red cliffs. Zion Canyon Scenic Drive cuts through its main section, leading to forest trails along the Virgin River. The river flows to the Emerald Pools, which have waterfalls and a hanging garden. Also along the river, partly through deep chasms, is Zion Narrows wading hike.", "Zion National Park", "Utah" },
                    { 5, "State", "Cape Lookout State Park is a state park on Cape Lookout in the U.S. state of Oregon. It is located in Tillamook County, south of the city of Tillamook, on a sand spit between Netarts Bay and the Pacific Ocean.", "Cape Lookout State Park", "Oregon" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "ParkId", "Rating", "ReviewBody", "ReviewTitle" },
                values: new object[,]
                {
                    { 1, 1, 5, "Yellowstone is cool. I'd like to visit again soon!", "I <3 Yellowstone" },
                    { 2, 1, 1, "Yellowstone is not cool. I would NOT like to visit again!", "Yellowstone :(" },
                    { 3, 3, 3, "Lake Sammamish is nice, but not too exciting", "Pleasant Lake Experience" },
                    { 4, 4, 5, "I absolutely loved Zion and can;t wait to go back! Summers are a bit hot, but the scenery is worth it.", "Splendid Zion!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);
        }
    }
}
