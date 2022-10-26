using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class LoginHandler
    {
        private int correct_counter;
        public LoginHandler()
        {
            correct_counter = 0;
        }

        public void Correct()
        {
            correct_counter++;
        }

        public void ResetCounter()
        {
            correct_counter = 0;
        }

        public int GetCounter()
        {
            return this.correct_counter;
        }

    }
}
