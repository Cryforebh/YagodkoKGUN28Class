using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Подготовка к бою!");

            //...............................................................................

            Console.Write($"\nВведите имя Первого бойца : ");
            string nameOne = Console.ReadLine();

            Templates.LimitParametersInput("Введите начальное здоровье Первого бойца (10-100): ", 100f, 10f, out float healthOne);

            var unitOne = new Unit(healthOne, nameOne);

            //...............................................................................

            Console.Write($"\nВведите имя Второго бойца : ");
            string nameTwo = Console.ReadLine();

            Templates.LimitParametersInput("Введите начальное здоровье Второго бойца (10-100): ", 100f, 10f, out float healthTwo);

            var unitTwo = new Unit(healthTwo, nameTwo);

            //...............................................................................

            Templates.LimitParametersInput("\nВведите значение брони шлема от 0, до 1: ", 1f, 0f, out float armorHelm);

            Templates.LimitParametersInput("\nВведите значение брони кирасы от 0, до 1: ", 1f, 0f, out float armorShell);

            Templates.LimitParametersInput("\nВведите значение брони сапог от 0, до 1: ", 1f, 0f, out float armorBoots);

            var helm = new Helm(armorHelm);
            var shell = new Shell(armorShell);
            var boots = new Boots(armorBoots);

            Templates.LimitParametersInput("\nУкажите минимальный урон оружия (0-20): ", 20f, 0f, out float minDamage);

            Templates.LimitParametersInput("\nУкажите максимальный урон оружия (20-40): ", 40f, 20f, out float maxDamage);

            var weapons = new Weapon(minDamage, maxDamage);

            //...............................................................................

            Console.WriteLine("\nБойцы снаряжаются...");

            //...............................................................................

            unitOne.EquipHelm(helm);
            unitOne.EquipShell(shell);
            unitOne.EquipBoots(boots);
            unitOne.EquipWeapon(weapons);

            //Console.WriteLine($"\nОбщий показатель брони равен: {unitOne.Armor}");
            //Console.WriteLine($"Фактическое значение здоровья равно: {unitOne.RealHealth()}");
            //Console.WriteLine($"Средний урон из {weapons.Name}: {weapons.GetDamage()}");
            //Console.WriteLine($"Экипировано: {weapons.Name}, {helm.Name}, {shell.Name}, {boots.Name}.\n");

            //...............................................................................

            unitTwo.EquipHelm(helm);
            unitTwo.EquipShell(shell);
            unitTwo.EquipBoots(boots);
            unitTwo.EquipWeapon(weapons);

            //Console.WriteLine($"\nОбщий показатель брони равен: {unitTwo.Armor}");
            //Console.WriteLine($"Фактическое значение здоровья равно: {unitTwo.RealHealth()}");
            //Console.WriteLine($"Средний урон из {weapons.Name}: {weapons.GetDamage()}");
            //Console.WriteLine($"Экипировано: {weapons.Name}, {helm.Name}, {shell.Name}, {boots.Name}.");

            //...............................................................................

            var combat = new Combat();

            //...............................................................................

            Console.WriteLine("\nБой начинается!\n");

            combat.StartCombat(unitOne, unitTwo);
            combat.ShowResults();

            Console.WriteLine("\nБой завершен!");

            if (unitTwo.Health <= 0)
            {
                Console.WriteLine($"\n{unitOne.Name} становится победителем!");
            }
            else if (unitOne.Health <= 0)
            {
                Console.WriteLine($"\n{unitTwo.Name} становится победителем!");
            }

            Console.ReadLine();
        }
    }
}
