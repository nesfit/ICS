using System;

namespace ClassVsStruct
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var coordinateClass = new MyClassCoordinate(1, 5);
            var coordinateStruct = new MyStructCoordinate(1, 5);

            MyClassCoordinate coordinateClassCopy = coordinateClass;
            MyStructCoordinate coordinateStructCopy = coordinateStruct;

            coordinateClassCopy.X = 6;
            coordinateStructCopy.X = 6;

            Console.WriteLine("{0}: class\n{1}: class copy", coordinateClass, coordinateClassCopy);
            Console.WriteLine("{0}: struct\n{1}: struct copy", coordinateStruct, coordinateStructCopy);

            int count = 100000000;

            var array = new MyClassCoordinate[count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new MyClassCoordinate(i, -i);
            }

            var array1 = new MyStructCoordinate[count];
            for (int i = 0; i < array.Length; i++)
            {
                array1[i] = new MyStructCoordinate(i, -i);
            }

        }
    }

    internal class MyClassCoordinate
    {
        public MyClassCoordinate(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public override string ToString()
        {
            return string.Format("x: {0} y:{1}", X, Y);
        }
    }
    internal struct MyStructCoordinate
    {
        public MyStructCoordinate(double x, double y)
            : this()
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public override string ToString()
        {
            return string.Format("x: {0} y:{1}", X, Y);
        }
    }
}