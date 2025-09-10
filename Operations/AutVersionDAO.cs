using AutosEJ.Context;
using AutosEJ.Models.DTO;

namespace AutosEJ.Operations
{
    public class AutVersionDAO
    {
        private readonly AutosEjContext _context;

        public AutVersionDAO (AutosEjContext context)
        {
            _context = context;
        }

        public List<AutVersionDTO> ObtenerLista()
        {
            try
            {
                List<AutVersionDTO> listaAutVersiones = _context.AutVersions.Select( )

            }
            catch (Exception ex)
            {
                return new List<AutVersionDTO> ();
            }
        }
    }
}
