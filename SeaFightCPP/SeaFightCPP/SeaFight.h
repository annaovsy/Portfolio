#pragma once

using namespace std;

const int n = 10;
const int N = 11;

void Print(int field[][n], int disguiseField[][n]);

int ShipsConstruction(int field[][n], int shipDeck, int number);

int Shooting(int field[][n], int disguiseField[][n], int x, int y, int ships[N]);

void Game(int playerField[][n], int computerField[][n], int disguisePlayer[][n], int disguiseComp[][n], int shipsPlayer[N], int shipsComp[N]);
