using System.Collections.Generic;

namespace MosquitoLab.Domain.PakcageGenarator
{
    public  interface IWingbankPackageProcess
    {
        string GerarPacote(IList<int> listaIdWingImage);
        string GerarPacote(int idWingImage);
    }
}
