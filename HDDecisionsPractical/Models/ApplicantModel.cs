using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HDDecisionsPractical.Models
{
    public class ApplicantModel
    {
        DataBaseContext context = new DataBaseContext(); 

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Salary { get; set; }
        public string CardSuggested { get; set; }


        //public void addApplicant(string pFirst, string pLast, string pDOB, string pSalary, string pCard)
        //{
        //    ApplicantModel applicant = new ApplicantModel();
        //    applicant.FirstName = pFirst;
        //    applicant.LastName = pLast;
        //    applicant.DOB = pDOB;
        //    applicant.Salary = pSalary;
        //    applicant.CardSuggested = pCard;


        //    context.Applicants.Add(applicant);
        //    context.SaveChanges();
        //}

    }
}