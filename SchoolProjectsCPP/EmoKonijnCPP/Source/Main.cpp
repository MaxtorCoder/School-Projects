#include <iostream>
#include <string>
#include <vector>
#include "Rabbit.h"

int main()
{
    std::vector<Rabbit> rabbits
    {
        { Rabbit("(?.?)") },
        { Rabbit("(x.x)") },
        { Rabbit("(>.<)") },
        { Rabbit("(^.^)") },
    };
    
    for (int i = 0; i < rabbits.size(); ++i)
    {
        std::cout << i + 1 << ": \n";
        rabbits[i].DisplayRabbit();
    }
    
    while (true)
    {
        int input = 0;
        std::cout << "Choose which Rabbit you want to display: ";
        std::cin >> input;
    
        if (input <= rabbits.size() && input != 0)
            rabbits[input - 1].DisplayRabbit();
        else
            std::cout << "Please input a new number\n";
    }
}