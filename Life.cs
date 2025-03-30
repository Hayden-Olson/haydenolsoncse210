using Raylib_cs;

public class Life : FallingObject
{

    public Life(int x, int y, int value, int speed) : base(x, y, speed,"L",value)
    {

    }

    public override void Draw()
    {
        if (_showObject == true)
        {
            Raylib.DrawText(_value.ToString(), _x, _y, 25, Color.Gold);
        }
    }

}