using cev.api.Uteis;
using Flunt.Notifications;
using Flunt.Validations;

namespace cev.api.Domain.Entidades
{
    public class Produto : Notifiable
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public double Valor { get; private set; }
        public int Estoque { get; private set; }

        public Produto(int id, string descricao, double valor, int estoque)
        {
            Id = id;
            if (Id < 0)
                AddNotification(nameof(Id), Constantes.Entidades.ID_INVALIDO);
            Validador(descricao, valor, estoque);
        }

        public Produto(string descricao, double valor, int estoque)
        {
            Validador(descricao, valor, estoque);
        }

        private void Validador(string descricao, double valor, int estoque)
        {
            Descricao = descricao;
            Valor = valor;
            Estoque = estoque;

            AddNotifications(new Contract()
                .IsNotNullOrWhiteSpace(Descricao, nameof(Descricao), Constantes.Entidades.DESCRICAO_NULA_OU_VAZIA)
                .HasMaxLengthIfNotNullOrEmpty(Descricao, 50, nameof(Descricao), Constantes.Entidades.DESCRICAO_INVALIDA));
            if (Valor < 0)
                AddNotification(nameof(Valor), Constantes.Entidades.VALOR_INVALIDO);
            if (Estoque < 0)
                AddNotification(nameof(Estoque), Constantes.Entidades.VALOR_INVALIDO);
        }
    }
}
