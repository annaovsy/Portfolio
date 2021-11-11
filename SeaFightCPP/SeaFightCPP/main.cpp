#include <iostream>
#include <ctime>
#include <stdlib.h> 
#include <windows.h>
#include <conio.h>
#include <iomanip>
#include "SeaFight.h"

using namespace std;

int main()
{
    setlocale(LC_ALL, "rus");
    // srand(time(NULL));

    int playerField[n][n] = { 0 };
    int computerField[n][n] = { 0 };
    int disguisePlayer[n][n] = { 0 };
    int disguiseComp[n][n] = { 0 };
    int shipsPlayer[N] = { 0, 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };    // запись количества палуб
    int shipsComp[N] = { 0, 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };     //  в каждом корабле


    for (int i = 1; i <= n; i++)
    {
        ShipsConstruction(playerField, shipsPlayer[i], i);   // поле, количество палуб, номер корабля
    }
    for (int i = 1; i <= n; i++)
    {
        ShipsConstruction(computerField, shipsComp[i], i);
    }
    Game(playerField, computerField, disguisePlayer, disguiseComp, shipsPlayer, shipsComp);


    return 0;
}
