namespace Financial.Control.Domain.Entities.NotificationEntity
{
    public class Notification
    {
        #region Properties
        public string Context { get; }
        public string Field { get; }
        public ICollection<string> Errors { get; }
        #endregion

        private Notification(string field, string context, ICollection<string> errors)
        {
            Context = context;
            Errors = errors;
            Field = field;
        }

        public static Notification Create(string context, string field, ICollection<string> errors) => new Notification(field, context, errors);
    }
}
