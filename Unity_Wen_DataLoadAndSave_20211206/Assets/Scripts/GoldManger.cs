using UnityEngine;
using UnityEngine.UI;

namespace Wen
{
    /// <summary>
    /// �Ī��q�޲z��
    /// </summary>
    public class GoldManger : MonoBehaviour
    {
        #region ���
        [Header("���q�b�|"), Range(0, 10)]
        public float radius = 3.5f;
        [Header("���q����")]
        public KeyCode keyGold = KeyCode.E;
        [Header("�ؼйϼh")]
        public LayerMask layerTraget;
        [Header("�����ƶq")]
        public Text textCoin;
        [HideInInspector]
        public int goldCount;
        #endregion

        #region �ݩ�
        /// <summary>
        /// ���U���q���s
        /// </summary>
        private bool inputGold { get => Input.GetKeyDown(keyGold); }
        /// <summary>
        /// �ؼЬO�_���b�b�|��
        /// </summary>
        public bool targetInRadius { get => Physics2D.OverlapCircle(transform.position, radius, layerTraget); }
        #endregion
        #region �ƥ�
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.8f, 0.7f, 0.3f, 0.35f);
            Gizmos.DrawSphere(transform.position, radius);

        }
        private void Update()
        {
            GetGold();
        }
        #endregion
        #region ��k �p�H
        /// <summary>
        /// ���q
        /// </summary>
        private void GetGold()
        {
            if (inputGold && targetInRadius) goldCount++;
            textCoin.text = "�����ƶq:" + goldCount;
        }
        #endregion

        public void UpdataData()
        {
            textCoin.text = "�����ƶq:" + goldCount;
        }
    }

}
