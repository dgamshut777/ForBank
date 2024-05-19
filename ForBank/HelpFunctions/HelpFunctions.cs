using ForBank.HelpClasses;

namespace ForBank.HelpFunctions
{
    public class HelpFunctions
    {
        /// <summary>
        /// Сформировать ответ на web-запрос
        /// </summary>
        /// <returns></returns>
        public static StatusForOut CreateResponseForOut(bool status, string description)
        {
            StatusForOut statusForOut = new StatusForOut
            {
                Description = description,
                Status = status
            };
            return statusForOut;
        }

        /// <summary>
        /// Сформировать ответ на web-запрос
        /// </summary>
        /// <returns></returns>
        public static StatusForOut CreateResponseForOut(bool status, string description, dynamic data)
        {
            StatusForOut statusForOut = new StatusForOut
            {
                Description = description,
                Status = status,
                Data = data
            };
            return statusForOut;
        }
    }
}
