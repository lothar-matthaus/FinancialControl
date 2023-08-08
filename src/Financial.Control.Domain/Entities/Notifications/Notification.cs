namespace Financial.Control.Domain.Entities.Notifications
{
    public class Notification
    {
        #region Properties
        public string Context { get; }
        public string Field { get; }
        public string Message { get; }
        #endregion

        private Notification(string field, string context, string message)
        {
            Context = context;
            Message = message;
            Field = field;
        }

        #region Factory

        #endregion
        public static Notification Create(string context, string field = null, string message = null) => new Notification(field, context, message);
    }
}
