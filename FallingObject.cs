using Raylib_cs;

public abstract class FallingObject : GameObject
{

    public FallingObject(int x, int y, int speed, string type, int value) : base(x, y, 25, 25, type, value)
    {
        _yVelocity = speed;
    }

    public void Gravity()
    {
        _y += _yVelocity;
    }

}