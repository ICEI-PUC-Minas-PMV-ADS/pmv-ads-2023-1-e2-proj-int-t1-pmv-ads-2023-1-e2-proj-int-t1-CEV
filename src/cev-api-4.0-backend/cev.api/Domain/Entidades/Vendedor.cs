using cev.api.Uteis;
using Flunt.Notifications;
using Flunt.Validations;

namespace cev.api.Domain.Entidades
{
    public sealed class Vendedor : Notifiable
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public Vendedor(int id, string nome)
        {
            Id = id;
            if (Id < 0)
                AddNotification(nameof(Id), Constantes.Entidades.ID_INVALIDO);
            Validador(nome);
        }

        public Vendedor(string nome)
        {
            Validador(nome);
        }

        private void Validador(string nome)
        {
            Nome = nome;

            AddNotifications(new Contract()
                .IsNotNullOrWhiteSpace(Nome, nameof(Nome), Constantes.Entidades.NOME_NULO_OU_VAZIO)
                .HasMaxLengthIfNotNullOrEmpty(Nome, 10, nameof(Nome), Constantes.Entidades.NOME_INVALIDO));
        }
    }
}
