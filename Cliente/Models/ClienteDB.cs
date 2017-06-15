using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cliente.Models
{
    [Table("Cliente")]
    public class ClienteDB
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DataNasc { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }
        public int Cpf { get; set; }


    }
}