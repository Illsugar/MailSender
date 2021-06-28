using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    internal class CalculationFactorialTask
    {
        private readonly Thread _Thread;
        private readonly int _Number;

        private int _Result;
        public int Result
        {
            get
            {
                Join();
                return _Result;
            }
            private set => _Result = value;
        }

        public CalculationFactorialTask(int Number)
        {
            _Number = Number;
            _Thread = new Thread(Calculation);
        }

        public void Start() => _Thread.Start();

        private void Calculation()
        {
            var fact = 1;
            for (var i = 1; i < _Number; i++)
                fact *= i;
            _Result = fact;
        }

        public void Join() => _Thread.Join();
    }
}
