using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {

	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngel = 20;
	//弾いた時の傾き
	private float flickAngel = -20;

	//画面幅の境界線座標の取得
	private int winBorder = Screen.width / 2;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネントを取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngel(this.defaultAngel);
	
	}
	
	// Update is called once per frame
	void Update () {

		//矢印キー左を押した時左フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngel (this.flickAngel);
		}
		//矢印キー右を押した時右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngel (this.flickAngel);
		}

		//矢印キー左を離した左フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngel (this.defaultAngel);
		}
		//矢印キー右を離した時右フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngel (this.defaultAngel);
		}

		//（発展課題）タップ判定処理
		foreach (Touch touch in Input.touches) {
			//タップされた位置と境界線との比較
			if (touch.position.x < this.winBorder) {
				//画面左側をタップされた時
				if (touch.phase == TouchPhase.Began && tag == "LeftFripperTag") {
					SetAngel (this.flickAngel);
				}
				//
				if (touch.phase == TouchPhase.Ended && (tag == "LeftFripperTag" || tag == "RightFripperTag")) {
					SetAngel (this.defaultAngel);
				}
					
			}else if (touch.position.x > this.winBorder) {
				//画面右側をタップされた時
				if (touch.phase == TouchPhase.Began && tag == "RightFripperTag") {
					SetAngel (this.flickAngel);
				}
				if (touch.phase == TouchPhase.Ended && (tag == "RightFripperTag" || tag == "LeftFripperTag")) {
					SetAngel (this.defaultAngel);
				}
			}	
		}
	}

	//フリッパーの傾きを設定
	public void SetAngel(float angel){
		JointSpring jointspr = this.myHingeJoint.spring;
		jointspr.targetPosition = angel;
		this.myHingeJoint.spring = jointspr;
	}

}
