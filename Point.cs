
class Point
{
    public double X{get;set;} 
    public double Y{get;set;}

    public Point(){
        X=0.0f;
        Y=0.0f;
    }
    

    public Point(double x, double y){
        X=x;
        Y=y;
    }

    public static Point operator +(Point p1, Point p2){

        return new Point() { X = p1.X + p2.X,Y = p1.Y + p2.Y };
    }


    public static Point operator-(Point p1, Point p2){

        return new Point() { X = p1.X-p2.X,Y=p1.Y-p2.Y };
    }

    public static Point operator*(Point p1,Point p2){

        return new Point() { X = p1.X*p2.X,Y = p1.Y*p2.Y} ;
    }

    public double Distance(Point p1){
        return Math.Sqrt((p1.X-X)*(p1.X-X) + (p1.Y-Y)*(p1.Y-Y));
    }

    public override string ToString() {
        return string.Format("({0},{1})", X,Y);
    }
}