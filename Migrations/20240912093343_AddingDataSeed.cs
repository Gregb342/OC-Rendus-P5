using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OC_P5.Migrations
{
    public partial class AddingDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarBrands",
                columns: new[] { "Id", "Brand" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "BMW" },
                    { 3, "Citroën" },
                    { 4, "Fiat" },
                    { 5, "Ford" },
                    { 6, "Mercedes" },
                    { 7, "Peugeot" },
                    { 8, "Renault" },
                    { 9, "Toyota" },
                    { 10, "Volkswagen" }
                });

            migrationBuilder.InsertData(
                table: "CarTrims",
                columns: new[] { "Id", "TrimLabel" },
                values: new object[,]
                {
                    { 1, "Base" },
                    { 2, "Sport" },
                    { 3, "Luxury" },
                    { 4, "Premium" },
                    { 5, "Exclusive" },
                    { 6, "GT" },
                    { 7, "SE" },
                    { 8, "SEL" },
                    { 9, "X-Line" },
                    { 10, "R-Line" },
                    { 11, "Z-Edition" },
                    { 12, "Black Edition" },
                    { 13, "White Edition" },
                    { 14, "S-Line" },
                    { 15, "Avant" },
                    { 16, "Highline" },
                    { 17, "Limited" },
                    { 18, "Ultimate" },
                    { 19, "Sportback" },
                    { 20, "Touring" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfMedias",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Image" },
                    { 2, "PDF" },
                    { 3, "Doc" }
                });

            migrationBuilder.InsertData(
                table: "YearOfProductions",
                columns: new[] { "Id", "Year" },
                values: new object[,]
                {
                    { 1, 2020 },
                    { 2, 2019 },
                    { 3, 2018 },
                    { 4, 2017 },
                    { 5, 2016 },
                    { 6, 2015 },
                    { 7, 2014 },
                    { 8, 2013 },
                    { 9, 2012 }
                });

            migrationBuilder.InsertData(
                table: "YearOfProductions",
                columns: new[] { "Id", "Year" },
                values: new object[,]
                {
                    { 10, 2011 },
                    { 11, 2010 },
                    { 12, 2009 },
                    { 13, 2008 },
                    { 14, 2007 },
                    { 15, 2006 },
                    { 16, 2005 },
                    { 17, 2004 },
                    { 18, 2003 },
                    { 19, 2002 },
                    { 20, 2001 },
                    { 21, 2000 },
                    { 22, 1999 },
                    { 23, 1998 },
                    { 24, 1997 },
                    { 25, 1996 },
                    { 26, 1995 },
                    { 27, 1994 },
                    { 28, 1993 },
                    { 29, 1992 },
                    { 30, 1991 },
                    { 31, 1990 }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "CarBrandId", "Model" },
                values: new object[,]
                {
                    { 1, 7, "107" },
                    { 2, 7, "208" },
                    { 3, 7, "3008" },
                    { 4, 1, "A3" },
                    { 5, 1, "A4" },
                    { 6, 1, "Q5" },
                    { 7, 2, "X1" },
                    { 8, 2, "X3" },
                    { 9, 2, "M3" },
                    { 10, 4, "500" },
                    { 11, 4, "Panda" },
                    { 12, 4, "Tipo" },
                    { 13, 5, "Fiesta" },
                    { 14, 5, "Focus" },
                    { 15, 5, "Mustang" },
                    { 16, 6, "A-Class" },
                    { 17, 6, "C-Class" },
                    { 18, 6, "E-Class" },
                    { 19, 8, "Clio" },
                    { 20, 8, "Captur" },
                    { 21, 8, "Twingo" },
                    { 22, 9, "Corolla" },
                    { 23, 9, "Camry" },
                    { 24, 9, "RAV4" },
                    { 25, 10, "Golf" },
                    { 26, 10, "Passat" },
                    { 27, 10, "Tiguan" }
                });

            migrationBuilder.InsertData(
                table: "CarModelCarTrims",
                columns: new[] { "CarModelId", "CarTrimId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 2 },
                    { 3, 4 },
                    { 4, 3 },
                    { 4, 5 },
                    { 5, 1 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarBrandId", "CarModelId", "CarTrimId", "Description", "Label", "Status", "VIN", "YearOfProductionId" },
                values: new object[,]
                {
                    { 1, 1, 1, null, "Car description 1", "Car 1", 2, "1HGCM82633A123456", 1 },
                    { 2, 2, 2, 1, "Car description 2", "Car 2", 0, "1HGCM82633A654321", 2 },
                    { 3, 3, 3, 2, "Car description 3", "Car 3", 1, "1HGCM82633A789456", 3 },
                    { 4, 4, 4, 3, "Car description 4", "Car 4", 2, "1HGCM82633A987654", 4 },
                    { 5, 5, 5, 4, "Car description 5", "Car 5", 3, "1HGCM82633A456789", 5 },
                    { 6, 6, 6, 5, "Car description 6", "Car 6", 1, "1HGCM82633A321654", 6 },
                    { 7, 7, 7, 6, "Car description 7", "Car 7", 2, "1HGCM82633A159753", 7 },
                    { 8, 8, 8, 7, "Car description 8", "Car 8", 3, "1HGCM82633A357951", 8 },
                    { 9, 9, 9, 8, "Car description 9", "Car 9", 0, "1HGCM82633A753159", 9 },
                    { 10, 10, 10, 9, "Car description 10", "Car 10", 1, "1HGCM82633A852963", 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarModelCarTrims",
                keyColumns: new[] { "CarModelId", "CarTrimId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CarModelCarTrims",
                keyColumns: new[] { "CarModelId", "CarTrimId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CarModelCarTrims",
                keyColumns: new[] { "CarModelId", "CarTrimId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CarModelCarTrims",
                keyColumns: new[] { "CarModelId", "CarTrimId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CarModelCarTrims",
                keyColumns: new[] { "CarModelId", "CarTrimId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CarModelCarTrims",
                keyColumns: new[] { "CarModelId", "CarTrimId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CarModelCarTrims",
                keyColumns: new[] { "CarModelId", "CarTrimId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CarModelCarTrims",
                keyColumns: new[] { "CarModelId", "CarTrimId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "CarModelCarTrims",
                keyColumns: new[] { "CarModelId", "CarTrimId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "CarModelCarTrims",
                keyColumns: new[] { "CarModelId", "CarTrimId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TypeOfMedias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeOfMedias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypeOfMedias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarTrims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "YearOfProductions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
