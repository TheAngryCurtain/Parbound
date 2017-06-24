using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshData
{
	private const float textureUnit = 0.25f; // sample texture has 4 x 4 tiles, so 1/4

	public float x;
	public float y;
	public float z = 0;

	public Vector3[] vertices;
	public int[] triangles;
	public Vector2[] uvs;

	public MeshData(float _x, float _y, Vector2 uv)
	{
		x = _x;
		y = _y;

		vertices = new Vector3[4];
		triangles = new int[6];
		uvs = new Vector2[4];

		vertices[0] = new Vector3(x, y, z);
		vertices[1] = new Vector3(x + 1, y, z);
		vertices[2] = new Vector3(x + 1, y - 1, z);
		vertices[3] = new Vector3(x, y - 1, z);

		triangles[0] = 0;
		triangles[1] = 1;
		triangles[2] = 3;
		triangles[3] = 1;
		triangles[4] = 2;
		triangles[5] = 3;

		uvs[0] = new Vector2 (textureUnit * uv.x, textureUnit * uv.y + textureUnit);
		uvs[1] = new Vector2 (textureUnit * uv.x + textureUnit, textureUnit * uv.y + textureUnit);
		uvs[2] = new Vector2 (textureUnit * uv.x + textureUnit, textureUnit * uv.y);
		uvs[3] = new Vector2 (textureUnit * uv.x, textureUnit * uv.y);
	}
}
