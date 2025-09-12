using AutosEJ.Context;
using AutosEJ.Models.Interfaces;
using System.Collections;

namespace AutosEJ.Models.Repository
{
    public abstract class RepositorioBase
    {
        protected readonly AutosEjContext _context;

        protected RepositorioBase(AutosEjContext context) 
        { 
           _context = context;
        }

        public abstract IEnumerable ObtenerLista();
        public abstract IDataTransferObject BuscarPorId(int id);
        
    }
}
