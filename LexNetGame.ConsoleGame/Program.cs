


var list = new List<string>();
list.Add("Hej");
var first = list[0];

var limitedList = new LimitedList<string>(5);
limitedList.Add("Hej");
var first2 = limitedList[0];

var game = new Game();
game.Run();

Console.WriteLine("Thanks for playing");
Console.ReadLine();
