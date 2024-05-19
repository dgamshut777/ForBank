using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForBank.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        /// <summary>
        /// имя
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// фамилия
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// отчёство
        /// </summary>
        public string? Patronymic { get; set; }
        /// <summary>
        /// дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// место работы
        /// </summary>
        public string? Job { get; set; }
        /// <summary>
        /// привязанная карта
        /// </summary>
        public List<Card> Cards { get; set; }
    }
}
