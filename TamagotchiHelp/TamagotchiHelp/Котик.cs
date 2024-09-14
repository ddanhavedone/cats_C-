using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiHelp
{
    internal class Котик
    {
        int Счастье = 300;
        int Сытость = 300;
        int Бодрость = 300;

        Random random = new Random();

        public int kormit()
        {
            return Сытость = Сытость + 20;
        }

        public int igrat()
        {
            return Счастье = Счастье + 20;
        }

        public int ulozhit()
        {
            return Бодрость = Бодрость + 20;
        }

        public void voskresit()
        {
            Счастье = 300;
            Сытость = 300;
            Бодрость = 300;
        }

        public string checkstate() //состояние котика
        {
            switch (random.Next(1, 5))
            {
                case (1):
                    Счастье = Счастье - 20;
                    break;
                case (2):
                    Сытость = Сытость - 20;
                    break;
                case (3):
                    Бодрость = Бодрость - 20;
                    break;
            }

            if (Сытость == 0 || Бодрость == 0 || Счастье == 0)
            {
                return "Не смог(";
            }
            if (Сытость < 150)
            {
                return "Голоден";
            }
            if (Счастье < 150)
            {
                return "Грустный";
            }
            if (Бодрость < 150)
            {
                return "Сонный";
            }
            return "Здоровый";
        }

        public int zСчастье() //значения:
        {
            return Счастье;
        }
        public int zСытость()
        {
            return Сытость;
        }
        public int zБодрость()
        {
            return Бодрость;
        }
    }
}

