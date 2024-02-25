using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Pool;
using UniRx;

public class EnemySpawnPresenter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    private ObjectPool<GameObject> m_objectPool; // オブジェクトプール

    void Start()
    {
        // オブジェクトプールを作成します
        m_objectPool = new ObjectPool<GameObject>
        (
            createFunc: CreateProjectile,         // プールにオブジェクトが不足している時にオブジェクトを生成するために呼び出されます
            actionOnGet: OnTakeFromPool,          // プールからオブジェクトを取得する時に呼び出されます
            actionOnRelease: OnReturnedToPool,    // プールにオブジェクトを戻す時に呼び出されます
            actionOnDestroy: OnDestroyPoolObject, // プールの最大サイズを超えたオブジェクトを削除する時に呼び出されます
            collectionCheck: true,                // すでにプールに戻されているオブジェクトをプールに戻そうとした時にエラーを出すなら true
            defaultCapacity: 10,                  // 内部でプールを管理する Stack のデフォルトのキャパシティ
            maxSize: 10                           // プールするオブジェクトの最大数。最大数を超えたオブジェクトに対しては actionOnRelease ではなく actionOnDestroy が呼ばれます
        );

        GameManager.I.Phase
            .Where(p => p == GamePhase.InGame)
            .Subscribe(_ => {
                Fire().Forget();
            })
            .AddTo(this);
    }

    // プールにオブジェクトが不足している時にオブジェクトを生成するために呼び出されます
    private GameObject CreateProjectile()
    {
        return Instantiate(projectilePrefab);
    }

    // プールからオブジェクトを取得する時に呼び出されます
    private void OnTakeFromPool(GameObject pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    // プールにオブジェクトを戻す時に呼び出されます
    private void OnReturnedToPool(GameObject pooledObject)
    {
        // プールに戻すオブジェクトは非アクティブにします
        pooledObject.gameObject.SetActive(false);
    }

    // プールの最大サイズを超えたオブジェクトを削除する時に呼び出されます
    private void OnDestroyPoolObject(GameObject pooledObject)
    {
        // 最大サイズを超えたオブジェクトはプールに戻さずに削除します
        Destroy(pooledObject.gameObject);
    }

    private async UniTaskVoid Fire()
    {
        while (true)
        {

            int rnd = Random.Range(0, 2);
            if (rnd == 1)
            {
                Debug.Log("fire");
                GameObject enemyObject = m_objectPool.Get();
                if (enemyObject == null) return;


                //右から出るか、左から出るか
                int rnd2 = Random.Range(0, 2);
                if (rnd2 == 1)
                {
                    Vector3 leftPos = new Vector3(
                        -9,
                        Random.Range(0, 4f),
                        0
                    );
                    enemyObject.transform.position = leftPos;
                }
                else
                {
                    enemyObject.GetComponent<EnemyPresenter>().GoLeft();
                    //enemyObject.transform.position = spawnPositionRigtht;
                    Vector3 rightPos = new Vector3(
                         9,
                         Random.Range(0, 4f),
                         0
                     );
                    enemyObject.transform.position = rightPos;
                }
                   

                // プールから取得したオブジェクトを 10 秒後にプールに戻すコルーチン
                IEnumerator Process()
                {
                    yield return new WaitForSeconds(10);
                    enemyObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                    m_objectPool.Release(enemyObject);
                }

                StartCoroutine(Process());
            }

            await UniTask.Delay(1000);
        }
    }
}
