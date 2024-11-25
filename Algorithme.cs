class Algorithme
{
    private List<Point> Points{ get; set; }


    public Algorithme(){
        Points=[];
    }

    public Algorithme(List<Point> points){
        Points=points;
    }

    public void AddSinglePoint(Point point){
        Points.Add(point);
    }

    public void AddManyPoint(List<Point> points){

        if (Points.Count==0)
        {
            Points=points;
        }
        else
        {
            Points.AddRange(Points);
        }
    }

    public double Fitness(List<Point> points){

        double som=0.0;

        for (int i = 0; i < points.Count-1; i++)
        {
            som+=points[i].Distance(points[i+1]);
        }

        return som;
    }

    private double Error(double delta,double t){
        return Math.Exp(delta/t);
    }

    public List<Point> PermutPoint(List<Point> points,int i,int j){
        
        if (i<points.Count && j<points.Count && i!=j)
        {
            Point[] p =[..points];
            Point temp=points[i];
            p[i]=points[j];
            p[j]=temp;
            return [..p];
        }
        return points;
    }

    public void  SimulatedAnnealing(double T,int max_iter=50){

        Random random=new();
        List<Point> points =Points;
        int k=0;
        double t=T;
        double alpha=1/2;

        while (k<max_iter || t>0)
        {
           int i= random.Next(points.Count-1);
           int j= random.Next(points.Count-1);
           List<Point> successeur=PermutPoint(points,i,j);
           double delta=Fitness(points)-Fitness(successeur);
           System.Console.WriteLine("f(n)={0} et f(n')={1}",Fitness(points),Fitness(successeur));
           System.Console.WriteLine("----------------------------------------------------------");
           if (delta>0)
           {
                points=successeur;
           }
           else
           {
            if (random.NextDouble()>Error(delta,t))
            {
                points=successeur;
            }
           }
           t*=alpha;
           k++;
        }
        Points=points;
        System.Console.WriteLine("f(n_final)={0} et t={1}",Fitness(Points),t);
    }

    public void HillClimbing(int max_iter=50){

        Random random=new();
        List<Point> points =Points;
        int k=0;

        while (k<max_iter)
        {
           int i= random.Next(points.Count-1);
           int j= random.Next(points.Count-1);
           List<Point> successeur=PermutPoint(points,i,j);
           double delta=Fitness(points)-Fitness(successeur);
           System.Console.WriteLine("f(n)={0} et f(n')={1}",Fitness(points),Fitness(successeur));
           System.Console.WriteLine("----------------------------------------------------------");
           if (delta>0)
           {
                points=successeur;
                k++;
           }
           else
           {
                k=max_iter;
           }
        }

        Points=points;
        System.Console.WriteLine("f(n_final)={0}",Fitness(Points));
    }

    public override string ToString()
    {
        string str="";
        Points.ForEach(p => str+=p+"->");
        return str;
    }
}