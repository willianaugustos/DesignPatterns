// See https://aka.ms/new-console-template for more information
Console.WriteLine("Testing singleton");

var sing1 = MySingleton.getInstance();
Console.WriteLine("This is the 1st hash");
Console.WriteLine(sing1.getHash());

var sing2 = MySingleton.getInstance();
Console.WriteLine("This is the 2nd hash");
Console.WriteLine(sing2.getHash());

Console.WriteLine("You see the same hash, because it works!");
