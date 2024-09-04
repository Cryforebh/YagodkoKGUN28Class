using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal struct Templates
    {
        /// <summary>
        /// Позволяет сократить код, от дублирования логических операций с ограниченными диапозонами параметров ввода. Возвращает result.
        /// </summary>
        /// <param name="text">Выводимый в консоль текст</param>
        /// <param name="oneValue">Максимальное значение</param>
        /// <param name="twoValue">Минимальное значение</param>
        /// <param name="result">Результат ввода ( Console.ReadLine() )</param>
        public static float LimitParametersInput(string text, float oneValue, float twoValue, out float result)
        {
            do
            {
                Console.Write($"{text}");

                if (!float.TryParse(Console.ReadLine(), out float value))
                {
                    Console.WriteLine("Укажите цифры!");
                    result = -1f;
                }
                else
                {
                    result = value;
                }

            }
            while (result > oneValue || result < twoValue);

            return result;
        }
    }
}
