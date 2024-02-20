using System.Diagnostics.SymbolStore;

Console.WriteLine("Krestiki noliki");

static void printDask(string one, string two, string three, string four, string five, string six, string seven, string eight, string nine)
{
    Console.WriteLine($"{one}|{two}|{three}");
    Console.WriteLine($"-----");
    Console.WriteLine($"{four}|{five}|{six}");
    Console.WriteLine($"-----");
    Console.WriteLine($"{seven}|{eight}|{nine}");
}

static bool isCellEmpty(string cell)
{
    return cell == " ";
}

static bool makeMove(ref string cell, string symbol)
{
    if (isCellEmpty(cell) || cell == symbol )
    {
        cell = symbol;
        return true;
    }
    else
    {
        Console.WriteLine("Invalid move. Cell is already occupied.");
        return false;
    }
}

static bool checkWin(string c1, string c2, string c3)
{
    return (c1 != " " && c1 == c2 && c2 == c3);
}

static bool checkDraw(string cell_1, string cell_2, string cell_3, string cell_4, string cell_5, string cell_6, string cell_7, string cell_8, string cell_9)
{
    return !isCellEmpty(cell_1) && !isCellEmpty(cell_2) && !isCellEmpty(cell_3) &&
           !isCellEmpty(cell_4) && !isCellEmpty(cell_5) && !isCellEmpty(cell_6) &&
           !isCellEmpty(cell_7) && !isCellEmpty(cell_8) && !isCellEmpty(cell_9);
}

static bool checkGameResult(string cell_1, string cell_2, string cell_3, string cell_4, string cell_5, string cell_6, string cell_7, string cell_8, string cell_9, string currentPlayer)
{

    if (checkWin(cell_1, cell_2, cell_3) || checkWin(cell_4, cell_5, cell_6) || checkWin(cell_7, cell_8, cell_9) ||
        checkWin(cell_1, cell_4, cell_7) || checkWin(cell_2, cell_5, cell_8) || checkWin(cell_3, cell_6, cell_9) ||
        checkWin(cell_1, cell_5, cell_9) || checkWin(cell_3, cell_5, cell_7))
    {
        printDask(cell_1, cell_2, cell_3, cell_4, cell_5, cell_6, cell_7, cell_8, cell_9);
        Console.WriteLine($"Player {currentPlayer} WINS!!!");
        return true;
    }

    else if (checkDraw(cell_1, cell_2, cell_3, cell_4, cell_5, cell_6, cell_7, cell_8, cell_9))
    {
        printDask(cell_1, cell_2, cell_3, cell_4, cell_5, cell_6, cell_7, cell_8, cell_9);
        Console.WriteLine("DRAW!");
        return true;
    }

    return false;
}


Console.WriteLine("Krestiki noliki");

string cell_1 = " ";
string cell_2 = " ";
string cell_3 = " ";
string cell_4 = " ";
string cell_5 = " ";
string cell_6 = " ";
string cell_7 = " ";
string cell_8 = " ";
string cell_9 = " ";

bool isEnd = false;
string currentPlayer = "X"; 
int choice;
Console.WriteLine("Welcome to Tic Tac Toe");
Console.WriteLine("Choose the game mode");
Console.WriteLine("1. With another player");
Console.WriteLine("2. With BOT");
Console.WriteLine("3. Exit.");

choice = int.Parse(Console.ReadLine());

