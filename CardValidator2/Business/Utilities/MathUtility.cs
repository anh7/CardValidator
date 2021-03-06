﻿using System;

namespace CardValidator2.Business.Utilities
{
    public static class MathUtility
    {
        public static bool IsPrime(int number)
        {

            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(Convert.ToDouble(number))); ++i)
            {
                if (number % i == 0) return false;
            }

            return true;

        }
    }
}