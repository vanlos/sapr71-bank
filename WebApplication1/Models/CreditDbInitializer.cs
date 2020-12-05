using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.VisualBasic.FileIO;

namespace WebApplication1.Models
{
    public class CreditDbInitializer : DropCreateDatabaseAlways<CreditContext>
    {
        protected override void Seed(CreditContext db)
        {
            using (TextFieldParser parser = new TextFieldParser("C:\\Users\\Admin\\Documents\\!Курсы\\4,1\\РПС курсач\\WebApplication1 — копия\\Scraper\\credit.csv"))
            {
                parser.Delimiters = new string[] { ";" };
                parser.ReadLine();
                int i = 0;
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    db.Credits.Add(new Credit { bank = fields[0], creditId = i, title = fields[1], rate = fields[2],  sum = Convert.ToInt32(fields[3]) });
                    i++;
                }
                base.Seed(db);
            }

        }
    }
}