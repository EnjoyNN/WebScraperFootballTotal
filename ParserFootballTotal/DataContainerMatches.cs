using System.Collections.Generic;
using System.ComponentModel;

namespace ParserFootballTotal
{ 
    //этот класс служит для получения дата контейнеров сайта для дальнейшего парсинга этого в формдату
class DataContainerMatches
    {

        //конструтор для создания дата контейнера с раздела не забивает/не пропускает
        public DataContainerMatches(string nameSerie, string url, int countSerie, int divAllMatchOrHalf, int divAllHomeAway)
        {
            this.nameSerie = nameSerie;
            this.url = url;
            this.countSerie = countSerie;
            this.divAllMatchOrHalf = divAllMatchOrHalf;
            this.divAllHomeAway = divAllHomeAway;
        }


        //конструктор для создания дата контейнера с раздела тоталов
        public DataContainerMatches(string nameSerie, string url, int countSerie, int divAllMatchOrHalf, int divAllHomeAway, int divTotals)
        {
            this.nameSerie = nameSerie;
            this.url = url;
            this.countSerie = countSerie;
            this.divAllMatchOrHalf = divAllMatchOrHalf;
            this.divAllHomeAway = divAllHomeAway;
            this.divTotals = divTotals;
        }

        public string url { get; }
        public int countSerie { get; }
        public int divAllMatchOrHalf { get; }
        public int divTotals { get; }
        public int divAllHomeAway { get; }
        public string nameSerie { get;  }
    }
}
