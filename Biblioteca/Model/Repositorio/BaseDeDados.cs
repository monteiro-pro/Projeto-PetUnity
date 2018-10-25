using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model.Repositorio
{
    public static class BaseDeDados
    {
        #region Cliente
        public static string tabelaCliente = "tbl_cliente";
        public static string colunaNomeCliente = "Cliente_Nome";
        public static string colunaRGCliente = "Cliente_RG";
        public static string colunaCPFCliente = "Cliente_CPF";
        public static string colunaEnderecoCliente = "Cliente_Endereco";
        public static string colunaEmailCliente = "Cliente_Email";
        public static string colunaSenhaCliente = "Cliente_Senha";
        public static string colunaTelefoneCliente = "Cliente_Telefone";
        #endregion

        #region Animal
        public static string tabelaAninal = "tbl_Animal";
        public static string colunaNomeAnimal = "Animal_Nome";
        public static string colunaRacaAnimal = "Animal_Raca";
        public static string colunaEspecieAnimal = "Animal_Especie";
        public static string colunaIdadeAnimal = "Animal_Idade";
        public static string colunaPeso = "Animal_Peso";
        #endregion

        #region Agenda
        public static string tabelaAgendamento = "tbl_Agendamento";
        public static string colunaDataAgendamento = "Agendamento_Data";
        public static string colunaHoraAgendamento = "Agendamento_Hora";
        public static string colunaUnidadeAgendamento = "Agendamento_Unidade";
        public static string colunaClienteAgendamento = "Agendamento_Cliente";
        #endregion

        #region Transacao
        public static string tabelaTransacao = "tbl_Transacao";
        public static string colunaDataTransacao = "Transacao_Data";
        public static string colunaProcessoTransacao = "Transacao_Processo";
        public static string colunaMotivoTransacao = "Transacao_Motivo";
        public static string colunaReservaTransacao = "Transacao_Reserva";
        public static string colunaRacaReservaTransacao = "Transacao_Raca_Reserva";
        public static string colunaAnimalTransacao = "Transacao_Animal";
        #endregion

        #region Doacao
        public static string tabelaDoacao = "tbl_Doacao";
        public static string colunaDataDoacao = "Doacao_Data";
        public static string colunaValorDoacao = "Doacao_Valor";
        public static string colunaClienteDoacao = "Doacao_Cliente";
        #endregion
    }
}
