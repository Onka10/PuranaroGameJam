using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using System;
using System.Threading;

public class EnemySpawnPresenter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    public SettingObject data;
    private CancellationTokenSource cancellationTokenSource;

    private int spwanInterval;
    float spawnXmin = -9f; // 出現範囲のx座標の最小値
    float spawnXmax = 9f; // 出現範囲のx座標の最大値
    float spawnYmin = 0f; // 出現範囲のy座標の最小値
    float spawnYmax = 4f; // 出現範囲のx座標の最大値

    void Start()
    {
        spwanInterval = data.spawninterval;
        spawnXmin = data.spawnXmin;
        spawnXmax = data.spawnXmax;
        spawnYmin = data.spawnYmin;
        spawnYmax = data.spawnYmax;

        GameManager.I.Phase
            .Subscribe(phase => {
                if (phase == GamePhase.InGame)
                {
                    cancellationTokenSource = new CancellationTokenSource();
                    Fire(cancellationTokenSource.Token);
                }
                else
                {
                    cancellationTokenSource?.Cancel();
                }
            })
            .AddTo(this);
    }

        private async UniTaskVoid Fire(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                //int rnd = UnityEngine.Random.Range(0, 2);
                //if (rnd == 1)
                //{
                    //Debug.Log("fire");
                    GameObject enemyObject = Instantiate(projectilePrefab);

                    // 右から出るか、左から出るか
                    int rnd2 = UnityEngine.Random.Range(0, 2);
                    if (rnd2 == 1)
                    {
                        enemyObject.transform.position = new Vector3(
                            spawnXmin,
                            UnityEngine.Random.Range(spawnYmin, spawnYmax),
                            0
                        );
                    }
                    else
                    {
                        enemyObject.GetComponent<EnemyPresenter>().GoLeft();
                        enemyObject.transform.position = new Vector3(
                             spawnXmax,
                             UnityEngine.Random.Range(spawnYmin, spawnYmax),
                             0
                         );
                    }
                    await UniTask.Delay(TimeSpan.FromSeconds(3));
                    Destroy(enemyObject);
                //}

                await UniTask.Delay(spwanInterval);
            }
        }

    }
