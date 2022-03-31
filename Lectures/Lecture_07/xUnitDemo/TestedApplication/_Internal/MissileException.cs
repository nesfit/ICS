using System;

namespace TestedApplication._Internal
{
    public class MissileException : Exception
    {
        public MissileException() : base("Missile launch failed!")
        {
        }
    }
}