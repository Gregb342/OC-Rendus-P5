using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class YearOfProductionSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YearOfProduction>().HasData(
                new YearOfProduction { Id = 1, Year = 2020 },
                new YearOfProduction { Id = 2, Year = 2019 },
                new YearOfProduction { Id = 3, Year = 2018 },
                new YearOfProduction { Id = 4, Year = 2017 },
                new YearOfProduction { Id = 5, Year = 2016 },
                new YearOfProduction { Id = 6, Year = 2015 },
                new YearOfProduction { Id = 7, Year = 2014 },
                new YearOfProduction { Id = 8, Year = 2013 },
                new YearOfProduction { Id = 9, Year = 2012 },
                new YearOfProduction { Id = 10, Year = 2011 },
                new YearOfProduction { Id = 11, Year = 2010 },
                new YearOfProduction { Id = 12, Year = 2009 },
                new YearOfProduction { Id = 13, Year = 2008 },
                new YearOfProduction { Id = 14, Year = 2007 },
                new YearOfProduction { Id = 15, Year = 2006 },
                new YearOfProduction { Id = 16, Year = 2005 },
                new YearOfProduction { Id = 17, Year = 2004 },
                new YearOfProduction { Id = 18, Year = 2003 },
                new YearOfProduction { Id = 19, Year = 2002 },
                new YearOfProduction { Id = 20, Year = 2001 },
                new YearOfProduction { Id = 21, Year = 2000 },
                new YearOfProduction { Id = 22, Year = 1999 },
                new YearOfProduction { Id = 23, Year = 1998 },
                new YearOfProduction { Id = 24, Year = 1997 },
                new YearOfProduction { Id = 25, Year = 1996 },
                new YearOfProduction { Id = 26, Year = 1995 },
                new YearOfProduction { Id = 27, Year = 1994 },
                new YearOfProduction { Id = 28, Year = 1993 },
                new YearOfProduction { Id = 29, Year = 1992 },
                new YearOfProduction { Id = 30, Year = 1991 },
                new YearOfProduction { Id = 31, Year = 1990 }
            );
        }
    }
}
