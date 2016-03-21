using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var point1 = new CalculateAverageDistanceBetweenPoints.Point(32.9697, -96.80322);
            var point2 = new CalculateAverageDistanceBetweenPoints.Point(29.46786, -98.53506);
            var point3 = new CalculateAverageDistanceBetweenPoints.Point(22.46786, -98.53506);

            Console.WriteLine(point1.DistanceTo(point2));
            Console.WriteLine(point2.DistanceTo(point3));
            Console.WriteLine(CalculateAverageDistanceBetweenPoints.Execute(point1, point2, point3));

            Console.ReadKey();
        }
        
    }

    /// <summary>
    /// Responsible for calculate average distance between points
    /// </summary>
    class CalculateAverageDistanceBetweenPoints
    {
        /// <summary>
        /// Point of reference
        /// </summary>
        public class Point
        {
            /// <summary>
            /// Latitude of point
            /// </summary>
            public double Latitude { get; private set; }

            /// <summary>
            /// Longitude of point
            /// </summary>
            public double Longitude { get; private set; }

            /// <summary>
            /// Point constructor
            /// </summary>
            /// <param name="latitude">Latitude</param>
            /// <param name="longitude">Longitude</param>
            public Point(double latitude, double longitude)
            {
                this.Latitude = latitude;
                this.Longitude = longitude;
            }

            /// <summary>
            /// Calculate distance between two points
            /// </summary>
            /// <param name="point">Point of destiny</param>
            /// <returns>Distance (Miles)</returns>
            public double DistanceTo(Point point)
            {
                double theta = Longitude - point.Longitude;
                double radian1 = DegreeToRadian(Latitude);
                double radian2 = DegreeToRadian(point.Latitude);

                double distance = Math.Sin(radian1) * Math.Sin(radian2) + Math.Cos(radian1) * Math.Cos(radian2) * Math.Cos(DegreeToRadian(theta));
                distance = Math.Acos(distance);
                distance = RadianToDegree(distance);
                distance = distance * 60 * 1.1515;

                return Math.Round(distance, 2);
            }

            /// <summary>
            /// This function converts decimal degrees to radians
            /// </summary>
            /// <param name="degree">Degree</param>
            /// <returns>Radian</returns>
            private double DegreeToRadian(double degree)
            {
                return (degree * Math.PI / 180.0);
            }

            /// <summary>
            /// This function converts radians to decimal degrees
            /// </summary>
            /// <param name="radian">Radian</param>
            /// <returns>Degree</returns>
            private double RadianToDegree(double radian)
            {
                return (radian / Math.PI * 180.0);
            }
        }

        /// <summary>
        /// Execute calculate of average of distance
        /// </summary>
        /// <param name="points">Points</param>
        /// <returns>Average distance (Miles)</returns>
        public static double Execute(params Point[] points)
        {
            var count = 0;
            var totalDistance = 0D;

            while (count < (points.Length - 1))
            {
                totalDistance += points[count].DistanceTo(points[count + 1]);
                count++;
            }

            return Math.Round(totalDistance / count, 2);
        }

    }

}
