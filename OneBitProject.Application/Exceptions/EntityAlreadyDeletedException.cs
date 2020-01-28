namespace OneBitProject.Application.Exceptions
{
    public class EntityAlreadyDeletedException : BaseCustomException
    {
        public EntityAlreadyDeletedException(string name, object key, string message)
            : base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
        {
        }
    }
}