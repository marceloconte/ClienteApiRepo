using Clientes.Framework;
using MongoDB.Bson;
using System;

namespace Clientes.Domain.Data.Entities
{
    public class Cliente
    {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public int Idade => DataNascimento.ToAge();

    }
}
