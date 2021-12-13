using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace Wen
{
    /// <summary>
    /// �z�L��Ʈw�s�����
    /// ��Ƴz�LJSON
    /// </summary>
    public class DataDBWithJSON : DataLoadAndSaveBase
    {
        private string urlSave = "https://wen-1101208.000webhostapp.com/savejson.php";
        private string urlLoad = "https://wen-1101208.000webhostapp.com/Loadjson.php";
        private WWWForm form;
        /// <summary>
        /// �ǿ鵲�G
        /// </summary>
        private string result;
        public override void SaveData()
        {

            base.SaveData();

            //�s�W���a��ƨ��x�s�����P�y��
            PlayerData data = new PlayerData(goldManger.goldCount, player.position.x, player.position.y,
                                player.rotation,Time.timeSinceLevelLoad);
            //JSON �r��(JSON�x�s����쳣�O�r��) = JSON ���.�� JSON(���a���)
            string dataJSON = JsonUtility.ToJson(data);
            print("JSON ���:<color=yellow>" + dataJSON + "</color>");

            //�NJSON ��ƲK�[�� ������W�٬� [JSON]
            form = new WWWForm();
            form.AddField("json", dataJSON);
            StartCoroutine(StartLinkData(urlSave));
        }
        public override void LoadData()
        {
            base.LoadData();

            form = new WWWForm();
            form.AddField("json", "json");
            StartCoroutine(StartLinkData(urlLoad, true));
        }
        /// <summary>
        /// �}�l�ϥθ�Ʈw
        /// </summary>
        /// <param name="url">�n���q��PHP�s��</param>
        /// <param name="load">�O�_�����J�Ҧ�</param>
        /// <returns></returns>
        private IEnumerator StartLinkData(string url,bool load=false)
        {

            using (UnityWebRequest www = UnityWebRequest.Post(url, form))    //�z�L�����ǿ�ǻ���ƨ� Save.php
            {
                yield return www.SendWebRequest();      //���ݶǿ�  
                print("�ǿ骬�A: " + www.isDone);
                result = www.downloadHandler.text;      //�ǿ鵲�G
                print("�ǿ鵲�G: " + result);

            }
            if (load)
            {
                //�NJSON �ର���a���
                //JSON ��� . �qJSON ����<���O>(JSON)
                PlayerData data = JsonUtility.FromJson<PlayerData>(result);
                print("���o������ : <color=yellow>" + data.coin + "</color>");

                goldManger.goldCount = data.coin;
                goldManger.UpdataData();

                float x = data.posX;
                float y = data.posY;
                player.position = new Vector3(x, y, 0);
                player.rotation = data.angle;

                print("�W���C���ɶ� : <color=red>" + data.time + "</color>");

            }
        }
    }
}

