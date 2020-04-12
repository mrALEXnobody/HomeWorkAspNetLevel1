namespace WebStoreGusev.Models
{
    /// <summary>
    /// Класс работника.
    /// </summary>
    public class EmployeeViewModel
    {
        /// <summary>
        /// ID работника.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя работника.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия работника.
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Отчество работника.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Возраст работника.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Должность работника.
        /// </summary>
        public string Position { get; set; }
    }
}
