using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AirQualityDataAPI.Models;
using MongoDB.Driver;

namespace AirQualityDataAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AirQualityContext AirContext = new AirQualityContext();
        public ActionResult Index()
        {
            var measurements = AirContext.Measurements.Find(b => b.Stofnavn.Equals("Ozon")).ToList();
            return View(measurements);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult OzonLineChart()
        {
            var measurements = AirContext.Measurements.Find(b => b.Stofnavn.Equals("Ozon")).ToList();

            List<DateTime?> DatoListe = new List<DateTime?>();
            List<double?> ResultatListe = new List<double?>();

            foreach (var data in measurements)
            {
                if (data.Målestedsnavn == "Aarhus Botanisk")
                {
                    DatoListe.Add(Convert.ToDateTime(data.Datomærke));
                    ResultatListe.Add(Convert.ToDouble(data.RåResultat));
                }
            }

            DateTime?[] XArray = new DateTime?[DatoListe.Count];
            double?[] YArray = new double?[ResultatListe.Count];

            for (int i = 0; i < DatoListe.Count; i++)
            {
                XArray[i] = DatoListe[i];

            }
            for (int i = 0; i < ResultatListe.Count; i++)
            {
                YArray[i] = ResultatListe[i];

            }
            //Create bar chart             

            var chart = new Chart(width: 800, height: 400)
                .AddTitle("Ozon målinger over tid i Århus Botanisk")
                .AddSeries(chartType: "Line",

                    xValue: XArray,

                    yValues: YArray).GetBytes("png");

            return File(chart, "image/bytes");
        }

        
    }
}