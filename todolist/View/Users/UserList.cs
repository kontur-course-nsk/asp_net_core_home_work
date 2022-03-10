namespace View.Users
{
    using System.Collections.Generic;

    /// <summary>
    ///  Список c описанием задач
    /// </summary>
    public sealed class UserList
    {
        /// <summary>
        /// Краткая информация о задачах
        /// </summary>
        public IReadOnlyCollection<User> Users { get; set; }
    }
}
