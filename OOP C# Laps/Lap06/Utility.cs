using System;

namespace Lap06;

public class Utility
{
        //Fail in Open for Extend / Close for Modification Principle
        public static double SumOfAreasV1(Rectangle[] rArr, Square[] sArr, Triangle[] tArr)
        {
            double sum = 0;
            for (int i = 0; i < rArr.Length; i++)
            {
                sum += rArr[i].GetArea();
            }
            for (int i = 0; i < sArr.Length; i++)
            {
                sum += sArr[i].GetArea();
            }
            for (int i = 0; i < tArr.Length; i++)
            {
                sum += tArr[i].GetArea();
            }
            return sum;
        }

        //Fail in Open for Extend / Close for Modification Principle
        public static double SumOfAreasV2(GeoShape[] gArr)
        {
            double sum = 0;
            for(int i = 0; i < gArr.Length; i++) 
            {
                sum += gArr[i].GetArea();
            }
            return sum;
        }
}
