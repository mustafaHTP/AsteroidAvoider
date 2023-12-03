using UnityEngine;

public static class CameraExtensions
{
    public static Border GetBorder(this Camera camera)
    {
        Vector2 bottomLeft = camera.ViewportToWorldPoint(new Vector2(0f, 0f));
        Vector2 topRight = camera.ViewportToWorldPoint(new Vector2(1f, 1f));

        Border border = new(bottomLeft.x, topRight.x, topRight.y, bottomLeft.y);
        return border;
    }
}
