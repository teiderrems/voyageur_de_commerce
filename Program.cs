// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Point p1=new();

Point p2=new(1,2);
Point p3=new(3,4);
Point p4=new(5,6);



List<Point> points=GeneratePoint(10);
Algorithme algorithme=new(points);

points.ForEach(p=>System.Console.WriteLine(p));

algorithme.SimulatedAnnealing(900);


System.Console.WriteLine("\n\n"+algorithme+"\n");

algorithme.HillClimbing();

System.Console.WriteLine("\n\n"+algorithme+"\n");


static List<Point> GeneratePoint(int nbPoint){

    List<Point> points=[];
    Random random= new();

    for (int i = 0; i < nbPoint; i++)
    {
        points.Add(new Point(random.NextDouble()*(-100+500)+100, random.NextDouble()*(-100+700)+100));
    }
    return points;
}


