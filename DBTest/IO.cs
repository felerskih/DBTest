using System;
using System.Collections.Generic;
using System.Text;

namespace DBTest
{
    class IO
    {
        private DBManager dbm = new DBManager();
        private readonly char insert = 'I';
        private readonly char delete = 'D';
        private readonly char select = 'S';
        private readonly char quit = 'Q';

        public void run()
        {
            string input;
            string[] parms;
            char cmd;
            input = Console.ReadLine();
            input = input.ToUpper();
            cmd = input[0];
            parms = input.Split();

            while (cmd != quit)
            {
                if (cmd == insert)
                {
                    dbm.Insert(parms[1], parms[2]);
                }
                
                if (cmd == delete)
                {
                    dbm.Delete(parms[1]);
                }

                if (cmd == select)
                {
                    Console.Write(dbm.QueryAll());
                }

                input = Console.ReadLine();
                input = input.ToUpper();
                cmd = input[0];
                parms = input.Split();
            }

        }
    }
}
