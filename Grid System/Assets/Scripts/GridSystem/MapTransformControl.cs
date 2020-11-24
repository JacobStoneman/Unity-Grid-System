using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridLayout;

public class MapTransformControl
{
	public MapTransformControl(Vector3 cellSize, CellSwizzle swizzle)
	{
		CellSize = cellSize;
		Swizzle = swizzle;
	}
	public Vector3 CellSize { get; set; }
	public CellSwizzle Swizzle { get; set; }

	//TODO: This needs to be implemented
	public Vector3 Position { get; set; } = new Vector3(0, 0, 0);

	public Matrix4x4 GetOrientation()
	{
		switch (Swizzle)
		{
			case CellSwizzle.XYZ:
				return Matrix4x4.TRS(Position, Quaternion.Euler(0,0,0), CellSize);
			case CellSwizzle.XZY:
				//Map.orientation = Tilemap.Orientation.XZ;
				return new Matrix4x4();
			case CellSwizzle.YXZ:
				//Map.orientation = Tilemap.Orientation.YX;
				return new Matrix4x4();
			case CellSwizzle.YZX:
				return Matrix4x4.TRS(Position, Quaternion.Euler(90, 270, 0), CellSize);
				//Map.orientationMatrix = mat;
				return new Matrix4x4();
			case CellSwizzle.ZXY:
				//Map.orientation = Tilemap.Orientation.ZY;
				return new Matrix4x4();
			case CellSwizzle.ZYX:
				//Map.orientation = Tilemap.Orientation.ZY;
				return new Matrix4x4();
			default:
				return new Matrix4x4();
		}
	}
}
