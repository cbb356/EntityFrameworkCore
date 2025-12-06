/*
 * Використовуючи Visual Studio, створіть проєкт за шаблоном Windows Forms Application. 
 * Потрібно: Створити моделі сутностей, використовуючи техніку Database First. 
 * (Підключити існуючу базу даних з завдання 2 (цього уроку) ) 
 * Додати на форму DataGridView і Button Реалізувати можливість виведення інформації 
 * в DataGridView за натисканням на Button.
 */

namespace DatabaseFirst
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}