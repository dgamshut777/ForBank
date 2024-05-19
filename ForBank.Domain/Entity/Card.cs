using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForBank.Domain.Entity
{
    public class Card
    {
        public int Id { get; set; }
        public string? Number { get; set; }//номер счёт
        public string? FullName{get;set;}
        public string? ExpDate { get; set; }//срок действия карты
        public int CVC { get; set; }//CVC карты
        public int UserId { get; set; }

        
    }
}
