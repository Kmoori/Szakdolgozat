using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateData
{
    public float x;
    public float y;
    public float z;

    public CoordinateData(float x, float y, float z)
	{
        this.x = x;
        this.y = y;
        this.z = z;
	}

	public override string ToString()
	{
		return $"Coordinates = X: {x}, Y: {y}, Z: {z}";
	}
}
