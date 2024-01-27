using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Xml.Linq;



Console.CursorVisible = false;

// инициализация 
var rand = new Random();
int x = 25;
int y = 16;
int axr = 0;
int ayr = 0;
int xc = x / 2;
int yc = y / 2;
int apple = 0;
int snake_len = 1;
int max_ap = 1;
int death = 0;
char csimb = 'x';
char cspas = 'x';
char applsymb = '@';
//string axiz = "y-";
int speed = 5;
var keyd = ConsoleKey.UpArrow;
List<int> sx = new List<int>() { x / 2, x / 2 };
List<int> sy = new List<int>() { y / 2, y / 2 };
//List<int> ax = new List<int>() { x / 2, x / 2 };
//List<int> ay = new List<int>() { y / 2, y / 2 };






Console.SetWindowSize(width: x, height: y);

Console.SetBufferSize(width: x, height: y);

Console.SetCursorPosition(xc, yc);
Console.Write(csimb);


while (death != 1)
{

    //// ↓ автоматическое движение по осям
    //if (axiz == "y-")
    //{
    //    Console.SetCursorPosition(xc, yc);
    //    Console.Write(cspas);

    //    yc--;
    //    if (yc < 0) { yc = 0; death = 1;  }

    //    Console.SetCursorPosition(xc, yc);
    //    Console.Write(csimb);
    //}
    //else if (axiz == "y+")
    //{
    //    Console.SetCursorPosition(xc, yc);
    //    Console.Write(cspas);

    //    yc++;
    //    if (yc > y - 1) {yc = y - 1; death = 1; }

    //    Console.SetCursorPosition(xc, yc);
    //    Console.Write(csimb);
    //}
    //else if (axiz == "x-")
    //{
    //    Console.SetCursorPosition(xc, yc);
    //    Console.Write(cspas);

    //    xc--;
    //    if (xc < 0) {xc = 0; death = 1; }

    //    Console.SetCursorPosition(xc, yc);
    //    Console.Write(csimb);
    //}
    //else if (axiz == "x+")
    //{
    //    Console.SetCursorPosition(xc, yc);
    //    Console.Write(cspas);

    //    xc++;
    //    if (xc > x - 1) {xc = x - 1; death = 1; }

    //    Console.SetCursorPosition(xc, yc);
    //    Console.Write(csimb);
    //}
    //// ↑ автоматическое движение по осям

    ////Console.SetCursorPosition(1, 1); // вывод счета
    ////Console.Write($"{snake_len},{axiz}");

    //sx.Add(xc); // запись авто перемешения по X
    //sy.Add(yc); // запись авто перемешения по Y

    // генерация яблок
    if (apple < max_ap) 
    {
        axr = rand.Next(0, x);
        ayr = rand.Next(0, y);

        Console.SetCursorPosition(axr, ayr);
        Console.Write(applsymb);
        apple++;
    }

    // ↓ считывание нажатия
    keyd = Console.ReadKey().Key;
    // ↑ считывание нажатия

    //Thread.Sleep(speed); // это должна быть задержка

    //  проверка на нажатие клавиши вниз (y-- - up)
    if (keyd == ConsoleKey.UpArrow /*&& axiz != "y-" && axiz != "y+"*/) 
    {
        Console.SetCursorPosition(xc, yc);
        Console.Write(cspas);

        yc--;
        if (yc < 0) {yc = 0; death = 1; }

        Console.SetCursorPosition(xc, yc);
        Console.Write(csimb);
        //axiz = "y-";
    }

    //  проверка на нажатие клавиши вниз (y++ - down)
    else if (keyd == ConsoleKey.DownArrow /*&& axiz != "y-" && axiz != "y+"*/) 
    {
        Console.SetCursorPosition(xc, yc);
        Console.Write(cspas);

        yc++;
        if (yc > y - 1) {yc = y - 1; death = 1; }

        Console.SetCursorPosition(xc, yc);
        Console.Write(csimb);
        //axiz = "y+";

    }

    //  проверка на нажатие клавиши влево (x-- - down)
    else if (keyd == ConsoleKey.LeftArrow /*&& axiz != "x-" && axiz != "x+"*/) 
    {
        Console.SetCursorPosition(xc, yc);
        Console.Write(cspas);

        xc--;
        if (xc < 0) {xc = 0; death = 1; }

        Console.SetCursorPosition(xc, yc);
        Console.Write(csimb);
        //axiz = "x-";

    }

    //  проверка на нажатие клавиши право (x++ - down)
    else if (keyd == ConsoleKey.RightArrow /*&& axiz != "x-" && axiz != "x+"*/) 
    {
        Console.SetCursorPosition(xc, yc);
        Console.Write(cspas);

        xc++;
        if (xc > x - 1) {xc = x - 1; death = 1; }

        Console.SetCursorPosition(xc, yc);
        Console.Write(csimb);
        //axiz = "x+";

    }

    // проверка на сьедение яблок
    if (axr == xc && ayr == yc) 
    {
        snake_len++;
        apple--;
    }


    sx.Add(xc); // запись перемешения по X 
    sy.Add(yc); // запись перемешения по Y

    // ↓ получение текущих координат
    int ccx = sx[sx.Count - 1 - snake_len];
    int ccy = sy[sy.Count - 1 - snake_len];
    //int acx = ax[ax.Count - 1 - snake_len];
    //int acy = ay[ay.Count - 1 - snake_len];
    // ↑ получение текущих координат

    Console.SetCursorPosition(ccx, ccy); // отчистка ранне закрашенного поля
    Console.Write(" ");
    //Console.SetCursorPosition(acx, acy); // отчистка ранне закрашенного поля
    //Console.Write(" ");

}
Console.Clear(); 
Console.WriteLine("Death!");
Console.ReadKey();
