using UnityEngine;
using System.Collections;
//UI使う際に必要↓
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバーを表示するテキスト
	private GameObject gameoverText;
	//スコアを表示するテキスト
	private GameObject scoreText;

	//プレイヤー持ち点
	private int myScore;

	//SmallStar点数
	private int s_star = 1;
	//LargeStar点数
	private int l_star = 5;
	//SmallCloud点数
	private int s_cloud = 10;
	//LargeCloud点数
	private int l_cloud = 25;

	//衝突したタグ名格納の宣言
	private string tagName = "none";

	// Use this for initialization
	void Start () {
		//シーン中のgameoverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		//シーン中のscoreTextオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameOverTextにゲームオーバーを表示
			this.gameoverText.GetComponent<Text>().text = "Game Over";
		}

		//衝突したオブジェクト毎に得点を加算
		switch (this.tagName) {
		case "SmallStarTag":
			this.myScore += this.s_star;
			break;
		case "LargeStarTag":
			this.myScore += this.l_star;
			break;
		case "SmallCloudTag":
			this.myScore += s_cloud;
			break;
		case "LargeCloudTag":
			this.myScore += l_cloud;
			break;
		default:
			break;
		}

		//scoreTextの得点を更新
		this.scoreText.GetComponent<Text>().text = this.myScore.ToString();
		//tagNameの初期化
		this.tagName = "none";
	}

	void OnCollisionEnter(Collision other){
		//衝突したタグ名をtagName変数に格納
		this.tagName = other.gameObject.tag;

	}
}
