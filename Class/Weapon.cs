using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Weapon
    {
        private Interval _interval;
        private float _minDamage;
        private float _maxDamage;

        public string Name { get; }

        public float MinDamage
        {
            set
            {
                _minDamage = value;
            }
        }

        public float MaxDamage
        {
            set
            {
                _maxDamage = value;
            }
        }

        public Weapon(string name = "Weapon")
        {
            Name = name;
        }

        public Weapon(float minDamage, float maxDamage, string name = "Weapon") : this(name)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            SetDamageParams(minDamage, maxDamage);
        }

        public void SetDamageParams(float minDamage, float maxDamage)
        {
            if (minDamage > maxDamage)
            {
                _minDamage = maxDamage;
                _maxDamage = minDamage;

                Console.WriteLine($"У {Name} не корректно указанны показатели урона, введеные параметры поменяны местами:\nМин. урон = {_minDamage}, а Макс. урон = {_maxDamage}.");
            }
            if (minDamage < 1f)
            {
                _minDamage = 1f;

                Console.WriteLine($"\nФорсированная установка Минимального Урона: {_minDamage}");
            }
            if (maxDamage <= 1f)
            {
                _maxDamage = 10f;
                Console.WriteLine($"\nФорсированная установка Максимального Урона: {_maxDamage}");
            }
        }

        public float GetDamage()
        {
            return (_maxDamage + _minDamage) / 2;
        }

        public float GetDamageInterval()
        {
            _interval = new Interval(_minDamage, _maxDamage);
            return _interval.Get;
        }
    }
}
