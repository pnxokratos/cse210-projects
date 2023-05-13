using System;
using static System.Console;

class Details
{
    public void Statistics(int breathing, int reflecting, int sisting)
    {
        Clear();
        WriteLine($"> Breathing: {breathing}");
        WriteLine($"> Reflecting: {reflecting}");
        WriteLine($"> Listing: {sisting}");
    }

    public void AboutActivities()
    {
        //display the different activities
        Clear();
        WriteLine("> Breathing Activity:");
        WriteLine("The Breathing Activity is where you slow the pace of your breathing to calm yourself down and relax. You start by stating how long you would like to go for and then alternating between breathing in and out.");
        WriteLine();
        WriteLine("> Reflection Activity:");
        WriteLine("The Reflection Activity is where you ponder on something important to you. You will be given a prompt of either an event or somthing you care about and will then be able to ponder questions about it that generate on the scree.");
        WriteLine();
        WriteLine("> Listing Activity:");
        WriteLine("The Listing Activity Is wwhere you list as many things about a part of your life. You will be given a prompt and will then write as many things as you can relating to this prompt and will then be told how many things you stated.");
        WriteLine();
    }
}