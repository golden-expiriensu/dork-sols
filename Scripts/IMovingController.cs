public delegate void AxisInput(float vertical, float horizontal);

public interface IMovingController
{
    void SubscribeOnAxisInput(AxisInput method);
    void ForbidMove();
    void AllowMove();
}
