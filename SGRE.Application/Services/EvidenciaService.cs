using SGRE.Application.Interfaces;
using SGRE.Domain.Documents;
using SGRE.Domain.Interfaces;

namespace SGRE.Application.Services
{
    public class EvidenciaService : IEvidenciaService
    {
        private readonly IRepositorioEvidencia _repositorio;

        public EvidenciaService(IRepositorioEvidencia repositorio)
        {
            _repositorio = repositorio;
        }

        public void RegistrarEvidencia(EvidenciaEntrega evidencia)
        {
            _repositorio.Guardar(evidencia);
        }

        public EvidenciaEntrega ObtenerPorEnvio(int envioId)
        {
            return _repositorio.ObtenerPorEnvioId(envioId);
        }
    }
}