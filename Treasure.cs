using Raylib_cs;

public class Treasure : FallingObject
{

    public Treasure(int x, int y, int value, int speed) : base(x, y, speed,"T",value)
    {

    }

    public override void Draw()
    {
        if (_showObject == true)
        {
            Raylib.DrawText(_value.ToString(), _x, _y, 25, Color.Green);
        }
    }

}