using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
  internal class GameXO
  {
    /// <summary>
    /// Выводит игровое поле, с символами массива
    /// </summary>
    /// <param name="board">игровое поле из символов которые вводятся с консоли</param>
    public void Print(char[] board)//
    {
      Console.Clear();
      Console.WriteLine("  -------------------------");
      Console.WriteLine("  |       |       |       |");
      Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", board[0], board[1], board[2]);
      Console.WriteLine("  |       |       |       |");
      Console.WriteLine("  -------------------------");
      Console.WriteLine("  |       |       |       |");
      Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", board[3], board[4], board[5]);
      Console.WriteLine("  |       |       |       |");
      Console.WriteLine("  -------------------------");
      Console.WriteLine("  |       |       |       |");
      Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", board[6], board[7], board[8]);
      Console.WriteLine("  |       |       |       |");
      Console.WriteLine("  -------------------------");
    }
    /// <summary>
    /// функция проверки на победу
    /// </summary>
    /// <param name="board">игровое поле с массивом символов для проверки на победу</param>
    /// <returns></returns>
    public bool Сheck(char[] board)//создали метод проверки комбинации
    {
      bool FlagWinO;//логическая переменная игрока олик
      bool FlagWinX;//логическая переменная игрока иксолик
      
      for (int i = 0; i < 8; i++)//цикл для проверки строки их всего 8 комбинации
                                 //состоят из трех по горизонтале трех по вертикали и две по диагонали
      {
        int zero = 0;//переменная для игрока олик
        int crest = 0;//переменная игрока иксолик
        for (int j = 0; j < 3; j++)//цикл для проверки столбика их всего три
        {
          if (board[combo[i, j]] == (char)Char.SecondPlayer)//бежим по матрице ищем символ игрока олик
          {
            zero++;//прибавляем
          }
          else if (board[combo[i, j]] == (char)Char.FirstPlayer)//бежим по матрице ищем символ игрока иксолик
          {
            crest++;//прибавляем
          }

          if (zero == 3)//если условие что переменная олика в матрице встречается 3 раза то ниже
          {
            FlagWinO = true;//срабатывает логическая переменная правда 
            Console.WriteLine($"пОБЕДИЛ о");//вывели на консоль текст с победой олика
            return true;
          }
          else if (crest == 3)//если условие что переменная иксолика в матрице встречается 3 раза то ниже
          {
            FlagWinX = true;//срабатывает логическая переменная правда 
            Console.WriteLine($"пОБЕДИЛ Х");// вывели на консоль текст с победой иксолика
            return true;
          }

        }
      }
      return false;//если ниодного выигрыша вернули ложь 
    }
    /// <summary>
    /// выигрышная комбинация
    /// </summary>
     private int[,] combo = new int[,]//создали двумерную матрицу (строка и столбик)
      {
        {0,1,2},
        {3,4,5},
        {6,7,8},
        {0,3,6},
        {1,4,7},
        {2,5,8},
        {0,4,8},
        {2,4,6}
      };
    /// <summary>
    /// перечисление переменных
    /// </summary>
    public enum Char
    {
      FirstPlayer = 'x',
      SecondPlayer = 'o'
    }
  }
}
