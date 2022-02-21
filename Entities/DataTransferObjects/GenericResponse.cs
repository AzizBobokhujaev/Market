namespace Entities.DataTransferObjects
{
    public class GenericResponse<T> : Response
    {
        public T Payload { get; set; }
    }
}