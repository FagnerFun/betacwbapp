using ControleAcesso.Dominio.Interface;
using System;

namespace ControleAcesso.Dominio.Entidade
{
    public class Evento: IEntidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
    }
}
