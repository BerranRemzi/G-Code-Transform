using System;
using System.Text.RegularExpressions;

namespace GCodeParser
{
    public class GCodeParserClass
    {

        public struct Axis
        {
            public double coordinates;
            public char letter;
        }

        Axis x, y;
        int index = -1;

        public GCodeParserClass()
        {
            x.letter = 'X';
            x.coordinates = 0;
            y.letter = 'Y';
            y.coordinates = 0;
        }
        public double GetX(ref string _input)
        {
            return ReadPosition(ref x, ref _input);
        }

        public double GetY(ref string _input)
        {
            return ReadPosition(ref y, ref _input);
        }

        public double ReadPosition(ref Axis _axis, ref string _input)
        {
            Regex rx = new Regex(_axis.letter + @"+\d*\.*\d+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            string s = "";

            foreach (Match match in rx.Matches(_input))
            {
                s = match.ToString();
                s = s.Remove(0, 1);

                _axis.coordinates = Double.Parse(s);

                index = match.Index;
                _input = _input.Remove(index, match.Length);
            }
            return _axis.coordinates;
        }
        public bool IsChangeFound()
        {
            bool returnValue = false;
            if (index >= 0)
            {
                returnValue = true;
            }
            return returnValue;
        }
        public int GetChangeIndex()
        {
            return index;
        }
        public void ResetChangeIndex()
        {
            index = -1;
        }

    }
}
