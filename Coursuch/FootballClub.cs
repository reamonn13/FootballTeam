using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Coursuch
{
    interface PerformanceW
    {
        Striker TheBestStriker();
        double AveragePerform();
    }

    [Serializable]
    class FootballClub  //Основной класс
    {
        public string NameFC { get; set; }  //Название команды
        public string Country { get; set; }  //Местонахождение команды
        public string Stadion { get; set; }  //Стадион команды
        public int RatingUEFA { get; set; }  //Место команды в рейтинге УЕФА
        public int CountPlayer { get; set; }  //Количество игроков в команде
        public List<Striker> Strikers;

        public FootballClub(string NameFC, string Country, string Stadion, int RatingUEFA, int CountPlayer)
        {
            this.NameFC = NameFC;
            this.Country = Country;
            this.Stadion = Stadion;
            this.RatingUEFA = RatingUEFA;
            this.CountPlayer = CountPlayer;
            Strikers = new List<Striker>();
        }
    }
}
