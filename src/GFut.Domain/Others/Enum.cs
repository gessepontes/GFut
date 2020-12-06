using System.ComponentModel.DataAnnotations;

namespace GFut.Domain.Others
{
    public class Enum
    {
        public enum Position : int
        {
            [Display(Name = "Goleiro")]
            Goleiro = 1,
            [Display(Name = "Zagueiro")]
            Zagueiro = 2,
            [Display(Name = "Volante")]
            Volante = 3,
            [Display(Name = "Meio-Campo")]
            MeioCampo = 4,
            [Display(Name = "Atacante")]
            Atacante = 5,
            [Display(Name = "Lateral")]
            Lateral = 6
        }

        public enum TeamType : int
        {
            [Display(Name = "Society")]
            Society = 1,
            [Display(Name = "Campo de 11")]
            Campo = 2
        }

        public enum HoraryType : int
        {
            [Display(Name = "Padrão")]
            Default = 1,
            [Display(Name = "Extra")]
            Extra = 2
        }

        public enum SchedulingType : int
        {
            [Display(Name = "Avulso")]
            Avulso = 1,
            [Display(Name = "Mensal")]
            Mensal = 2
        }

        public enum ChampionshipType : int
        {
            [Display(Name = "Grupo")]
            Grupos = 1,
            [Display(Name = "Mata-Mata")]
            MataMata = 2,
            [Display(Name = "Pontos Corridos")]
            PontosCorridos = 3
        }


        public enum RefereeType : int
        {
            [Display(Name = "Society")]
            Society = 1,
            [Display(Name = "Campo de 11")]
            Campo = 2,
            [Display(Name = "Quadra")]
            Quadra = 3,
        }

        public enum WeekDay : int
        {
            [Display(Name = "Segunda-feira")]
            Monday = 1,
            [Display(Name = "Terça-feira")]
            Tuesday = 2,
            [Display(Name = "Quarta-feira")]
            Wednesday = 3,
            [Display(Name = "Quinta-feira")]
            Thursday = 4,
            [Display(Name = "Sexta-feira")]
            Friday = 5,
            [Display(Name = "Sabado")]
            Saturday = 6,
            [Display(Name = "Domingo")]
            Sunday = 0
        }

        public enum CardType : int
        {
            [Display(Name = "Nenhum")]
            Nothing = 1,
            [Display(Name = "Amarelo")]
            Yellow = 2,
            [Display(Name = "Vermelho")]
            Red = 3,
            [Display(Name = "Segundo amarelo seguido de vermelho")]
            YellowSecond = 4,
            [Display(Name = "Vermelho depois de um amarelo")]
            RedYellow = 5
        }

        public enum Group : int
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
            E = 5,
            F = 6,
            G = 7,
            H = 8,
            I = 9,
            J = 10,
            L = 11,
            M = 12
        }

        public enum StatusP : int
        {
            [Display(Name = "Pendente")]
            Pendente = 1,
            [Display(Name = "Aprovado")]
            Aprovado = 2,
            [Display(Name = "Cancelado")]
            Cancelado = 3,
        }

        public enum ProfileType : int
        {
            [Display(Name = "Administrador")]
            Administrador = 1,
            [Display(Name = "Usuário")]
            Usuario = 2,
            [Display(Name = "Administrador do campeonato")]
            AdministradorCampeonato = 3,
            [Display(Name = "Arbitro")]
            Arbitro = 4,
            [Display(Name = "Jogador")]
            Jogador = 5,
            [Display(Name = "Administrador do campo")]
            AdministradorCampo = 6
        }
    }
}
