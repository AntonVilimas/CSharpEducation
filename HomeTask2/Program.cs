using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Program gameboard = new Program();//создали новый класс для доски 
      char[] board = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };//создали символьный тип массива из максимального колличества
                                                                                 //(ходов или полей в на доске) максимум их 9
      gameboard.Print(board);
      for (int i = 0; i < 10; i++)
      {
        if (i % 2 == 0) //самое просток раз игроков 2 то можно поставить условие счетчика четное и не четное
                        //(четный индекс массива это ход игрока х иксолик)
        {
          int motion = Convert.ToInt32(Console.ReadLine())-1;//создали переменную ход которая целочисленное и на единицу больше так как индекс
                                                             //массива начинается с 0 а переменная хода с 1 (переменная хода от 1 до 9 по условию,
                                                             //пока не сделал ограничение)
          if (board[motion] == ' ')//если в поле с ходом пустой символ
          {
            board[motion] = 'x';//заменили на символ иксолик
          }
          else
          {
            i = i - 1;//иначе вернули назад счетчик для ввода корректного значения (0-9)
            continue;
          }


        }
        else if (i % 2!= 0)//не четное ход игрока олик
        {
          int motion =Convert.ToInt32(Console.ReadLine())-1;//конвертнули в инт
          if (board[motion] == ' ')//проверили поле есть там уже символ или нет
          {
            board[motion] = 'o';//заменили поле на сивол
          }
          else
          {
            i = i - 1;//вернули счетчик если ввели уже переменную которая уже использовалась
            continue;
          }
        }
        gameboard.Print(board);//обновили доску
        if (gameboard.check(board))//проверили доску на вариант выигрышной комбинации в номвом методе
        {
        //  break;
        }
      }

    }
    private void Print(char[] board)//создали метод вывода доски к которой обращаемся 
    {
      Console.Clear();
      Console.WriteLine("  -------------------------");
      Console.WriteLine("  |       |       |       |");
      Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", board[0], board[1], board[2]);//посути это не матрица
                                                                                           //а массив который состоит из 9 индексов
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
    private bool check(char[] board)//создали метод проверки комбинации
    {
      bool FlagWinO;//логическая переменная игрока олик
      bool FlagWinX;//логическая переменная игрока иксолик
      int[,] combo = new int[,]//создали двумерную матрицу (строка и столбик)
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
      for (int i = 0; i < 8; i++)//цикл для проверки строки их всего 8 комбинации
                                 //состоят из трех по горизонтале трех по вертикали и две по диагонали
      {
        int zero = 0;//переменная для игрока олик
        int crest = 0;//переменная игрока иксолик
        for (int j = 0;j < 3; j++)//цикл для проверки столбика их всего три
        {
          if (board[combo[i, j]] == 'o')//бежим по матрице ищем символ игрока олик
          {
            zero++;//прибавляем
          }
          else if (board[combo[i, j]] == 'x')//бежим по матрице ищем символ игрока иксолик
          {
            crest++;//прибавляем
          }
          
          if(zero == 3 )//если условие что переменная олика в матрице встречается 3 раза то ниже
          {
            FlagWinO = true;//срабатывает логическая переменная правда 
            Console.WriteLine($"пОБЕДИЛ о");//вывели на консоль текст с победой олика
            return true;
          }
          else if (crest == 3)//если условие что переменная иксолика в матрице встречается 3 раза то ниже
          {
            FlagWinX = true;//срабатывает логическая переменная правда 
            Console.WriteLine($"пОБЕДИЛ Х");// вывели на консоль текст с победой иксолика
            return true ;
          }

        }
      }
      return false;//если ниодного выигрыша вернули ложь 
    }
    
    
  }
}
