using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASI.Basecode.Data.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Jane", "Austen" },
                    { 2, "George", "Orwell" },
                    { 3, "Haruki", "Murakami" },
                    { 4, "Toni", "Morrison" },
                    { 5, "Leo", "Tolstoy" },
                    { 6, "Gabriel García", "Márquez" },
                    { 7, "J.K.", "Rowling" },
                    { 8, "Charles", "Dickens" },
                    { 9, "Chimamanda Ngozi", "Adichie" },
                    { 10, "Ernest", "Hemingway" },
                    { 11, "Fyodor", "Dostoevsky" },
                    { 12, "Isabel", "Allende" },
                    { 13, "Mark", "Twain" },
                    { 14, "Virginia", "Woolf" },
                    { 15, "James", "Baldwin" },
                    { 16, "Agatha", "Christie" },
                    { 17, "J.R.R.", "Tolkien" },
                    { 18, "Margaret", "Atwood" },
                    { 19, "Kazuo", "Ishiguro" },
                    { 20, "Paulo", "Coelho" },
                    { 21, "Mary", "Shelley" },
                    { 22, "Salman", "Rushdie" },
                    { 23, "H.P.", "Lovecraft" },
                    { 24, "Emily", "Brontë" },
                    { 25, "Edgar Allan", "Poe" },
                    { 26, "Langston", "Hughes" },
                    { 27, "Khaled", "Hosseini" },
                    { 28, "Oscar", "Wilde" },
                    { 29, "Stephen", "King" },
                    { 30, "Maya", "Angelou" },
                    { 31, "Roald", "Dahl" },
                    { 32, "Dan", "Brown" },
                    { 33, "Neil", "Gaiman" },
                    { 34, "Sylvia", "Plath" },
                    { 35, "Ian", "McEwan" },
                    { 36, "Orhan", "Pamuk" },
                    { 37, "Zadie", "Smith" },
                    { 38, "Alice", "Walker" },
                    { 39, "Kurt", "Vonnegut" },
                    { 40, "Louise", "Erdrich" },
                    { 41, "Cormac", "McCarthy" },
                    { 42, "Philip K.", "Dick" },
                    { 43, "John", "Steinbeck" },
                    { 44, "Herman", "Melville" },
                    { 45, "Charles", "Bukowski" },
                    { 46, "William", "Faulkner" },
                    { 47, "Ayn", "Rand" },
                    { 48, "Gustave", "Flaubert" },
                    { 49, "Ken", "Follett" },
                    { 50, "Arthur Conan", "Doyle" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Created", "Description", "ISBN", "Image", "Language", "Name", "PageCount", "PublishedOn", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(7972), "An engaging and compelling story about...", "ISBN-4649-9344", null, "English", "The Meridian of Fate", 211, new DateTime(2021, 7, 17, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(7961), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(7972) },
                    { 2, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8135), "An engaging and compelling story about...", "ISBN-7697-4323", null, "English", "The Last Symphony of Autumn", 427, new DateTime(2015, 4, 2, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8134), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8135) },
                    { 3, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8181), "An engaging and compelling story about...", "ISBN-8305-1746", null, "English", "Eclipses of the Past", 171, new DateTime(2021, 9, 16, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8180), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8181) },
                    { 4, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8229), "An engaging and compelling story about...", "ISBN-2240-8957", null, "English", "The Labyrinth of Lost Souls", 125, new DateTime(2015, 11, 5, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8228), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8229) },
                    { 5, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8310), "An engaging and compelling story about...", "ISBN-7031-4467", null, "English", "Lost in the Whispering Forest", 270, new DateTime(2019, 6, 28, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8309), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8310) },
                    { 6, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8352), "An engaging and compelling story about...", "ISBN-7986-3560", null, "English", "The Midnight Carousel", 302, new DateTime(2015, 9, 1, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8351), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8353) },
                    { 7, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8393), "An engaging and compelling story about...", "ISBN-3134-8034", null, "English", "Sorrows of the Last Warlock", 241, new DateTime(2014, 12, 6, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8393), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8393) },
                    { 8, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8459), "An engaging and compelling story about...", "ISBN-7334-4291", null, "English", "The Labyrinth of Lost Souls", 446, new DateTime(2017, 10, 24, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8458), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8459) },
                    { 9, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8500), "An engaging and compelling story about...", "ISBN-2221-7704", null, "English", "The Scribe's Enigma", 344, new DateTime(2017, 10, 2, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8500), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8501) },
                    { 10, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8537), "An engaging and compelling story about...", "ISBN-3582-2998", null, "English", "Tales from the Sapphire Sea", 401, new DateTime(2014, 5, 30, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8536), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8537) },
                    { 11, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8600), "An engaging and compelling story about...", "ISBN-1112-9897", null, "English", "Veil of the Northern Lights", 418, new DateTime(2014, 12, 17, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8599), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8600) },
                    { 12, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8625), "An engaging and compelling story about...", "ISBN-2919-5221", null, "English", "Beyond the Shadow Realm", 368, new DateTime(2017, 11, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8624), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8625) },
                    { 13, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8658), "An engaging and compelling story about...", "ISBN-8910-3160", null, "English", "Chronicle of the Shattered Lands", 207, new DateTime(2017, 3, 23, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8657), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8658) },
                    { 14, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8719), "An engaging and compelling story about...", "ISBN-9345-7132", null, "English", "The Enigma of the Crystal Towers", 267, new DateTime(2015, 1, 2, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8718), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8719) },
                    { 15, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8744), "An engaging and compelling story about...", "ISBN-5065-6146", null, "English", "In the Heart of the Storm", 222, new DateTime(2015, 12, 9, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8743), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8744) },
                    { 16, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8768), "An engaging and compelling story about...", "ISBN-6200-9718", null, "English", "The Sorceress's Labyrinth", 383, new DateTime(2021, 2, 20, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8767), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8768) },
                    { 17, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8838), "An engaging and compelling story about...", "ISBN-2207-3653", null, "English", "Tales from the Sapphire Sea", 391, new DateTime(2019, 1, 6, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8837), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8838) },
                    { 18, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8877), "An engaging and compelling story about...", "ISBN-1875-4686", null, "English", "Chronicles of the Silver Mist", 127, new DateTime(2015, 3, 26, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8876), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8877) },
                    { 19, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8901), "An engaging and compelling story about...", "ISBN-1026-9438", null, "English", "The Midnight Carousel", 410, new DateTime(2022, 10, 25, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8900), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8901) },
                    { 20, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8967), "An engaging and compelling story about...", "ISBN-6447-7019", null, "English", "The Last Voyage of the Star Sailor", 255, new DateTime(2020, 6, 15, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8967), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8968) },
                    { 21, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8991), "An engaging and compelling story about...", "ISBN-5009-8801", null, "English", "The Heirloom of Forgotten Times", 459, new DateTime(2017, 8, 1, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8990), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(8991) },
                    { 22, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9019), "An engaging and compelling story about...", "ISBN-5781-6793", null, "English", "The Last Voyage of the Star Sailor", 284, new DateTime(2022, 3, 23, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9018), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9019) },
                    { 23, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9088), "An engaging and compelling story about...", "ISBN-7206-5947", null, "English", "Twilight of the Celestial Court", 196, new DateTime(2022, 7, 6, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9088), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9089) },
                    { 24, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9112), "An engaging and compelling story about...", "ISBN-9230-2181", null, "English", "The Clockmaker's Illusion", 155, new DateTime(2018, 9, 15, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9111), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9112) },
                    { 25, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9148), "An engaging and compelling story about...", "ISBN-1000-7262", null, "English", "Mysteries at the Edge of the Universe", 458, new DateTime(2014, 5, 24, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9147), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9148) },
                    { 26, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9211), "An engaging and compelling story about...", "ISBN-1617-3668", null, "English", "The Last Symphony of Autumn", 271, new DateTime(2017, 12, 30, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9210), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9211) },
                    { 27, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9242), "An engaging and compelling story about...", "ISBN-6894-4884", null, "English", "Lost in the Whispering Forest", 157, new DateTime(2021, 9, 4, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9242), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9243) },
                    { 28, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9280), "An engaging and compelling story about...", "ISBN-6062-8487", null, "English", "Abyss of the Starry Depths", 313, new DateTime(2020, 5, 29, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9280), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9281) },
                    { 29, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9360), "An engaging and compelling story about...", "ISBN-1737-6759", null, "English", "The Dragon's Heir", 101, new DateTime(2016, 7, 6, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9360), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9361) },
                    { 30, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9397), "An engaging and compelling story about...", "ISBN-1771-4936", null, "English", "Shadows over Valoria", 329, new DateTime(2019, 5, 29, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9396), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9397) },
                    { 31, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9430), "An engaging and compelling story about...", "ISBN-1465-6500", null, "English", "The Hidden Kingdom Beyond the Mountains", 470, new DateTime(2021, 11, 15, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9429), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9430) },
                    { 32, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9486), "An engaging and compelling story about...", "ISBN-7326-9395", null, "English", "The Alchemist's Shadow", 128, new DateTime(2019, 6, 30, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9486), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9487) },
                    { 33, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9514), "An engaging and compelling story about...", "ISBN-2912-2275", null, "English", "The Painter's Paradox", 476, new DateTime(2017, 8, 11, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9513), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9514) },
                    { 34, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9550), "An engaging and compelling story about...", "ISBN-2597-9818", null, "English", "The Heirloom of Forgotten Times", 294, new DateTime(2021, 3, 12, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9550), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9551) },
                    { 35, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9617), "An engaging and compelling story about...", "ISBN-8668-9271", null, "English", "The Painter's Paradox", 378, new DateTime(2016, 2, 23, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9616), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9617) },
                    { 36, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9653), "An engaging and compelling story about...", "ISBN-1571-7795", null, "English", "Mysteries at the Edge of the Universe", 358, new DateTime(2022, 3, 21, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9653), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9654) },
                    { 37, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9707), "An engaging and compelling story about...", "ISBN-7211-7106", null, "English", "The Hidden Kingdom Beyond the Mountains", 120, new DateTime(2017, 1, 28, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9706), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9707) },
                    { 38, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9740), "An engaging and compelling story about...", "ISBN-9693-4162", null, "English", "Mysteries at the Edge of the Universe", 351, new DateTime(2020, 11, 16, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9739), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9741) },
                    { 39, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9764), "An engaging and compelling story about...", "ISBN-3308-8242", null, "English", "Twilight of the Celestial Court", 159, new DateTime(2017, 5, 13, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9763), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9764) },
                    { 40, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9806), "An engaging and compelling story about...", "ISBN-8021-5544", null, "English", "Twilight of the Celestial Court", 316, new DateTime(2019, 1, 9, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9806), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9807) },
                    { 41, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9862), "An engaging and compelling story about...", "ISBN-9701-5884", null, "English", "Mysteries of the Ancient Library", 299, new DateTime(2018, 7, 19, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9861), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9862) },
                    { 42, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9901), "An engaging and compelling story about...", "ISBN-2912-2770", null, "English", "Voices from the Hollow Mountains", 476, new DateTime(2022, 8, 28, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9900), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9901) },
                    { 43, new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9929), "An engaging and compelling story about...", "ISBN-1526-3261", null, "English", "The Magician's Reflection", 441, new DateTime(2021, 9, 20, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9929), new DateTime(2023, 12, 3, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9930) },
                    { 44, new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local), "An engaging and compelling story about...", "ISBN-2907-4196", null, "English", "The Enigma of the Crystal Towers", 253, new DateTime(2020, 6, 9, 22, 23, 48, 947, DateTimeKind.Local).AddTicks(9999), new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local) },
                    { 45, new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(49), "An engaging and compelling story about...", "ISBN-6897-3493", null, "English", "The Oracle's Last Prophecy", 404, new DateTime(2014, 12, 14, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(48), new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(49) },
                    { 46, new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(96), "An engaging and compelling story about...", "ISBN-7287-3626", null, "English", "Secrets of the Jade Labyrinth", 106, new DateTime(2016, 8, 9, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(95), new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(97) },
                    { 47, new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(152), "An engaging and compelling story about...", "ISBN-9123-1688", null, "English", "Mysteries at the Edge of the Universe", 221, new DateTime(2014, 2, 26, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(151), new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(152) },
                    { 48, new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(182), "An engaging and compelling story about...", "ISBN-2552-7236", null, "English", "Twilight of the Celestial Court", 336, new DateTime(2014, 2, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(181), new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(182) },
                    { 49, new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(243), "An engaging and compelling story about...", "ISBN-2412-6771", null, "English", "Secrets of the Jade Labyrinth", 339, new DateTime(2016, 5, 7, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(242), new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(244) },
                    { 50, new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(291), "An engaging and compelling story about...", "ISBN-7041-1487", null, "English", "The Meridian of Fate", 299, new DateTime(2022, 3, 20, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(290), new DateTime(2023, 12, 3, 22, 23, 48, 948, DateTimeKind.Local).AddTicks(291) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Science Fiction" },
                    { 3, "Mystery" },
                    { 4, "Thriller" },
                    { 5, "Romance" },
                    { 6, "Historical Fiction" },
                    { 7, "Horror" },
                    { 8, "Young Adult" },
                    { 9, "Children’s Literature" },
                    { 10, "Literary Fiction" },
                    { 11, "Dystopian" },
                    { 12, "Adventure" },
                    { 13, "Crime" },
                    { 14, "Suspense" },
                    { 15, "Cyberpunk" },
                    { 16, "Magical Realism" },
                    { 17, "Gothic" },
                    { 18, "War" },
                    { 19, "Post-Apocalyptic" },
                    { 20, "Western" },
                    { 21, "Satire" },
                    { 22, "Biography" },
                    { 23, "Autobiography" },
                    { 24, "Self-Help" },
                    { 25, "Travel" },
                    { 26, "Cooking" },
                    { 27, "Health & Fitness" },
                    { 28, "Graphic Novel" },
                    { 29, "Poetry" },
                    { 30, "Play" },
                    { 31, "Essays" },
                    { 32, "Journalism" },
                    { 33, "Steampunk" },
                    { 34, "Paranormal" },
                    { 35, "Urban Fantasy" },
                    { 36, "Epic" },
                    { 37, "Non-Fiction" },
                    { 38, "Contemporary" },
                    { 39, "Classic" },
                    { 40, "Humor" },
                    { 41, "Memoir" },
                    { 42, "Philosophy" },
                    { 43, "Religion" },
                    { 44, "True Crime" },
                    { 45, "Academic" },
                    { 46, "Self-Improvement" },
                    { 47, "Chick Lit" },
                    { 48, "LGBT Literature" },
                    { 49, "Fairy Tales" },
                    { 50, "Bildungsroman" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 13 },
                    { 1, 20 },
                    { 2, 19 },
                    { 2, 31 },
                    { 2, 32 },
                    { 2, 33 },
                    { 2, 37 },
                    { 3, 26 },
                    { 4, 24 },
                    { 4, 48 },
                    { 5, 30 },
                    { 5, 47 },
                    { 6, 29 },
                    { 7, 9 },
                    { 8, 13 },
                    { 8, 18 },
                    { 8, 25 },
                    { 9, 3 },
                    { 9, 36 },
                    { 10, 8 },
                    { 10, 26 },
                    { 10, 46 },
                    { 12, 3 },
                    { 12, 6 },
                    { 12, 29 },
                    { 15, 6 },
                    { 15, 44 },
                    { 16, 3 },
                    { 16, 17 },
                    { 16, 50 },
                    { 18, 22 },
                    { 18, 41 },
                    { 19, 8 },
                    { 19, 27 },
                    { 20, 4 },
                    { 20, 45 },
                    { 21, 5 },
                    { 21, 30 },
                    { 21, 49 },
                    { 22, 10 },
                    { 22, 34 },
                    { 22, 42 },
                    { 23, 5 },
                    { 24, 12 },
                    { 24, 29 },
                    { 24, 42 },
                    { 24, 43 },
                    { 24, 44 },
                    { 26, 6 },
                    { 26, 16 },
                    { 26, 25 },
                    { 27, 24 },
                    { 27, 41 },
                    { 28, 21 },
                    { 28, 22 },
                    { 28, 30 },
                    { 29, 7 },
                    { 29, 12 },
                    { 29, 37 },
                    { 29, 49 },
                    { 30, 2 },
                    { 30, 7 },
                    { 31, 1 },
                    { 31, 17 },
                    { 31, 39 },
                    { 32, 9 },
                    { 32, 14 },
                    { 32, 16 },
                    { 32, 19 },
                    { 33, 28 },
                    { 34, 33 },
                    { 35, 41 },
                    { 36, 15 },
                    { 36, 17 },
                    { 37, 35 },
                    { 38, 11 },
                    { 38, 35 },
                    { 38, 50 },
                    { 39, 2 },
                    { 40, 39 },
                    { 41, 34 },
                    { 43, 8 },
                    { 44, 23 },
                    { 44, 38 },
                    { 45, 10 },
                    { 45, 45 },
                    { 46, 7 },
                    { 46, 40 },
                    { 47, 26 },
                    { 47, 42 },
                    { 48, 2 },
                    { 48, 49 },
                    { 49, 43 },
                    { 50, 27 }
                });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 1, 22 },
                    { 1, 40 },
                    { 2, 9 },
                    { 2, 19 },
                    { 3, 5 },
                    { 3, 41 },
                    { 4, 40 },
                    { 4, 45 },
                    { 5, 36 },
                    { 5, 47 },
                    { 6, 7 },
                    { 7, 9 },
                    { 8, 9 },
                    { 8, 21 },
                    { 9, 33 },
                    { 9, 36 },
                    { 10, 40 },
                    { 11, 44 },
                    { 12, 2 },
                    { 13, 24 },
                    { 14, 15 },
                    { 15, 22 },
                    { 16, 14 },
                    { 16, 34 },
                    { 17, 44 },
                    { 18, 40 },
                    { 19, 25 },
                    { 20, 38 },
                    { 21, 22 },
                    { 21, 30 },
                    { 22, 36 },
                    { 23, 33 },
                    { 24, 23 },
                    { 25, 48 },
                    { 26, 45 },
                    { 27, 43 },
                    { 28, 5 },
                    { 28, 7 },
                    { 29, 7 },
                    { 29, 12 },
                    { 30, 10 },
                    { 31, 6 },
                    { 31, 47 },
                    { 32, 27 },
                    { 32, 30 },
                    { 33, 30 },
                    { 34, 7 },
                    { 35, 15 },
                    { 35, 34 },
                    { 36, 49 },
                    { 37, 10 },
                    { 38, 22 },
                    { 39, 4 },
                    { 39, 9 },
                    { 40, 28 },
                    { 41, 29 },
                    { 41, 30 },
                    { 42, 3 },
                    { 43, 15 },
                    { 43, 28 },
                    { 44, 33 },
                    { 44, 47 },
                    { 45, 8 },
                    { 45, 22 },
                    { 46, 50 },
                    { 47, 8 },
                    { 47, 22 },
                    { 48, 23 },
                    { 48, 35 },
                    { 49, 16 },
                    { 49, 45 },
                    { 50, 24 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 19 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 31 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 32 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 33 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 37 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 26 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 24 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 48 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 30 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 47 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 29 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 8, 13 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 8, 18 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 8, 25 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 9, 36 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 10, 8 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 10, 26 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 10, 46 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 29 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 15, 6 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 15, 44 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 16, 17 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 16, 50 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 18, 22 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 18, 41 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 19, 8 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 19, 27 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 20, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 20, 45 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 21, 5 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 21, 30 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 21, 49 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 10 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 34 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 42 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 23, 5 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 24, 12 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 24, 29 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 24, 42 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 24, 43 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 24, 44 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 26, 6 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 26, 16 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 26, 25 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 27, 24 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 27, 41 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 21 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 22 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 30 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 29, 7 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 29, 12 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 29, 37 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 29, 49 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 30, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 30, 7 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 31, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 31, 17 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 31, 39 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 32, 9 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 32, 14 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 32, 16 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 32, 19 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 33, 28 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 33 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 35, 41 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 36, 15 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 36, 17 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 37, 35 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 38, 11 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 38, 35 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 38, 50 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 39, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 40, 39 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 41, 34 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 43, 8 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 44, 23 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 44, 38 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 45, 10 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 45, 45 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 46, 7 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 46, 40 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 47, 26 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 47, 42 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 48, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 48, 49 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 49, 43 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 50, 27 });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 1, 22 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 1, 40 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 2, 19 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 3, 41 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 4, 40 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 4, 45 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 5, 36 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 5, 47 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 8, 21 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 9, 33 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 9, 36 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 10, 40 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 11, 44 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 13, 24 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 14, 15 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 15, 22 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 16, 14 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 16, 34 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 17, 44 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 18, 40 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 19, 25 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 20, 38 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 21, 22 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 21, 30 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 22, 36 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 23, 33 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 24, 23 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 25, 48 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 26, 45 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 27, 43 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 28, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 28, 7 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 29, 7 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 29, 12 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 30, 10 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 31, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 31, 47 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 32, 27 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 32, 30 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 33, 30 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 34, 7 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 35, 15 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 35, 34 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 36, 49 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 37, 10 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 38, 22 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 39, 4 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 39, 9 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 40, 28 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 41, 29 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 41, 30 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 42, 3 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 43, 15 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 43, 28 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 44, 33 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 44, 47 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 45, 8 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 45, 22 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 46, 50 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 47, 8 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 47, 22 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 48, 23 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 48, 35 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 49, 16 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 49, 45 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 50, 24 });

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Users__1788CC4D5F4A160F",
                table: "Users",
                column: "UserId",
                unique: true);
        }
    }
}
