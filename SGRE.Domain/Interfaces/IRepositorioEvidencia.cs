using System.Collections.Generic;
using SGRE.Domain.Documents;

namespace SGRE.Domain.Interfaces
{
    public interface IRepositorioEvidencia
    {
        void Guardar(EvidenciaEntrega evidencia);
        EvidenciaEntrega ObtenerPorEnvioId(int envioId);
        IEnumerable<EvidenciaEntrega> ObtenerTodas();
    }
}