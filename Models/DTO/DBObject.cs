using AutosEJ.Context;
using System.Collections;

namespace AutosEJ.Models.DTO
{
    public abstract class DBObject
    {
        protected AutosEjContext context { get; set; }

        protected DBObject(AutosEjContext context) 
        { 
           this.context = context;
        }

        public abstract List<Type> GetList();
        
    }
}
