#include "Rabbit.h"

Rabbit::Rabbit(std::string face)
{
    Face += " ()_()\n";
    Face += " " + face;
    Face += "\n'(\")(\")'\n";
}

void Rabbit::DisplayRabbit()
{
    std::cout << Face;
}