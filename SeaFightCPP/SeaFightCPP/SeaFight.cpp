#include <iostream>
#include <ctime>
#include <stdlib.h> 
#include <windows.h>
#include <conio.h>
#include <iomanip>
#include "SeaFight.h"

using namespace std;

void Print(int field[][n], int disguiseField[][n])
{
    cout << "\t    ";
    for (int i = 0; i < n; i++)
    {
        cout << i << " ";
    }
    cout << endl << "\t  ";
    for (int i = 0; i < n + 1; i++)
        cout << "--";

    cout << endl;
    for (int i = 0; i < n; i++)
    {
        cout << "\t" << i << " | ";
        for (int j = 0; j < n; j++)
        {
            if (disguiseField[i][j] == 1)
            {
                if (field[i][j] == 0)
                    cout << "- ";
                else
                    cout << "x ";
            }
            else
                cout << "  ";
        }
        cout << endl;
    }
}

int ShipsConstruction(int field[][n], int shipDeck, int number)
{
    int x, y;    // x - координата по оси абцисс, у - координата по оси ординат
    int xBuffer;
    int yBuffer;

    int direction = 0;      // переменная для направления
    bool canBeInstalled;
    do
    {
        x = rand() % n;
        y = rand() % n;

        xBuffer = x;
        yBuffer = y;

        direction = rand() % 4;     // генерация направления корабля

        // проверка возможности установки корабля
        canBeInstalled = true;
        for (int i = 0; i < shipDeck; i++)
        {
            if (x < 0 || y < 0 || x >= n || y >= n)
            {
                canBeInstalled = false;
                break;
            }
            if (field[x][y] >= 1 ||
                field[x][y + 1] >= 1 ||
                field[x][y - 1] >= 1 ||
                field[x + 1][y] >= 1 ||
                field[x + 1][y + 1] >= 1 ||
                field[x + 1][y - 1] >= 1 ||
                field[x - 1][y] >= 1 ||
                field[x - 1][y + 1] >= 1 ||
                field[x - 1][y - 1] >= 1)
            {
                canBeInstalled = false;
                break;
            }
            switch (direction)
            {
            case 0:
                x++;
                break;
            case 1:
                y++;
                break;
            case 2:
                x--;
                break;
            case 3:
                y--;
                break;
            }
        }
    } while (canBeInstalled != true);

    if (canBeInstalled)     //если установка возможна
    {
        x = xBuffer;
        y = yBuffer;
        for (int i = 0; i < shipDeck; i++)
        {
            // то устанавливаем корабли
            field[x][y] = number;
            switch (direction)
            {
            case 0:
                x++;
                break;
            case 1:
                y++;
                break;
            case 2:
                x--;
                break;
            case 3:
                y--;
                break;
            }
        }
    }
    return field[n][n];
}

int Shooting(int field[][n], int disguiseField[][n], int x, int y, int ships[N])
{
    int rezult = 0;

    if (field[x][y] >= 1)
    {
        ships[field[x][y]]--;
        if (ships[field[x][y]] == 0)
            rezult = 1;
        else
            rezult = 2;

        field[x][y] = -1;
    }

    disguiseField[x][y] = 1;

    return rezult;
}

void Game(int playerField[][n], int computerField[][n], int disguisePlayer[][n], int disguiseComp[][n], int shipsPlayer[N], int shipsComp[N])
{
    bool playerWin = 0;
    bool compWin = 0;

    bool yourTurn = true;   // переключение хода
    int x;
    int y;

    while (playerWin == 0 && compWin == 0)
    {
        int rezultShot = 0;
        do
        {
            cout << endl << "Ваше поле: " << endl;
            Print(playerField, disguisePlayer);
            cout << endl << "Поле противника: " << endl;
            Print(computerField, disguiseComp);

            if (yourTurn)
            {
                cout << "\nВаш ход! Введите координаты выстрела ( строка столбец )" << endl;
                cin >> x >> y;
                rezultShot = Shooting(computerField, disguiseComp, x, y, shipsComp);
                if (rezultShot == 1)
                {
                    bool killed = 1;
                    for (int i = N; i >= 0; i--)
                    {
                        if (shipsComp[i] != 0)
                        {
                            killed = 0;
                            break;
                        }
                    }

                    if (killed == 1)
                    {
                        playerWin = 1;
                        break;
                    }
                    cout << "Убит!" << endl;
                }

                else if (rezultShot == 2)
                    cout << "Ранен!" << endl;
                else
                    cout << "Промах! " << endl;
            }
            else
            {
                x = rand() % n;
                y = rand() % n;
                cout << "\nХод компьютера " << endl;
                Sleep(1500);
                rezultShot = Shooting(playerField, disguisePlayer, x, y, shipsPlayer);
                if (rezultShot == 1)
                {
                    bool killed = 1;
                    for (int i = N; i >= 0; i--)
                    {
                        if (shipsPlayer[i] != 0)
                        {
                            killed = 0;
                            break;
                        }
                    }

                    if (killed == 1)
                    {
                        compWin = 1;
                        break;
                    }

                    cout << "Убит!" << endl;
                }

                else if (rezultShot == 2)
                    cout << "Ранен!" << endl;
                else
                    cout << "Промах! " << endl;
            }



            Sleep(2000);
            system("cls");
        } while (rezultShot != 0);

        yourTurn = !yourTurn;
    }

    if (playerWin)
    {
        cout << "Вы победили!" << endl << endl;
    }
    else if (compWin)
    {
        cout << "Вы проиграли!" << endl << endl;
    }

}
