
public abstract class GameObject
{
    protected int _x;
    protected int _y;
    protected int _width;
    protected int _height;
    protected bool _showObject = true;
    protected string _gameObjectType;
    protected int _value;
    protected int _yVelocity;

    public GameObject(int x, int y, int width, int height, string type, int value)
    {
        _x = x;
        _y = y;
        _width = width;
        _height = height;
        _gameObjectType = type;
        _value = value;
    }

    public virtual int GetLeftEdge()
    {
        return _x;
    }

    public virtual int GetRightEdge()
    {
        return _x + _width;
    }

    public virtual int GetBottomEdge()
    {
        return _y + _height;
    }

    public virtual int GetTopEdge()
    {
        return _y;
    }
    
    public void ToggleShow()
    {
        _showObject = !_showObject;
    }

    public void SetNewPosition(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public void SetSpeed(int speed)
    {
        _yVelocity = speed;
    }

    public void SetValue(int value)
    {
        _value = value;
    }

    public string GetGameObjectType()
    {
        return _gameObjectType;
    }

    public int GetY()
    {
        return _y;
    }

    public int GetX()
    {
        return _x;
    }
    
    public int GetValue()
    {
        return _value;
    }

    public abstract void Draw();
}