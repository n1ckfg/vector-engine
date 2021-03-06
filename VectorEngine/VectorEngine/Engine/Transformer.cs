﻿using System.Collections;
using Microsoft.Xna.Framework;

public class Transformer
{
    /// <summary>
    /// Produces "view" coordinates (aka "eye" or "camera" coordinates)
    /// Applies the view transform of the given camera (transformCamera.worldToCameraMatrix)
    /// to the homogeonous vertex.
    /// </summary>
    public static Vector4 performViewTransform(Vector4 vertex, Matrix worldToCameraMatrix)
    {
        Vector4 result = Vector4.Transform(vertex, worldToCameraMatrix);
        return result;
    }

    /// <summary>
    /// Produces "clip" coordinates by applying the projection transform.
    /// This result can be transformed into "Normalized Device Coordinates" by performing a homogeneous devide.
    /// </summary>
    public static Vector4 performProjectionTransform(Vector4 vertex, Matrix projectionMatrix)
    {
        Vector4 result = Vector4.Transform(vertex, projectionMatrix);
        return result;
    }

    public static bool clip(Vector4 vertex)
    {
        bool result = !(-vertex.W <= vertex.X && vertex.X <= vertex.W
                        && -vertex.W <= vertex.Y && vertex.Y <= vertex.W
                        && -vertex.W <= vertex.Z && vertex.Z <= vertex.W);
        return result;
    }

    /// <summary>
    /// Performs a homogeneous divide and discards z to get the final screen space coordinates
    /// </summary>
    public static Vector2 performViewportTransform(Vector4 vertex)
    {
        Vector2 viewportSpace = new Vector2(vertex.X / vertex.W, vertex.Y / vertex.W);
        
        //viewportSpace.X = (viewportSpace.X + 1) * 0.5f; // I think this is unnecessary because my screen space centers on zero 
        //viewportSpace.Y = (viewportSpace.Y + 1) * 0.5f;

        return viewportSpace;
    }
}
