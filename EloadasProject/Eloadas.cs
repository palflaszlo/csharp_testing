using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloadasProject
{
    public class Eloadas
    {
        public bool[,] foglalasok;
        public int sorokSzama;
        public int helyekSzama;
        public Eloadas(int sorokSzama, int helyekSzama)
        {
            if(sorokSzama < 0 || helyekSzama < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                foglalasok = new bool[sorokSzama, helyekSzama];
            }
        }

        public bool[,] Foglalasok { get => foglalasok; set => foglalasok = value; }

        public bool Lefoglal()
        {
            for (int i = 0; i < sorokSzama; i++)
            {
                for (int j = 0; j < helyekSzama; j++)
                {
                    if (!foglalasok[i, j])
                    {
                        foglalasok[i, j] = true;
                        return true;
                    }
                }
            }
            return false;
        }

        public int szabadHelyek()
        {
            int count = 0;
            for (int i = 0; i < Foglalasok.GetLength(0); i++)
            {
                for (int j = 0; j < Foglalasok.GetLength(1); j++)
                {
                    if (!foglalasok[i, j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public bool Teli()
        {
            int count = szabadHelyek();
            
            if(count == 0)
            {
                Console.WriteLine("Az előadás tele van.");
                return true;
            }
            else
            {
                Console.WriteLine("Még van szabad hely.");
                return false;
            }
        }

        public bool Foglalt(int sorSzam, int helySzam)
        {
            if (sorokSzama < 0 || helyekSzama < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                for (int i = 0; i < sorokSzama; i++)
                {
                    for (int j = 0; j < helyekSzama; j++)
                    {
                        if (i == sorSzam && j == helySzam)
                        {
                            if (!foglalasok[i, j])
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
