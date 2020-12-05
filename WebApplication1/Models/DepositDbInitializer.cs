using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.VisualBasic.FileIO;

namespace WebApplication1.Models
{
    public class DepositDbInitializer : DropCreateDatabaseAlways<DepositContext>
    {
        protected override void Seed(DepositContext db)
        {
            using (TextFieldParser parser = new TextFieldParser("C:\\Users\\Admin\\Documents\\!Курсы\\4,1\\РПС курсач\\WebApplication1 — копия\\Scraper\\deposit.csv"))
            {
                parser.Delimiters = new string[] { ";" };
                parser.ReadLine();
                int i = 0;
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    db.Deposits.Add(new Deposit { bank = fields[0], depositId = i,title = fields[1], rate = fields[2], limit = fields[3], sum = Convert.ToInt32(fields[4]), sum2 = Convert.ToInt32(fields[5]) });
                    i++;
                }
                base.Seed(db);
            }
        }
    }
}