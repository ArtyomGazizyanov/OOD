namespace LongMath
{
	public class Cont<T, T1>
	{
		public Cont(T down, T1 residue)
		{
			First = down;
			Second = residue;
		}

		public T1 Second { get; set; }

		public T First { get; set; }

		public override string ToString()
		{
			return "Dividend is " + First + " : Residue is " + Second;
		}
	}
}
