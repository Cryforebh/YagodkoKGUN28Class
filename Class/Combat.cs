using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public struct Interval
    {

        public Interval(int minValue, int maxValue) : this((float)minValue, (float)maxValue)
        {

        }

        public Interval(float minValue, float maxValue)
        {
            Min = (int)Math.Round(minValue, 0);
            Max = (int)Math.Round(maxValue, 0);

            if (Min > Max)
            {
                var min = Max;
                var max = Min;
                Min = min;
                Max = max;

                Console.WriteLine($"Не корректно указанны показатели урона, введеные параметры поменяны местами:\nМин. урон = {Min}, а Макс. урон = {Max}.");
            }
        }

        public Interval(float Value) : this(Value, Value)
        {

        }

        public int Min { get; } // возвращает значение, равное минимальной границе интервала;

        public int Max { get; } // возвращает значение, равное максимальной границе интервала;

        public int Get => IntervalRandom(Min, Max); // возвращает случайное число из интервала между minValue и maxValue;

        public int Average => AverageInt(Min, Max); // возвращает средне арифметическое значение интервала;

        static Random random = new Random();

        public int IntervalRandom(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public int AverageInt(int min, int max)
        {
            return (min + max) / 2;
        }
    }

    public struct Rate // хранит информацию об одном кадре поединка между персонажами
    {
        public Unit Unit; // ссылка на экземпляр класса юнита, инициирующего атаку
        public float Damage; // значение нанесенного урона
        public float Health; // значение здоровья противника

        public Rate(Unit unit, float damage, float health)
        {
            Unit = unit;
            Damage = damage;
            Health = health;
        }
    }

    internal class Combat // инкапсулирует логику работы боя
    {
        List<Rate> rates = new List<Rate>();

        public void StartCombat(Unit unit1, Unit unit2)
        {
            Random random = new Random();
            do
            {
                var randomInt = random.Next(1, 20);

                Rate rate;

                if (randomInt % 2 == 0)
                {
                    unit2.SetDamage(unit1.Damage);
                    rate = new Rate(unit1, unit1.Damage, unit2.Health);
                }
                else
                {
                    unit1.SetDamage(unit2.Damage);
                    rate = new Rate(unit2, unit2.Damage, unit1.Health);
                }
                rates.Add(rate);
            }
            while (unit2.Health > 0 && unit1.Health > 0);
        }

        public void ShowResults()
        {
            foreach (Rate rate in rates)
            {
                Console.WriteLine($"Боец {rate.Unit.Name} нанёс урон {rate.Damage} и оставил {rate.Health} здоровья.");
                //rate.Unit.DamageSkip();
            }

        }

    }
}
