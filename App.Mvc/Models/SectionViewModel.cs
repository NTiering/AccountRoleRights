using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Mvc.Models
{
    public class SectionViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ControllerName { get; set; }
        public string InitialMethodName { get; set; }
        public string Colour { get ; set; }
        public string Icon { get ; set; }
        public bool Current { get ; set; }

        private SectionViewModel()
        {

        }

        public static IEnumerable<SectionViewModel> GetAll()
        {
            var rtn = new List<SectionViewModel>();

            rtn.Add( new SectionViewModel{
                Name = "Welcome",
                Description = "Welcome to this application",
                ControllerName = "Home",
                InitialMethodName = "index",
                Colour = "white",
                Icon = "fa fa-home" 
            });

            rtn.Add( new SectionViewModel{
                Name = "Account",
                Description = "Represents a validated end user",
                ControllerName = "Account",
                InitialMethodName = "index",
                Colour = "orange",
                Icon = "fa fa-anchor" 
            });
         
            rtn.Add( new SectionViewModel{
                Name = "Role",
                Description = "Represents a collection of common rights",
                ControllerName = "Role",
                InitialMethodName = "index",
                Colour = "blue",
                Icon = "fa fa-book" 
            });
         
            rtn.Add( new SectionViewModel{
                Name = "Right",
                Description = "A single action an end user can perform",
                ControllerName = "Right",
                InitialMethodName = "index",
                Colour = "green",
                Icon = "fa fa-automobile" 
            });
         
            return rtn; 
        }
    }    
}