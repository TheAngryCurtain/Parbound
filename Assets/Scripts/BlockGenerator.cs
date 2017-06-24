using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eType { Stone, Grass };

public class BlockGenerator : MonoBehaviour
{
	[SerializeField] private GameObject _meshObjPrefab;

	private void Start()
	{
		CreateBlock(eType.Grass, 0, 0);
	}

	private void CreateBlock(eType type, int x, int y)
	{
		GameObject meshObj = (GameObject)Instantiate(_meshObjPrefab, new Vector2(x, y), Quaternion.identity);
		meshObj.name = string.Format("MeshObject[{0},{1}]", x, y);

		MeshObject mObj = meshObj.GetComponent<MeshObject>();
		if (mObj != null)
		{
			mObj.Init(type, x, y);
		}
		else
		{
			Debug.LogErrorFormat("No MeshObject Component found on {0}", meshObj.name);
		}
	}
}
