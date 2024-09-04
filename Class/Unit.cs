using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Unit
    {
        private float _health;
        private float _baseDamage = 5f;
        private Weapon _weapon;
        private Helm _helm;
        private Shell _shell;
        private Boots _boots;

        public string Name { get; }

        public float Health => _health;

        public float Damage
        {
            get
            {
                if (_weapon != null)
                {
                    return _baseDamage + _weapon.GetDamageInterval(); // возвращаем сумму базового урона и урона от оружия если оно есть
                }
                else { return _baseDamage; }
            }
        }

        public float Armor
        {
            get
            {
                float value = 0;

                if (_helm != null)
                {
                    value += _helm.Armor;
                }

                if (_shell != null)
                {
                    value += _shell.Armor;
                }

                if (_boots != null)
                {
                    value += _boots.Armor;
                }


                if (value > 1f)
                {
                    return 1f;
                }
                else if (value <= 0f)
                {
                    return 0f;
                }
                else
                {
                    value = (float)Math.Round(value, 2);
                    return value;
                }

            }
        }

        public Unit(string name)
        {
            Name = name;
        }

        public Unit(float health, string name = "Unknown Unit") : this(name)
        {
            _health = health;
        }

        public Unit() : this("Unknown Unit")
        {
        }

        public float RealHealth() { return Health * (1f + Armor); }

        public bool SetDamage(float damage)
        {
            _health = Health - damage / (1f + Armor);

            if (Health <= 0f)
            {
                return true;
            }
            else { return false; }
        }

        public void EquipWeapon(Weapon weapon) // Снарядить Weapon | Замена оружия на новое
        {
            _weapon = weapon;
            Console.WriteLine($"{_weapon.Name} - экипировано!");
        }

        public void EquipHelm(Helm helm) // Снарядить Helm
        {
            _helm = helm;
            Console.WriteLine($"{_helm.Name} - экипировано!");
        }

        public void EquipShell(Shell shell) // Снарядить Shell
        {
            _shell = shell;
            Console.WriteLine($"{_shell.Name} - экипировано!");
        }

        public void EquipBoots(Boots boots) // Снарядить Boots
        {
            _boots = boots;
            Console.WriteLine($"{_boots.Name} - экипировано!");
        }

        public void DamageSkip()
        {
            var damageSkip = Damage - (Damage / (1f + Armor));
            Console.WriteLine($"Поглащенно урона - {damageSkip}.\n");
        }

        public void Info()
        {
            Console.WriteLine($"{Name}, {_health}, {Armor}, {RealHealth()}");
        }
    }
}
