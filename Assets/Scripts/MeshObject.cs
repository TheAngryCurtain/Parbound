using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshObject : MonoBehaviour
{
	private Mesh _mesh;
	private MeshData _mData;
	// private BlockData _bData;

	private void Awake()
	{
		_mesh = GetComponent<MeshFilter>().mesh;
	}

	public void Init(eType type, int x, int y)
	{
		// TODO move this out of here
		Vector2 uv = Vector2.zero;
		switch (type)
		{
		case eType.Grass:
			uv = new Vector2(0, 1);
			break;

		case eType.Stone:
			uv = new Vector2(0, 0);
			break;

		default:
			Debug.LogErrorFormat("Invalid type {0}", type);
			break;
		}

		_mData = new MeshData(x, y, uv);
		_mesh.Clear();
		_mesh.vertices = _mData.vertices;
		_mesh.triangles = _mData.triangles;
		_mesh.uv = _mData.uvs;
		_mesh.RecalculateNormals();
	}
}
