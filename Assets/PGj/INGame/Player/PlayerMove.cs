using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        Rigidbody2D rBody; // リジッドボディを使うための宣言
        Vector2 velo = Vector2.zero;
        float speed = 8;
        public SettingObject data;

        //上0 左1 下2 右3
        //public IReadOnlyReactiveProperty<PlayerLookDirection> Direction => _dire;
        //private readonly ReactiveProperty<PlayerLookDirection> _dire = new ReactiveProperty<PlayerLookDirection>();

        void Start()
        {
            rBody = this.gameObject.GetComponent<Rigidbody2D>();
            speed = data.playerSpeed;
            
        }

        void FixedUpdate()
        {
            if (GameManager.I.Phase.Value != GamePhase.InGame) return;
            rBody.velocity = velo;

            //Clamp
            var pos = transform.position;
            // x軸方向の移動範囲制限
            pos.x = Mathf.Clamp(pos.x, -7.5f, 3.5f);
            // y軸方向の移動範囲制限
            pos.y = Mathf.Clamp(pos.y, -3.8f, 3.8f);
            transform.position = pos;
        }

        private void Update()
        {
            if (GameManager.I.Phase.Value != GamePhase.InGame) return;

            var move = GetInputMove();
            Vector2 moveVector = new Vector2(move.x, move.y);

            if (moveVector != Vector2.zero)
            {
                // 入力方向を正規化して速度を掛ける
                velo = moveVector.normalized * speed;
            }
            else
            {
                velo = Vector2.zero;
            }
        }

        (float x, float y) GetInputMove()
        {
            return (
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );
        }
    }
}
