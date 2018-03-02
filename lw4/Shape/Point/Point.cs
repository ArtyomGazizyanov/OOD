using LongMath;

namespace Shape
{
    class Point
    {
	    public BigNumber X { get; set; }
	    public BigNumber Y { get; set; }

		public Point(int x, int y)
	    {
		    X = new BigNumber(x.ToString());
		    Y = new BigNumber(y.ToString());
	    }

	    public Point(string x, string y)
	    {
		    X = new BigNumber(x.ToString());
		    Y = new BigNumber(y.ToString());
	    }

		public Point()
	    {
		    X = new BigNumber("0");
		    Y = new BigNumber("0");
		}
    }
}
