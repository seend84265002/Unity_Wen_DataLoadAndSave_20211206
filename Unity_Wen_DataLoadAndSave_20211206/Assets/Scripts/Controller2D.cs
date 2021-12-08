using UnityEngine;
namespace Wen
{
    /// <summary>
    /// �ϥ�GAS�s�����
    /// Google AppLication Script
    /// </summary>
    public class Controller2D : MonoBehaviour
    {
        #region ���G���}
        [Header("���ʳt��"), Range(0, 10)]
        public float speed = 3.5f;
        [Header("�ʵe�Ѽ�")]
        public string parameterRun = "�]�B�}��";
        #endregion

        #region ���G�p�H
        private Rigidbody2D rig;
        private Animator ani;
        #endregion

        #region �ݩʡG�p�H
        /// <summary>
        /// ������J��
        /// </summary>
        private float inputHorizontal { get => Input.GetAxis("Horizontal"); }
        #endregion

        #region �ƥ�
        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Update()
        {
            Flip();
            UpdateAnimation();
        }
        #endregion

        #region ��k�G�p�H
        /// <summary>
        /// ����
        /// </summary>
        private void Move()
        {
            rig.velocity = new Vector2(speed * inputHorizontal, rig.velocity.y);
        }

        /// <summary>
        /// ��s�ʵe
        /// </summary>
        private void UpdateAnimation()
        {
            ani.SetBool(parameterRun, inputHorizontal != 0);
        }

        /// <summary>
        /// ½��
        /// </summary>
        private void Flip()
        {
            if (Mathf.Abs(inputHorizontal) < 0.1f) return;      // �����ȵ���� < 0.1 ���B�z
            float yAngle = inputHorizontal > 0 ? 0 : 180;       // ������ > 0 ���� 0 �_�h 180
            transform.eulerAngles = new Vector3(0, yAngle, 0);  // ��s�کԨ���
        }
        #endregion
    }

}
