using System;

namespace HW3Normalization
{
    class Program
    {
         
        static void Main(string[] args)
        {
            var R = new string[]{"PID","HID", "PN", "S", "HS", "HZ", "HC"};
            for(int i = 0; i < R.Length;i++){
                for(int j = 0; j < R.Length;j++){
                    if(i !=j){
                        printSQL(R[i], R[j]);
                    }
                }
            }
        }
        static void printSQL(string att1, string att2){
            var SQLquery = "SELECT 'Rentals: " + att1 + " --> " + att2 + "' AS FD,\nCASE WHEN COUNT(*)=0 THEN 'MAY HOLD'\nELSE 'does not hold' END AS VALIDITY\nFROM (\n    SELECT R." + att1 +
            "\n    FROM Rentals R\n    GROUP BY R." + att1 + "\n    HAVING COUNT(DISTINCT R." + att2+ ") > 1\n) X;";
            Console.WriteLine(SQLquery);
        }
    }
}
