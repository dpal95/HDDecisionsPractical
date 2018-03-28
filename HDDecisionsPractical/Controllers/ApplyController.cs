using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDDecisionsPractical.Models;
using System.Data;

namespace HDDecisionsPractical.Controllers
{
    public class ApplyController : Controller
    {
        private DataBaseContext context = new DataBaseContext();
        // GET: Apply
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult ApplyMethod(ApplicantModel applicant)
        {           
            //uses the applicants age and salary to assign a numeric value from 1-3
            int result = cardDecision(applicant.DOB, applicant.Salary);
           //switch statement loads the relevent page.
            switch(result)
            {
                //case 1 is when no cards apply
                case 1:
                    applicant.CardSuggested = "No cards suggested";
                    context.Applicants.Add(applicant);
                    context.SaveChanges();
                    return View("~/Views/Home/NoCard.cshtml");                    

                    //case 2 is when the age is above 18 and salary is above 30000
                case 2:
                    applicant.CardSuggested = "Barclaycard credit card";
                    context.Applicants.Add(applicant);
                    context.SaveChanges();
                    return View("~/Views/Home/Barclaycard.cshtml");                    

                    //case 3 is for over 18s that are not earning over 30000
                case 3:
                    applicant.CardSuggested = "Vanquis card";
                    context.Applicants.Add(applicant);
                    context.SaveChanges();
                    return View("~/Views/Home/Vanquis.cshtml");

            }

            return View("~/Views/Home/Apply.cshtml");
            
           
        }

        /// <summary>
        /// Uses the applicant age and salary to assign a value of 1-3 to be 
        /// used to display the correct page
        /// </summary>
        /// <param name="pAge">age of applicant</param>
        /// <param name="pSalary">salary of the applicant</param>
        /// <returns>an int between 1 and 3</returns>
        public int cardDecision(string pAge, string pSalary)
        {
            int decision = 0;
            float salary = float.Parse(pSalary);
            //calls the age method to calculate the age of the app in years
            int age = ageCalculation(pAge);
            //uses if statement to assign a value depending on age and earning
            if(age < 18)
            {
                decision = 1;
                return decision;
            }
            if(age >= 18 && salary > 30000)
            {
                decision = 2;
                return decision;
            }
            else
            {
                decision = 3;
                return decision;
            }
        }

        /// <summary>
        /// Calculates the age in years of the applicant
        /// from the date they provide in the application page
        /// </summary>
        /// <param name="pAge">age of the applicant</param>
        /// <returns>return an int, the age in years of the applicant</returns>
        public int ageCalculation(string pAge)
        {
            int age = 0;
            var today = DateTime.Today;
            DateTime birthDay = DateTime.ParseExact(pAge, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            var span = today.Date - birthDay.Date;
            age = span.Days / 365;

            return age;
        }
    }
}