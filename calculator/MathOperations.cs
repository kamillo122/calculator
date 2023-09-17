using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    internal class MathOperations
    {
        private double _first_number;
        public double first_number
        {
            get => _first_number;
            set => _first_number = value;
        }
        private double _second_number;
        public double second_number
        {
            get => _second_number;
            set => _second_number = value;
        }
        private double result;
        private char _sign;
        public char sign
        {
            get => _sign;
            set => _sign = value;
        }
        private bool _state = false;
        public bool state
        {
            get => _state;
            set => _state = value;
        }
        private void Add()
        {
            result = _first_number + _second_number;
        }
        private void Substraction()
        {
            result = _first_number - _second_number;
        }
        private void Multiply()
        {
            if (_first_number == 0 || _second_number == 0)
            {
                result = 0;
                return;
            }
            result = _first_number * _second_number;
        }
        private void Division()
        {
            if (_first_number == 0 || _second_number == 0)
            {
                result = 0;
                return;
            }
            result = _first_number / _second_number;
        }
        public void Exponentiation()
        {
            result = _first_number * _first_number;
        }
        public void Count()
        {
            _state = false;
            switch (_sign)
            {
                case '+':
                    Add();
                    break;
                case '-':
                    Substraction();
                    break;
                case '*':
                    Multiply();
                    break;
                case '/':
                    Division();
                    break;
                case 'p':
                    Exponentiation();
                    break;
                default:
                    Console.WriteLine("Operation not defined!");
                    break;
            }
        }
        public string GetResult()
        {
            return result.ToString();
        }
    }
}
