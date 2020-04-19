using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	[SerializeField]
	GameObject m_Object;

	private void Awake()
	{
		DontDestroyOnLoad(m_Object);
	}
}
