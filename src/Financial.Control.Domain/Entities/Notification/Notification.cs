namespace Financial.Control.Domain.Entities.NotificationEntity
{
    public class Notification
    {
        #region Properties
        public string Context { get; }
        public string Message { get; }
        #endregion

        private Notification(string context, string message)
        {
            Context = context;
            Message = message;
        }

        public static Notification Create(string context, string message) => new Notification(context, message);
    }
}
