using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EloadasProject.Tests
{
    [TestFixture]
    class EloadasTests
    {
        Eloadas eload;

        [TestCase]
        public void negativErtek()
        {
            Assert.Pass("jeee", eload = new Eloadas(-53, -23));
        }

        [TestCase]
        public void szabadUles()
        {
            eload = new Eloadas(323, 321);
            Assert.AreEqual(false, eload.Foglalt(43,123), "a ules szabad");
        }
        [TestCase]
        public void szabadUles2()
        {
            eload = new Eloadas(323, 321);
            Assert.AreEqual(false, eload.Foglalt(-302,-21), "Hibás paraméter!");
        }
        [TestCase]
        public void szabadUles3()
        {
            eload = new Eloadas(323, 321);
            eload.Lefoglal();
            Assert.AreEqual(true, eload.Foglalt(0, 0), "Sikeres foglalás!");
        }
        [TestCase]
        public void TelivanE()
        {
            eload = new Eloadas(323, 321);
            Assert.IsFalse(eload.Teli(), "A terem nincs tele");
        }
        [TestCase]
        public void TelevanE()
        {
            eload = new Eloadas(1, 2);
            eload.Lefoglal();
            eload.Lefoglal();

            Assert.IsFalse(eload.Teli(), "Az a terem tele van");
        }        

        [TestCase]
        public void dobjonArgumentet()
        {
            Assert.Throws<ArgumentException>(szabadUles2);
            Assert.Throws<ArgumentException>(() => {
                var eloadas2 = new Eloadas(-32, -312);
            });
        }
        [TestCase]
        public void dobjonArgumentet2()
        {
            Assert.Throws<ArgumentException>(szabadUles3);
            Assert.Throws<ArgumentException>(() => {
                eload.Foglalt(-21, 302);
            });
        }
        [TestCase]
        public void dobjonArgumentet3()
        {
            Assert.Throws<ArgumentException>(TelivanE);
            Assert.Throws<ArgumentException>(() => {
                eload.Foglalt(100, 50);
            });
        }
        [TestCase]
        public void dobjonArgumentet4()
        {
            Assert.Throws<ArgumentException>(TelevanE);
            Assert.Throws<ArgumentException>(() => {
                eload.Foglalt(-31, 20);
            });
        }
    }
}
