using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task21;

namespace Task26
{
    class Ring
    {
        Point coordinateCentr;
        double innerRadius, outerRadius;

        public Ring(Point coordinateCentr, double innerRadius, double outerRadius)
        {
            if (innerRadius > outerRadius || innerRadius <= 0 || outerRadius <= 0)
                throw new Exception("Ошибка в значении радиуса");
            this.coordinateCentr = coordinateCentr;
            this.innerRadius = innerRadius;
            this.outerRadius = outerRadius;
        }

        public double areaRing
        {
            get
            {
                Round outerRound = new Round(coordinateCentr, outerRadius);
                Round innerRound = new Round(coordinateCentr, innerRadius);
                return outerRound.AreaCircle - innerRound.AreaCircle;
            }
        }

        public double lengthRing
        {
            get
            {
                Round outerRound = new Round(coordinateCentr, outerRadius);
                Round innerRound = new Round(coordinateCentr, innerRadius);
                return outerRound.LengthRound + innerRound.LengthRound;
            }
        }

        public bool Correct
        {
            get
            {
                return (coordinateCentr != null);
            }
        }

        public override string ToString()
        {
            String res = "";
            if (this.Correct)
            {
                res = String.Format("Длина кольца = {0}{2}Площадь кольца = {1}", this.lengthRing, this.areaRing, Environment.NewLine);
            }
            return res;
        }
    }
}
