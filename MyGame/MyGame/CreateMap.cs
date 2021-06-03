using System;

using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public static class CreateMap
    {
        /*public static string[,] GenerateRAndomMap()
        {
            var arr = new string[152, 8];
            
            for (var x = 0; x < arr.GetLength(0); x++)
                for (var y = 0; y < arr.GetLength(1); y++)
                { 
                    var rnd = new Random().Next(0,100);
                    arr[x, y] = " ";
                    if(rnd == 4)
                        arr[x,y] = "o";

                    if(x == arr.GetLength(0))
                        arr[x, y] = "o";

                }
            arr[149, 4] = "p";
            return arr;
        }*/

        public static string[,] CreatureMap(string map)
        {
            var separator = "\r\n";
            var rows = map.Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries);
            var result = new string[rows[0].Length, rows.Length];
            for (var x = 0; x < rows[0].Length; x++)
            for (var y = 0; y < rows.Length; y++)
                 result[x, y] = CreateMapBySymbol(rows[y][x]);
            return result;
        }

        private static string CreateMapBySymbol(char symbol)
        {
            switch (symbol)
            {
                case 'o':
                    return "cube";
                case 'p': 
                    return "pump";
                case ' ':
                    return null;
                default:
                    throw new Exception($"wrong character for {symbol}");
            }
        }
    }
}