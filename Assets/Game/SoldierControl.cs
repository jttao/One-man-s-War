using UnityEngine;
using System.Collections;

public class SoldierControl : MonoBehaviour {
	//基础信息
	public int mHeath = 100;
	//射击范围
	public float fShootDistance;
	//

	//目标信息
	Transform mTarget;
	//位置信息
	Vector3 mDestPosition;

	Animator mAnimator;

	CharacterController mCharacter;

	// Use this for initialization
	void Start () {
		mAnimator = GetComponent<Animator> ();
		mCharacter = GetComponent<CharacterController> ();
		mAnimator.SetInteger("state",0);
	}
	
	// Update is called once per frame
	void Update () { 

		//目标没有找到，寻找目标
		if (mTarget == null) {
			//原地等待，知道接到通知  
			return;
		}

		Vector3 posi = transform.position;
		posi.y = 0; 
		//没有移动到目的地,移动
		if(Vector3.Distance(posi,mDestPosition)>1){  
			mCharacter.Move((posi-mDestPosition)*Time.deltaTime*10);
			return;
		}

		//发现目标，原地射击 或者 选择合适位子隐藏

		mAnimator.SetInteger("state",2);

		//距离目标射击范围，原地射击

		//没有血量了，死亡

	}

	public void SetTarget(Transform target){
		//设置目标
		this.mTarget = target; 
		//寻找路径
		mDestPosition = this.mTarget.position;
		mDestPosition.z = 0;
		//
		mAnimator.SetInteger("state",1);
	}


}
