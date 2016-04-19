using ControleAcesso.Dominio.Interface;

namespace ControleAcesso.Dominio.Entidade
{
    public class Produto: IEntidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public double ValorBeta { get; set; }
        public int Quantidade { get; set; }
    }
}
