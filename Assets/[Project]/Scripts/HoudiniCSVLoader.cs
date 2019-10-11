using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HoudiniCSVLoader : MonoBehaviour
{

	[SerializeField] private GameObject m_blockPrefab;
	[SerializeField] private GameObject m_woodPrefab;

	/// <summary>
	/// 指定されたパスにあるcsvを読みこんで返す処理
	/// </summary>
	/// <param name="filePath"></param>
	/// <returns></returns>
	public static List<string[]> CSVLoading(string filePath)
	{
		List<string[]> csvDatas = new List<string[]>();

		TextAsset csvFile = Resources.Load(filePath) as TextAsset;
		StringReader reader = new StringReader(csvFile.text);

		while (reader.Peek() != -1)
		{
			string line = reader.ReadLine();
			csvDatas.Add(line.Split(','));
		}
		return csvDatas;
	}

	/// <summary>
	/// スタート処理
	/// </summary>
	private void Start()
	{
		var csvData = CSVLoading("Area1");

		//冒頭にあるデータは無視

		for (int i = 3; i < csvData.Count; i++)
		{
			string[] data = csvData[i];

			//必要なトランスフォーム情報に変換
			string tag = data[0];
			Quaternion quaternion = new Quaternion(float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]), float.Parse(data[4]));
			Vector3 position = new Vector3(-float.Parse(data[7]), float.Parse(data[6]),-float.Parse(data[5]));
			float pscale = float.Parse(data[8]);

			GameObject gameObj;
			switch (tag)
			{
				case "Block":
					gameObj = GameObject.Instantiate(m_blockPrefab, position, quaternion);
					break;
				case "Woods":
					gameObj = GameObject.Instantiate(m_woodPrefab, position, quaternion);
					break;
				default:
					gameObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
					gameObj.transform.position = position;
					gameObj.transform.rotation = quaternion;
					break;
			}
			gameObj.transform.localScale = Vector3.one * pscale*10;
		}
	}
}
