using ControleAcesso.Dominio.Interface;

namespace ControleAcesso.Dominio.Entidade
{
    public class Menu: IEntidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }

    }
}
