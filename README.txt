Console.WriteLine("What monster would you like to Annihilate? (Type the Symbol):");
List<Monster> dm = new List<Monster>();
string userinput = Console.ReadLine().ToUpper();
IEnumerable<Monster> query = from m in b.MonsterList where m.Symbol == userinput select m;

foreach (Monster m in query)
{
	m.Death(b);
	dm.Add(m);
}
if (query.Count() == 0)
{
	Console.SetCursorPosition(0, 15);
	Utilities.ClearCurrentConsoleLine();
	Console.WriteLine("There are no Symbols of" + userinput + " on the board!");
}
else
{
	foreach (Monster m in dm)
	{
		b.MonsterList.Remove(m);
	}
	Console.SetCursorPosition(0, 36);
	Utilities.ClearCurrentConsoleLine();
	Console.SetCursorPosition(0, 15);
	Utilities.ClearCurrentConsoleLine();
	Console.WriteLine("All monsters with the Symbol " + userinput + " are dead!");
	Console.ReadKey(true);
	p.ScrollOfAnn--;
	Inventory(p);
}