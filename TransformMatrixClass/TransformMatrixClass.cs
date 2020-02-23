using System;
using System.Windows;
using System.Windows.Media;

namespace Transform
{
    public class TransformMatrix
    {
        public TransformMatrix(Point _source1, Point _source2, Point _target1, Point _target2)
        {
            InitSourcePoints(_source1, _source2);
            InitTargetPoints(_target1, _target2);
        }
        public TransformMatrix()
        {

        }
        public struct MatrixStruct
        {
            public Point[] points;
            public double hypotenuse, adjacent, opposite, sin, cos;
            public void Init()
            {
                hypotenuse = 0;
                adjacent = 0;
                opposite = 0;
                sin = 0;
                cos = 0;
                points = new Point[2];
            }
        }
        Matrix myMatrix = new Matrix(1, 0, 0, 1, 0, 0);

        MatrixStruct source = new MatrixStruct();
        MatrixStruct target = new MatrixStruct();
        private int precision = 3;

        public double GetCos(int _input)
        {
            double hypotenuse = GetDistance(_input);
            double adjacent = GetAdjacent(_input);

            double cos = adjacent / hypotenuse;
            return cos;
        }

        public double GetSin(int _input)
        {
            double hypotenuse = GetDistance(_input);
            double opposite = GetOpposite(_input);

            double sin = opposite / hypotenuse;
            return sin;
        }

        public void InitSourcePoints(Point _start, Point _end)
        {
            source.Init();
            source.points[0] = _start;
            source.points[1] = _end;
        }

        public void InitTargetPoints(Point _start, Point _end)
        {
            target.Init();
            target.points[0] = _start;
            target.points[1] = _end;
        }

        public Point MoveTo(Point _source, Point _target)
        {
            Point PointResult;
            Matrix temp = new Matrix(1, 0, 0, 1, 0, 0);

            temp.Translate(_target.X - _source.X, _target.Y - _source.Y);
            PointResult = temp.Transform(_source);

            return PointResult;
        }

        public Point MoveTo(Point _input)
        {
            Point PointResult;

            myMatrix.Translate(-GetAdjacent(0), -GetOpposite(0));
            PointResult = myMatrix.Transform(_input);

            return PointResult;
        }

        public double GetDistance(Point _start, Point _end)
        {
            double x = _start.X - _end.X;
            double y = _start.Y - _end.Y;

            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            return distance;
        }
        public double GetDistance(int _input)
        {
            Point[] temp = new Point[2];

            switch (_input)
            {
                case 0: temp = source.points; break;
                case 1: temp = target.points; break;
                default: break;
            }

            double x = temp[0].X - temp[1].X;
            double y = temp[0].Y - temp[1].Y;

            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            return distance;
        }

        public double GetAdjacent(int _input)
        {
            Point[] temp = new Point[2];

            switch (_input)
            {
                case 0: temp = source.points; break;
                case 1: temp = target.points; break;
                default: break;
            }

            double distance = temp[1].X - temp[0].X;

            return distance;
        }

        public double GetAdjacent(Point _start, Point _end)
        {
            double distance = _end.X - _start.X;

            return distance;
        }

        public double GetOpposite(Point _start, Point _end)
        {
            double distance = _end.Y - _start.Y;

            return distance;
        }

        public double GetOpposite(int _input)
        {
            Point[] temp = new Point[2];

            switch (_input)
            {
                case 0: temp = source.points; break;
                case 1: temp = target.points; break;
                default: break;
            }

            double distance = temp[1].Y - temp[0].Y;

            return distance;
        }
        public double GetSin(Point _start, Point _end)
        {
            double hypotenuse = GetDistance(_start, _end);
            double opposite = GetOpposite(_start, _end);

            double sin = opposite / hypotenuse;
            return sin;
        }
        public double GetCos(Point _start, Point _end)
        {
            double hypotenuse = GetDistance(_start, _end);
            double adjacent = GetAdjacent(_start, _end);

            double cos = adjacent / hypotenuse;
            return cos;
        }

        public void CalculateTransform()
        {
            myMatrix = new Matrix(1, 0, 0, 1, 0, 0);

            source.hypotenuse = GetDistance(0);
            source.adjacent = GetAdjacent(0);
            source.opposite = GetOpposite(0);
            source.sin = GetSin(0);
            source.cos = GetCos(0);

            target.hypotenuse = GetDistance(1);
            target.adjacent = GetAdjacent(1);
            target.opposite = GetOpposite(1);
            target.sin = GetSin(1);
            target.cos = GetCos(1);

            double targetSin = Math.Asin(target.sin) * 180 / Math.PI;
            double sourceSin = Math.Asin(source.sin) * 180 / Math.PI;
            double degree = targetSin - sourceSin;
            double scale = target.hypotenuse / source.hypotenuse;

            //Move
            myMatrix.Translate(
                target.points[0].X - source.points[0].X,
                target.points[0].Y - source.points[0].Y);
            //Rotate
            myMatrix.RotateAt(degree, target.points[0].X, target.points[0].Y);
            //Scale
            myMatrix.ScaleAt(scale, scale, target.points[0].X, target.points[0].Y);
        }

        public Point GetNewPoint(Point _input)
        {
            Point result = myMatrix.Transform(_input);
            result.X = Math.Round(result.X, precision);
            result.Y = Math.Round(result.Y, precision);
            return result;
        }
        public void Precision(int _precision)
        {
            precision = _precision;
        }
    }

}
