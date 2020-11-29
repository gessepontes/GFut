using System;
using System.Collections.Generic;
using System.Text;

namespace GFut.Infra.Data.SocietyPro.Model
{
    public class PESSOA
    {

        public int ID { get; set; }

        public string NOME { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }
        public DateTime DATANASCIMENTO { get; set; }

        public string TELEFONE { get; set; }

        public string EMAIL { get; set; }

        public string FOTO { get; set; }

        public string SENHA { get; set; }

        public bool ATIVO { get; set; }

        public bool CONFIRMACAO { get; set; }

        public string SECURITYSTAMP { get; set; }

        public bool STATUS { get; set; }

        public string CODFACEBOOK { get; set; }

        public DateTime DATACADASTRO { get; set; }
    }
}
