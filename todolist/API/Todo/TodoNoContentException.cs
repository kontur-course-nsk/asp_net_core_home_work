namespace API.Todo
{
    using System;
    
    /// <summary>
    /// Исключение, которое возникает при попытке удалить несуществующую задачу
    /// </summary>
    public class TodoNoContentException : Exception
    {
        /// <summary>
        /// Создает новый экземпляр исключения о том, что по заданному идентификатору нет содержимого
        /// </summary>
        /// <param name="id">Идентификатор запрашиваемой задачи</param>
        public TodoNoContentException(string id)
            : base($"Todo with id {id} is no content.")
        {
        }
    }
}