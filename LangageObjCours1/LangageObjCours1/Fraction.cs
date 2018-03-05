using System;
namespace LangageObjCours1
{

    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator{ get; set; }

        public Fraction(int x, int y)
        {
            if (y == 0) {
                throw new FractionInitException("Incorrect denominator");
            }
            this.Numerator = x;
            this.Denominator = y;
        }

        public Fraction(string s)
        {
            string[] pieces = s.Split('/');
            if (pieces.Length != 2) {
                throw new FractionInitException("Incorrect String");
            }
            else if (int.Parse(pieces[1]) == 0)
            {
                throw new FractionInitException("Incorrect denominator");
            } else {
                this.Numerator = int.Parse(pieces[0]);
                this.Denominator = int.Parse(pieces[1]);
            }

        }

        // Return PGCD
        private static int PGCD(int a, int b)
        {
            int temp = a % b;
            if (temp == 0)
                return b;
            return PGCD(b, temp);
        }

        // Simplify the fraction
        public void Simplifier() {
            // Simplify the sign.
            if (this.Denominator < 0)
            {
                this.Numerator = -this.Numerator;
                this.Denominator = -this.Denominator;
            }

            // Factor out the greatest common divisor of the
            // numerator and the denominator.
            int gcd_ab = PGCD(this.Numerator, this.Denominator);
            this.Numerator = this.Numerator / gcd_ab;
            this.Denominator = this.Denominator / gcd_ab;
        }


        // Return a * b
        public static Fraction operator *(Fraction a, Fraction b)
        {
            // Swap numerators and denominators to simplify.
            Fraction result1 = new Fraction(a.Numerator, b.Denominator);
            Fraction result2 = new Fraction(b.Numerator, a.Denominator);

            return new Fraction(
                result1.Numerator * result2.Numerator,
                result1.Denominator * result2.Denominator);
        }

        // Return a + b
        public static Fraction operator +(Fraction a, Fraction b)
        {
            // Get the denominators' greatest common divisor.
            int gcd_ab = PGCD(a.Denominator, b.Denominator);

            int numer =
                a.Numerator * (b.Denominator / gcd_ab) +
                b.Numerator * (a.Denominator / gcd_ab);
            int denom =
                a.Denominator * (b.Denominator / gcd_ab);
            return new Fraction(numer, denom);
        }

        // Return -a
        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.Numerator, a.Denominator);
        }

        // Return a - b
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a + -b;
        }

        // Return a / b.
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return a * new Fraction(b.Denominator, b.Numerator);
        }
    }
}
