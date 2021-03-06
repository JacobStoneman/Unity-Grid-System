﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
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
	public Vector3Int Origin { get; set; } = new Vector3Int(0, 0, 0);

	//TODO: This needs to be implemented
	public Vector3 Position { get; set; } = new Vector3(0, 0, 0);

	public Matrix4x4 SetOrientation()
	{
		Quaternion rot = new Quaternion();
		switch (Swizzle)
		{
			case CellSwizzle.XYZ:
				rot = Quaternion.Euler(0, 0, 0);
				break;
			case CellSwizzle.XZY:
				rot = Quaternion.Euler(90, 180, 0);
				break;
			case CellSwizzle.YXZ:
				rot = Quaternion.Euler(0, 0, 90);
				break;
			case CellSwizzle.YZX:
				rot = Quaternion.Euler(90, 270, 0);
				break;
			case CellSwizzle.ZXY:
				rot = Quaternion.Euler(0, 90, 90);
				break;
			case CellSwizzle.ZYX:
				rot = Quaternion.Euler(0, 270, 0);
				break;
			default:
				return new Matrix4x4();
		}
		return Matrix4x4.TRS(Position, rot, CellSize);
	}

	public void SetOrigin(Tilemap map)
	{
		map.CompressBounds();
		Origin = new Vector3Int(map.cellBounds.min.x, map.cellBounds.min.y, map.cellBounds.min.z);
	}
}
