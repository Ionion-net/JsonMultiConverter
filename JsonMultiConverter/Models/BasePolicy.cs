using JsonMultiConverter.Interfaces;
using System;


namespace JsonMultiConverter.Models
{
    public class BasePolicy : IJsonType
    {
        public DateTime DocumentDate { get; set; }      // Дата создания документа
        public DateTime EffectiveDate { get; set; }       // Начало действия ДС
        public DateTime ExpirationDate { get; set; }    // Окончание действия ДС
        public DateTime AcceptationDate { get; set; }   // Дата акцептации ДС
        public Person Insurer { get; set; }             // Страхователь
        public Vehicle Vehicle { get; set; }            // Данные Автомобиля
    }

}
