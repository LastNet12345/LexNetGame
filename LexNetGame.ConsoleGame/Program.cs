


var list = new List<string>();
string x = "Hej på dig";

foreach (var item in x)
{
    Console.WriteLine(item);
}

list.Add("Hej");
var first = list[0];

foreach (var item in list)
{
    Console.WriteLine(item);
}

var limitedList = new LimitedList<string>(5);
limitedList.Add("Hej");
var first2 = limitedList[0];

foreach (var item in limitedList)
{
    Console.WriteLine(item);
}

var game = new Game();
game.Run();

Console.WriteLine("Thanks for playing");
Console.ReadLine();
