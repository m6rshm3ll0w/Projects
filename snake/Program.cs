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

char csimb = 'x';
char cspas = 'x';
char applsymb = '@';
string axiz = "y-";
int speed = 5;
var keyd = ConsoleKey.UpArrow;
List<int> sx = new List<int>() { x / 2, x / 2 };
List<int> sy = new List<int>() { y / 2, y / 2 };
List<int> ax = new List<int>() { x / 2, x / 2 };
List<int> ay = new List<int>() { y / 2, y / 2 };





Console.SetWindowSize(width: x, height: y);

Console.SetBufferSize(width: x, height: y);

Console.SetCursorPosition(xc, yc);
Console.Write(csimb);

while (true)
{

    if (axiz == "y-")
    {
        Console.SetCursorPosition(xc, yc);
        Console.Write(cspas);

        yc--;
        if (yc < 0) yc = 0;

        Console.SetCursorPosition(xc, yc);
        Console.Write(csimb);
    }
    else if (axiz == "y+")
    {
        Console.SetCursorPosition(xc, yc);
        Console.Write(cspas);

        yc++;
        if (yc > y - 1) yc = y - 1;

        Console.SetCursorPosition(xc, yc);
        Console.Write(csimb);
    }
    else if (axiz == "x-")
    {
        Console.SetCursorPosition(xc, yc);
        Console.Write(cspas);

        xc--;
        if (xc < 0) xc = 0;

        Console.SetCursorPosition(xc, yc);
        Console.Write(csimb);
    }
    else if (axiz == "x")
    {
        Console.SetCursorPosition(xc, yc);
        Console.Write(cspas);

        xc++;
        if (xc > x - 1) xc = x - 1;

        Console.SetCursorPosition(xc, yc);
        Console.Write(csimb);
    }
    Console.SetCursorPosition(1, 1);
    Console.Write($"{snake_len},{axiz}");

    ax.Add(xc);
    ay.Add(yc);

    if (apple < max_ap) //tab
    {
        axr = rand.Next(0, x);
        ayr = rand.Next(0, y);

        Console.SetCursorPosition(axr, ayr);
        Console.Write(applsymb);
        apple++;
    }


    keyd = Console.ReadKey().Key;

    Thread.Sleep(speed);
    if (keyd == ConsoleKey.UpArrow && axiz != "y-" && axiz != "y+") //  y_up
    {
        Console.SetCursorPosition(xc, yc);
        Console.Write(cspas);

        yc--;
        if (yc < 0) yc = 0;

        Console.SetCursorPosition(xc, yc);
        Console.Write(csimb);
        axiz = "y-";
    }
    else if (keyd == ConsoleKey.DownArrow && axiz != "y-" && axiz != "y+") //  y_down
    {
        Console.SetCursorPosition(xc, yc);
        Console.Write(cspas);

        yc++;
        if (yc > y - 1) yc = y - 1;

        Console.SetCursorPosition(xc, yc);
        Console.Write(csimb);
        axiz = "y+";

    }
    else if (keyd == ConsoleKey.LeftArrow && axiz != "x-" && axiz != "x+") //  x_left
    {
        Console.SetCursorPosition(xc, yc);
        Console.Write(cspas);

        xc--;
        if (xc < 0) xc = 0;

        Console.SetCursorPosition(xc, yc);
        Console.Write(csimb);
        axiz = "x-";

    }
    else if (keyd == ConsoleKey.RightArrow && axiz != "x-" && axiz != "x+") //  x_right
    {
        Console.SetCursorPosition(xc, yc);
        Console.Write(cspas);

        xc++;
        if (xc > x - 1) xc = x - 1;

        Console.SetCursorPosition(xc, yc);
        Console.Write(csimb);
        //axiz = "x+";

    }


    if (axr == xc && ayr == yc)
    {
        snake_len++;
        apple--;
    }



    sx.Add(xc);
    sy.Add(yc);

    int ccx = sx[sx.Count - 1 - snake_len];
    int ccy = sy[sy.Count - 1 - snake_len];
    int acx = ax[ax.Count - 1 - snake_len];
    int acy = ay[ay.Count - 1 - snake_len];

    Console.SetCursorPosition(ccx, ccy);
    Console.Write(" ");
    Console.SetCursorPosition(acx, acy);
    Console.Write(" ");

}