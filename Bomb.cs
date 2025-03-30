using Raylib_cs;

public class Bomb : FallingObject
{

    public Bomb(int x, int y, int speed) : base(x, y, speed,"B", 0)
    {

    }

    public override void Draw()
    {
        if (_showObject == true)
        {
            Raylib.DrawRectangle(_x, _y, 25, 25, Color.Red);
        }
    }

}