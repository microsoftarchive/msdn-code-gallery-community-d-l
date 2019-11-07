using System;

namespace Mandelbrot
{
    class Complex
    {
        private double real, imag;

        public Complex()
        {
            real = imag = 0.0;
        }

        public Complex(double real, double imag)
        {
            this.real = real;
            this.imag = imag;
        }

        public double Real
        {
            set
            {
                real = value;
            }
            get
            {
                return real;
            }
        }

        public double Imag
        {
            set
            {
                imag = value;
            }
            get
            {
                return imag;
            }
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.real + c2.real, c1.imag + c2.imag);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.real - c2.real, c1.imag - c2.imag);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            double r = c1.real * c2.real - c1.imag * c2.imag;
            double i = c1.real * c2.imag + c1.imag * c2.real;

            return new Complex(r, i);
        }

        public static Complex operator /(Complex c1, Complex c2)
        {
            double d = (c2.real * c2.real + c2.imag * c2.imag);
            double r = (c1.real * c2.real + c1.imag * c2.imag) / d;
            double i = (c1.imag * c2.real - c1.real * c2.imag) / d;

            return new Complex(r, i);
        }

        public static double abs(Complex z)
        {
            return Math.Sqrt(z.real * z.real + z.imag * z.imag);
        }

        public static Complex exp(Complex z)
        {
            double e = Math.Exp(z.real);
            double r = Math.Cos(z.imag);
            double i = Math.Sin(z.imag);

            return new Complex(e * r, e * i);
        }
    }
}