while (!isEnd)
        {
            if (choice == 1)
            {
                Random random = new Random();
                int randNum = random.Next(0, 2);
                if (randNum == 1)
                {
                    currentPlayer = "0";
                    Console.WriteLine("Player 0 go first");
                }
                else
                {
                    currentPlayer = "X";
                    Console.WriteLine("Player X go first");
                }

                while (!isEnd)
                {
                    printDask(cell_1, cell_2, cell_3, cell_4, cell_5, cell_6, cell_7, cell_8, cell_9);
                    Console.WriteLine($"Player {currentPlayer} turn");

                    Console.WriteLine("Enter the number of the cell (1-9): ");
                    string cell_num = Console.ReadLine();
                    string cell_sym = "";
                    switch (cell_num)
                    {
                        case "1":
                            cell_sym = cell_1;
                            break;
                        case "2":
                            cell_sym = cell_2;
                            break;
                        case "3":
                            cell_sym = cell_3;
                            break;
                        case "4":
                            cell_sym = cell_4;
                            break;
                        case "5":
                            cell_sym = cell_5;
                            break;
                        case "6":
                            cell_sym = cell_6;
                            break;
                        case "7":
                            cell_sym = cell_7;
                            break;
                        case "8":
                            cell_sym = cell_8;
                            break;
                        case "9":
                            cell_sym = cell_9;
                            break;
                        default:
                            Console.WriteLine("Invalid cell number.");
                            break;
                    }

                    if (makeMove(ref cell_sym, currentPlayer))
                    {
                        switch (cell_num)
                        {
                            case "1":
                                cell_1 = cell_sym;
                                break;
                            case "2":
                                cell_2 = cell_sym;
                                break;
                            case "3":
                                cell_3 = cell_sym;
                                break;
                            case "4":
                                cell_4 = cell_sym;
                                break;
                            case "5":
                                cell_5 = cell_sym;
                                break;
                            case "6":
                                cell_6 = cell_sym;
                                break;
                            case "7":
                                cell_7 = cell_sym;
                                break;
                            case "8":
                                cell_8 = cell_sym;
                                break;
                            case "9":
                                cell_9 = cell_sym;
                                break;
                        }
                        if (checkGameResult(cell_1, cell_2, cell_3, cell_4, cell_5, cell_6, cell_7, cell_8, cell_9, currentPlayer))
                            isEnd = true;
                        currentPlayer = (currentPlayer == "X") ? "0" : "X";
                    }
                }
            }
            else if (choice == 2)
            {

                Random random = new Random();
                int randNum = random.Next(0, 2);
                if (randNum == 1)
                {
                    currentPlayer = "X";
                    Console.WriteLine("Player X go first");
                }
                else
                {
                    currentPlayer = "0";
                    Console.WriteLine("Bot goes first");
                }
                while (!isEnd)
                {
                    printDask(cell_1, cell_2, cell_3, cell_4, cell_5, cell_6, cell_7, cell_8, cell_9);
                    Console.WriteLine($"Player {currentPlayer} turn");

                    if (currentPlayer == "X")
                    {
                        Console.WriteLine("Enter the number of the cell (1-9): ");
                        string cell_num = Console.ReadLine();
                        string cell_sym = "";
                        switch (cell_num)
                        {
                            case "1":
                                cell_sym = cell_1;
                                break;
                            case "2":
                                cell_sym = cell_2;
                                break;
                            case "3":
                                cell_sym = cell_3;
                                break;
                            case "4":
                                cell_sym = cell_4;
                                break;
                            case "5":
                                cell_sym = cell_5;
                                break;
                            case "6":
                                cell_sym = cell_6;
                                break;
                            case "7":
                                cell_sym = cell_7;
                                break;
                            case "8":
                                cell_sym = cell_8;
                                break;
                            case "9":
                                cell_sym = cell_9;
                                break;
                            default:
                                Console.WriteLine("Invalid cell number.");
                                break;
                        }

                        if (makeMove(ref cell_sym, currentPlayer))
                        {
                            switch (cell_num)
                            {
                                case "1":
                                    cell_1 = cell_sym;
                                    break;
                                case "2":
                                    cell_2 = cell_sym;
                                    break;
                                case "3":
                                    cell_3 = cell_sym;
                                    break;
                                case "4":
                                    cell_4 = cell_sym;
                                    break;
                                case "5":
                                    cell_5 = cell_sym;
                                    break;
                                case "6":
                                    cell_6 = cell_sym;
                                    break;
                                case "7":
                                    cell_7 = cell_sym;
                                    break;
                                case "8":
                                    cell_8 = cell_sym;
                                    break;
                                case "9":
                                    cell_9 = cell_sym;
                                    break;
                            }
                            if (checkGameResult(cell_1, cell_2, cell_3, cell_4, cell_5, cell_6, cell_7, cell_8, cell_9, currentPlayer))
                                isEnd = true;
                            currentPlayer = (currentPlayer == "X") ? "0" : "X";
                        }
                    }
                    else if (currentPlayer == "0")
                    {
                        int botMove = random.Next(1, 10);
                        string cell_num = botMove.ToString();
                        string cell_sym = "";
                        switch (cell_num)
                        {
                            case "1":
                                cell_sym = cell_1;
                                break;
                            case "2":
                                cell_sym = cell_2;
                                break;
                            case "3":
                                cell_sym = cell_3;
                                break;
                            case "4":
                                cell_sym = cell_4;
                                break;
                            case "5":
                                cell_sym = cell_5;
                                break;
                            case "6":
                                cell_sym = cell_6;
                                break;
                            case "7":
                                cell_sym = cell_7;
                                break;
                            case "8":
                                cell_sym = cell_8;
                                break;
                            case "9":
                                cell_sym = cell_9;
                                break;
                            default:
                                Console.WriteLine("Invalid cell number.");
                                break;
                        }




                        if (makeMove(ref cell_sym, currentPlayer))
                        {
                            switch (cell_num)
                            {
                                case "1":
                                    cell_1 = cell_sym;
                                    break;
                                case "2":
                                    cell_2 = cell_sym;
                                    break;
                                case "3":
                                    cell_3 = cell_sym;
                                    break;
                                case "4":
                                    cell_4 = cell_sym;
                                    break;
                                case "5":
                                    cell_5 = cell_sym;
                                    break;
                                case "6":
                                    cell_6 = cell_sym;
                                    break;
                                case "7":
                                    cell_7 = cell_sym;
                                    break;
                                case "8":
                                    cell_8 = cell_sym;
                                    break;
                                case "9":
                                    cell_9 = cell_sym;
                                    break;
                            }
                            if (checkGameResult(cell_1, cell_2, cell_3, cell_4, cell_5, cell_6, cell_7, cell_8, cell_9, currentPlayer))
                                isEnd = true;
                            currentPlayer = (currentPlayer == "X") ? "O" : "X";
                        }
                    }

                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Exiting...");
                break;
            }
        }
