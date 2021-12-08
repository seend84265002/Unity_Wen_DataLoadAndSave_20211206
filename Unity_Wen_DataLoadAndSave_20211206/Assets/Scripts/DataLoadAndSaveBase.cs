using UnityEngine;
namespace Wen
{
    /// <summary>
    /// ��Ʀs����
    /// ���J���
    /// �x�s���
    /// </summary>
    public class DataLoadAndSaveBase : MonoBehaviour
    {
        [Header("�n�x�s�����")]
        public GoldManger goldManger;
        public Transform player;
        #region ��k
        /// <summary>
        /// �x�s���
        /// </summary>
        public virtual void SaveData()
        {

        }
        /// <summary>
        /// ���J���
        /// </summary>
        public virtual void LoadData()
        {

        }
        #endregion
    }

}
