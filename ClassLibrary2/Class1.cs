using System;
namespace GeometryTasks
{
    public class Vector
    {
        public double X;
        public double Y;
        public double GetLength() => Geometry.GetLength(this);
        public bool Belongs(Segment segment) => Geometry.IsVectorInSegment(this, segment);
        public Vector Add(Vector v2) => Geometry.Add(this, v2);
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;
        public double GetLength() => Geometry.GetLength(this);
        public bool Contains(Vector vector) => Geometry.IsVectorInSegment(vector, this);
    }





    class Geometry
    {
        public static double GetLength(Vector v1) => Math.Abs(Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y));
        public static double GetLength(Segment s1)
            => Math.Sqrt(Math.Pow(s1.End.X - s1.Begin.X, 2) + Math.Pow(s1.End.Y - s1.Begin.Y, 2));
        public static Vector Add(Vector v1, Vector v2) => new Vector() { Y = v1.Y + v2.Y, X = v1.X + v2.X };
        public static bool IsVectorInSegment(Vector vec, Segment seg)
        {
            var segLen = GetLength(seg);
            var fromBeginLen = GetLength(new Segment() { Begin = seg.Begin, End = vec });
            var fromEndLen = GetLength(new Segment() { Begin = seg.End, End = vec });
            Segment a = new Segment();
            return (fromBeginLen + fromEndLen) == segLen;
        }
    }
}