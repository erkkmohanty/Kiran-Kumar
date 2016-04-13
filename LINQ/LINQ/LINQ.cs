using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ
{
    class LINQ
    {
        static string[] words = { "hello", "wonderful", "LINQ", "beautiful", "world" };
        public static void FindShortWords()
        {
            var shortWords = (from word in words
                              where word.Length <= 5
                              select word);
            foreach (var item in shortWords)
            {
                Console.WriteLine(item);
            }
            shortWords = words.Where(w => w.Length <= 5);
        }

        public static void LinqOnDataSet()
        {
            DataTable tab1 = new DataTable();
            tab1.Columns.Add(new DataColumn("Name"));
            tab1.Columns.Add(new DataColumn("Age"));
            tab1.Columns.Add(new DataColumn("Sex"));
            tab1.Columns.Add(new DataColumn("Address"));
            for (int i = 0; i < 10; i++)
            {
                DataRow row = tab1.NewRow();
                row["Name"] = "Name" + i;
                row["Age"] = "Age" + i;
                row["Sex"] = "Sex" + i;
                row["Address"] = "Address" + i;
                tab1.Rows.Add(row);
            }
            DataTable tab2 = tab1.Copy();
            var query = (from d in tab1.AsEnumerable()
                         join e in tab2.AsEnumerable() on d.Field<string>("Name") equals e.Field<string>("Name")
                         select
                         new
                         {
                             Name=e.Field<string>("Name"),
                             Age=e.Field<string>("Age"),
                             Sex=e.Field<string>("Sex"),
                             Address=e.Field<string>("Address")
                         });
            foreach (var item in query)
            {
                Console.WriteLine("Name:{0}||Age:{1}||Sex:{2}||Address:{3}", item.Name, item.Age, item.Sex, item.Address);
            }
        }

        public static void LinqOnXML()
        {
            string myXML = @"<Departments>
                       <Department>Account</Department>
                       <Department>Sales</Department>
                       <Department>Pre-Sales</Department>
                       <Department>Marketing</Department>
                       </Departments>";
            var query = XDocument.Parse(myXML).Descendants();
            foreach (var item in query)
            {
               Console.WriteLine( item.Value);
            }
            var query2 = XDocument.Parse(myXML).DescendantNodes();
            foreach (var item in query2)
            {
                Console.WriteLine(item.NextNode);
            }
        }
    }
}
