using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/マスターデータ", order = 1)]
public class SettingObject : ScriptableObject
{
    //プレイヤー
    //playercore
    public int maxHealth = 100;//満腹最大値
    public float haraheri = 10f;//エネルギー処理速度
    //playerfire
    public float PlayerForceMagnitude = 13f; // 火を飛ばす力
    //playermove
    public float playerSpeed = 5f;//プレイヤーの移動速度
    public float invincibleTime = 2f; //無敵時間

    //敵
    //enemypresenter
    public float enemySpeed = 5f;// 敵の移動速度
    //attack
    public float enemyForceMagnitude = 5f; // 攻撃を飛ばす力
    public int attackinterval = 2; //攻撃の頻度(秒)
    //fire
    //public int enemyAtk = 10;//敵の攻撃力
    //spwanpreseenter
    public int spawninterval = 1000; //出現の頻度(ミリ秒)
    public float spawnXmin = -9f; // 出現範囲のx座標地点
    public float spawnXmax = 9f; // 出現範囲のx座標地点
    public float spawnYmin = 0f; // 出現範囲のy座標の最小値
    public float spawnYmax = 4f; // 出現範囲のx座標の最大値

    //肉
    //meatPresenter
    public float meatSpeed = 5f; // 肉の移動速度
}
