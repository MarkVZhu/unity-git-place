using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//一个隐藏的物体等待t秒后显示，updata计时器实现
public class StoryDisplay : MonoBehaviour
{

	public GameObject image;
	public int tshow=3;//展示等待时间
	public int thide = 8;//隐藏等待时间

	// Use this for initialization
	void Start()
	{
		image.SetActive(false);
		Invoke("ActiveShow", tshow);
		Invoke("HideShow", thide);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ActiveShow()
	{
		image.SetActive(true);
	}

	public void HideShow()
	{
		image.SetActive(false);
	}
}
