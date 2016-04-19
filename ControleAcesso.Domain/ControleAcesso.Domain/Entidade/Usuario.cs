using ControleAcesso.Dominio.Interface;
using System;

namespace ControleAcesso.Dominio.Entidade
{
    public class Usuario : IEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public long CPF { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }

    }
}
