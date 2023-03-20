using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class TargetBehaviour : NetworkBehaviour
{
	private Vector3 targetPos;

	// Milyen objectet és melyik object pozicíójára állítsuk
	[Header("GameObjects")]
	[SerializeField] private GameObject targetObject;
	[SerializeField] private GameObject usingObject;
	[SerializeField] private GameObject targetObject2;
	[SerializeField] private GameObject usingObject2;


	[Header("Network variables")]
	public NetworkVariable<float> posX = new NetworkVariable<float>(0, NetworkVariableReadPermission.Everyone);
	public NetworkVariable<float> posY = new NetworkVariable<float>(0, NetworkVariableReadPermission.Everyone);
	public NetworkVariable<float> posZ = new NetworkVariable<float>(0, NetworkVariableReadPermission.Everyone);


	public void goToTarget()
	{
		usingObject2.transform.position = targetObject2.transform.position;
		targetPos = targetObject2.transform.position;

		targetObject2.SetActive(false);
	}

	public void SetCoordinates()
	{
		JSONReader.Instance.LoadData();

		posX.Value = JSONReader.Instance.data.x / 1000;
		posY.Value = JSONReader.Instance.data.y / 1000;
		posZ.Value = JSONReader.Instance.data.z / 1000;

		Debug.Log("X: " + posX.Value + " Y: " + posY.Value + " Z: " + posZ.Value);
	}

	public void TestMoving()
	{
		usingObject2.transform.position = new Vector3(targetPos.x + posX.Value, targetPos.y + posY.Value, targetPos.z + posZ.Value);
		Debug.Log("Position" + usingObject2.transform.position);
	}


}
