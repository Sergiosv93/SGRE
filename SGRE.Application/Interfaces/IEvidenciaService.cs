using SGRE.Domain.Documents;

namespace SGRE.Application.Interfaces
{
    public interface IEvidenciaService
    {
        void RegistrarEvidencia(EvidenciaEntrega evidencia);
        EvidenciaEntrega ObtenerPorEnvio(int envioId);
    }
}