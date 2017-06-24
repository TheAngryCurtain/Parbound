using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
	[SerializeField] private GameObject _blockPrefab;

	private Block[] blocks;
	private int _resolution;
	private float _blockSize;

	public void Init(int resolution, float size)
	{
		_resolution = resolution;
		_blockSize = size / _resolution;
		blocks = new Block[_resolution * _resolution];

		for (int i = 0; i < resolution; i++)
		{
			for (int j = 0; j < resolution; j++)
			{
				blocks[i * resolution + j] = CreateBlock(eBlockType.Grass, j, i);
			}
		}
	}

	private Block CreateBlock(eBlockType type, int x, int y)
	{
		GameObject blockObj = (GameObject)Instantiate(_blockPrefab, this.transform);
		blockObj.name = string.Format("Block[{0},{1}]", x, y);
		blockObj.transform.localPosition = new Vector3(x * _blockSize, (y + 1) * _blockSize);
		blockObj.transform.localScale = Vector3.one * _blockSize;

		Block block = blockObj.GetComponent<Block>();
		if (block != null)
		{
			block.Init(type, x, y);
		}
		else
		{
			Debug.LogErrorFormat("No Block Component found on {0}", blockObj.name);
		}

		return block;
	}
}
