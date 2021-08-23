using UnityEngine;

public class AnimationParameter
{
    public bool BoolValue;
    public float FloatValue;
    public Vector3 VectorValue;
    public Transform TransformValue;
    public IMovingController MovingController;

    public AnimationParameter(bool boolValue)
    {
        BoolValue = boolValue;
    }

    public AnimationParameter(float floatValue)
    {
        FloatValue = floatValue;
    }

    public AnimationParameter(Transform transformValue, Vector3 vectorValue)
    {
        TransformValue = transformValue;
        VectorValue = vectorValue;
    }

    public AnimationParameter(bool boolValue, float floatValue, IMovingController movingController)
    {
        BoolValue = boolValue;
        FloatValue = floatValue;
        MovingController = movingController;
    }
}
