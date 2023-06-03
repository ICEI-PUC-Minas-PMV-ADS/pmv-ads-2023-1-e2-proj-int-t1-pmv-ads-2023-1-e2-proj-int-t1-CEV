using Flunt.Notifications;
using System.Diagnostics.CodeAnalysis;

namespace cev.api.Uteis.Results
{
    [ExcludeFromCodeCoverage]
    public class Result : Notifiable
    {
        public bool Success { get { return !Notifications.Any(); } }

        protected Result() { }

        protected Result(IReadOnlyCollection<Notification> notifications)
        {
            AddNotifications(notifications);
        }

        public static Result Ok()
        {
            return new Result();
        }

        public static Result Error(Notification notification)
        {
            return new Result(new List<Notification>() { notification });
        }

        public static Result Error(IReadOnlyCollection<Notification> notifications)
        {
            return new Result(notifications);
        }
    }

    [ExcludeFromCodeCoverage]
    public class Result<T> : Notifiable
    {
        public bool Sucess { get { return !Notifications.Any(); } }

        public T Object { get; }

        private Result(T obj)
        {
            Object = obj;
        }

        private Result(IReadOnlyCollection<Notification> notifications)
        {
            Object = default;
            AddNotifications(notifications);
        }

        public static Result<T> Ok(T obj)
        {
            return new Result<T>(obj);
        }

        public static Result<T> Error(Notification notification)
        {
            return Error(new List<Notification>() { notification });
        }

        public static Result<T> Error(IReadOnlyCollection<Notification> notifications)
        {
            return new Result<T>(notifications);
        }
    }
}
