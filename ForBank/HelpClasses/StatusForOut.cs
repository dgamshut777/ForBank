namespace ForBank.HelpClasses
{
    public class StatusForOut
    {
        /// <summary>
        /// Статус выполнения запроса
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Данные для вывода
        /// </summary>
        public dynamic Data { get; set; }
    }
}
