using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

	public static SceneController Instance { get; private set; }


	[Header("Objects")]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject arCamera;

    void Awake()
    {
		Instance = this;
	}

	public void Cameras()
	{
		Destroy(arCamera);
		Instantiate(mainCamera);
	}


}
