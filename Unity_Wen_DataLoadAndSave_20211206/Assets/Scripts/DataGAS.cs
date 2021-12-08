using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

namespace Wen
{
    /// <summary>
    /// �ϥ�GAS�s�����
    /// Google AppLication Script
    /// </summary>
    public class DataGAS : DataLoadAndSaveBase
    {
        /// <summary>
        /// GAS�s��
        /// </summary>
        private string gas = "https://script.google.com/macros/s/AKfycbzwokUKlsehtNIWvUwqpovv3124o-Khxaf4VhqQCWHoYjnUP2Hk4psWI1bss4x_77QL/exec";
        private WWWForm form;
        private string result;
        public override void SaveData()
        {
            base.SaveData();
            #region �x�s���
            form = new WWWForm();
            form.AddField("coin", goldManger.goldCount);
            form.AddField("posX", player.position.x.ToString());
            form.AddField("posY", player.position.y.ToString());
            
            StartCoroutine(LinKGAS("�g�J"));
            #endregion
        }
        public override void LoadData()
        {
            base.LoadData();
            #region Ū�����
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 1);
            StartCoroutine(LoadGASData("����"));
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 2);
            StartCoroutine(LoadGASData("�y��X"));
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 3);
            StartCoroutine(LoadGASData("�y��Y"));
            #endregion
        }

        private IEnumerator LoadGASData(string updata)
        {
            yield return StartCoroutine(LinKGAS("Ū��"));
            #region
            if(updata == "����")
            {
                goldManger.goldCount = Convert.ToInt32(result);
                goldManger.UpdataData();
            }else if(updata == "�y��X")
            {
                float x = Convert.ToSingle(result);
                player.position = new Vector3(x, player.position.y, 0);
            }
            else if (updata == "�y��Y")
            {
                float y = Convert.ToSingle(result);
                player.position = new Vector3(player.position.x, y, 0);
            }

            #endregion
        }

        /// <summary>
        /// �s���� GAS
        /// </summary>
        /// <param name="loadOrSave">�g�J Ū��</param>
        /// <returns></returns>
        private IEnumerator LinKGAS(string loadOrSave)
        {
            
            form.AddField("method", loadOrSave);
            using(UnityWebRequest www = UnityWebRequest.Post(gas, form))
            {
                yield return www.SendWebRequest();
                result = www.downloadHandler.text;
                print(result);
            }
        }

    }

}
