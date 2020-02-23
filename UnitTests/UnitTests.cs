using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using Transform;

namespace UnitTests
{
    [TestClass]

    public class RotateMoveScale
    {
        static Point sourcePoint1 = new Point(12.54, 11.78);
        static Point sourcePoint2 = new Point(22.70, 18.90);

        static Point targetPoint1 = new Point(2.00, 2.00); //origin
        static Point targetPoint2 = new Point(10.00, 10.00); //origin

        Point in1 = new Point(12.54, 11.78);
        Point in2 = new Point(21.18, 10.26);
        Point in3 = new Point(22.70, 18.90);
        Point in4 = new Point(14.06, 20.42);

        Point out1 = new Point(2.00, 2.00);
        Point out2 = new Point(10.00, 2.00);
        Point out3 = new Point(10.00, 10.00);
        Point out4 = new Point(2.00, 10.00);

        readonly TransformMatrix m = new TransformMatrix(sourcePoint1, sourcePoint2, targetPoint1, targetPoint2);
        [TestMethod]
        public void Transform1()
        {
            m.CalculateTransform();

            Assert.AreEqual(expected: out1,
                             actual: m.GetNewPoint(in1));
        }
        [TestMethod]
        public void Transform2()
        {
            m.CalculateTransform();

            Assert.AreEqual(out2, m.GetNewPoint(in2));
        }
        [TestMethod]
        public void Transform3()
        {
            m.CalculateTransform();

            Assert.AreEqual(out3, m.GetNewPoint(in3));
        }
        [TestMethod]
        public void Transform4()
        {
            m.CalculateTransform();

            Assert.AreEqual(out4, m.GetNewPoint(in4));
        }
    }
    [TestClass]
    public class RotateMove
    {
        public void Init()
        {
            m.InitSourcePoints(sourcePoint1, sourcePoint2);
            m.InitTargetPoints(targetPoint1, targetPoint2);
        }

        static Point sourcePoint1 = new Point(12.30, 11.62);
        static Point sourcePoint2 = new Point(21.50, 18.10);

        static Point targetPoint1 = new Point(2.00, 2.00); //origin
        static Point targetPoint2 = new Point(10.00, 10.00); //origin

        Point in1 = new Point(12.30, 11.62);
        Point in2 = new Point(20.14, 10.26);
        Point in3 = new Point(21.50, 18.10);
        Point in4 = new Point(13.66, 19.46);

        Point out1 = new Point(2.00, 2.00);
        Point out2 = new Point(10.00, 2.00);
        Point out3 = new Point(10.00, 10.00);
        Point out4 = new Point(2.00, 10.00);
      
        readonly TransformMatrix m = new TransformMatrix(sourcePoint1, sourcePoint2, targetPoint1, targetPoint2);

        [TestMethod]
        public void GetDistance1()
        {
            Init();
            double hyp = m.GetDistance(0);

            Assert.AreEqual(11.25, Math.Round(hyp, 2));
        }
        [TestMethod]
        public void GetDistance2()
        {
            Init();
            double hyp = m.GetDistance(1);

            Assert.AreEqual(11.31, Math.Round(hyp, 2));
        }
        [TestMethod]
        public void GetSin()
        {
            Init();
            double sin = m.GetSin(0);
            //double cos = m.GetCos(0);

            Assert.AreEqual(0.58, Math.Round(sin, 2));
        }

        [TestMethod]
        public void Transform1()
        {
            Init();
            m.CalculateTransform();

            Assert.AreEqual(out1, m.GetNewPoint(in1));
        }
        [TestMethod]
        public void Transform2()
        {
            Init();
            m.CalculateTransform();

            Assert.AreEqual(out2, m.GetNewPoint(in2));
        }
        [TestMethod]
        public void Transform3()
        {
            Init();
            m.CalculateTransform();

            Assert.AreEqual(out3, m.GetNewPoint(in3));
        }
        [TestMethod]
        public void Transform4()
        {
            Init();
            m.CalculateTransform();

            Assert.AreEqual(out4, m.GetNewPoint(in4));
        }
    }
}

//Translate [source] (Move to origin)

//Find angle [target]

//Find angle [source]

//RotateAt [source]

//Find point-to-point distance [target]

//Find point-to-point distance [source]

//ScaleAt [source]
