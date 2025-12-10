/*
 * Відкрити рішення завдання 2 (1 урок)
 * Потрібно:
 * Обмежити всі строкові властивості (обмеження підбирати, виходячи з призначення поля) через DataAnnotations.
 * Змінити назву Id на – (НазваКласу)Id.
 * Для полів з типом DateTime вказати тип Date через DataAnnotations Внести всі зміни у базу.
 */

using DataAnnotations.Entities;

namespace DataAnnotations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDatabaseContext())
            {
                Console.WriteLine("Database created successfully");
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
