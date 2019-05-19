using WebApplication2.DAL;
using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;






namespace WebApplication2.ViewModels
{
    public class ProjectMemberVM
    {
        public List<PrivateProjects> projectMember = new List<Models.PrivateProjects>();//projects list
        //public List<Download> downs = new List<Models.Download>();//downloads list 
        public string keyWordforSearch { get; set; }
        public ProjectMemberVM()
        {
            // get the books list form the books DB
            foreach (PrivateProjects p in (new PrivateProjectsDal()).privateprojects.ToList<PrivateProjects>())

            {
                projectMember.Add(p);//add the books from books Db to the books list  
            }
        }

        public Project getProject(int i)
        {
            var pr = (new ProjectsDal()).GetPrijectByPrjectId(i);
            return pr;
            
        }
        
        /* public ProjectMv(string x)
         {
             keyWordforSearch = x;
             //get the user downloads list from the downloads  the Db
             foreach (Download u in (new libraryDal()).downloads.ToList<Download>())
             {

                 downs.Add(u);//add the books in the downloads list from the DB into the download list 
             }*/
    }
}


