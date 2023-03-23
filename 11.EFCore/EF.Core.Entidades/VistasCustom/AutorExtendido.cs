using EF.Core.Entidades.Autores;

namespace EF.Core.Entidades.VistasCustom
{
    public class AutorExtendido : Autor
    {
        public int NumeroLibros { get; set; }
    }
}
