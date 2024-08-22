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
      GameXO Game = new GameXO();//создали новый класс для доски 
      char[] board = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };//создали символьный тип массива из максимального колличества
                                                                                 //(ходов или полей в на доске) максимум их 9
      Game.Print(board);
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
            board[motion] = (char)GameXO.Char.FirstPlayer;//заменили на символ иксолик
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
            board[motion] = (char)GameXO.Char.SecondPlayer;//заменили поле на сивол
          }
          else
          {
            i = i - 1;//вернули счетчик если ввели уже переменную которая уже использовалась
            continue;
          }
        }
        Game.Print(board);//обновили доску
        if (Game.Сheck(board))//проверили доску на вариант выигрышной комбинации в номвом методе
        {
        //  break;
        }
      }

    }
    
    
    
    
  }
}
