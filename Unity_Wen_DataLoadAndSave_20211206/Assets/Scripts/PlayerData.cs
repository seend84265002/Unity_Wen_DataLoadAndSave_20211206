using UnityEngine;
namespace Wen
{
    /// <summary>
    /// ���a�����JSON���
    /// </summary>
    public class PlayerData : MonoBehaviour
    {
        public int coin;
        public float posX;
        public float posY;
        //�غc�l:�L�Ǧ^�åB�W�ٻP���O�@�˪���k
        //�|�b�����O��������ɰ���@���A�B�z��l��
        /// <summary>
        /// �إߪ��a��ƨýᤩ��
        /// </summary>
        /// <param name="coin">����</param>
        /// <param name="posX">�y��X</param>
        /// <param name="posY">�y��Y</param>
        public PlayerData(int coin ,float posX,float posY)
        {
            this.coin = coin;
            this.posX = posX;
            this.posY = posY;

        }
    }

}
