using FixedAssetsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FixedAssetsWebApp.DAL
{
    public class AssetInitializer : DropCreateDatabaseAlways<FixedAssetsWebAppContext>
    {
        protected override void Seed(FixedAssetsWebAppContext context)
        {
            List<string[]> assets = new List<string[]>();
            var addAssetsList = new List<Assets>();
            Random random = new Random();

            //Add assets to the assets list
            assets.Add(new string[] { "HP 1040 G3", "Computer", "12", "05/01/2015", "05/01/2019", "1", "1,250.00",
                "Salt Lake", "L150", "53458S", "Active", "IT Helpdesk", "5415", "HSI", random.Next(0, 100).ToString() });
            assets.Add(new string[] { "Samsung Smart TV", "Furniture", "5", "02/15/2016", "1", "845.00",
                "Breakroom", "F135", "", "Active", "Facility", "", "Granite", random.Next(0, 100).ToString() });

            //Loop goes through the list that contains the array of information
            //about assets
            foreach (var a in assets)
            {

                //For each list in list, create a assets object
                Assets item = new Assets
                {
                    AssetDescription = a[0],
                    Category = a[1],
                    TaxClassification = Int32.Parse(a[2]),
                    ServiceDate = DateTime.Parse(a[3]),
                    Quantity = a[4],
                    Cost = Int32.Parse(a[5]),
                    Location = a[6],
                    TagNubmer = a[7],
                    SerialNumber = a[8],
                    Status = a[9],
                    Department = a[10],
                    Invoice = a[11],
                    Vendor = a[12]

                };

                //add each assets object to the add list
                addAssetsList.Add(item);

            }

            //For each object in the add list, add them using
            //the data context
            addAssetsList.ForEach(s => context.Assets.Add(s));
            context.SaveChanges();

        }
    }
}