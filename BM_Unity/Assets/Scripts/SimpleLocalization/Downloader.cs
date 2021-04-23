using System;
using System.Collections;
using UnityEngine;

namespace Assets.SimpleLocalization
{
    /// <summary>
    /// HTTP downloader with WWW utility (creates instance automatically)
    /// </summary>
    [ExecuteInEditMode]
    public class Downloader : MonoBehaviour
    {
        public static event Action OnNetworkReady = () => { }; 

        private static Downloader _instance;

	    public static Downloader Instance
        {
            get { return _instance ?? (_instance = new GameObject("Downloader").AddComponent<Downloader>()); }
        }

        public void OnDestroy()
        {
            _instance = null;
        }
       
#pragma warning disable 618
        public static void Download(string url, Action<WWW> callback)
#pragma warning restore 618
        {
            Debug.LogFormat("downloading {0}", url);
            Instance.StartCoroutine(Coroutine(url, callback));
        }

#pragma warning disable 618
        private static IEnumerator Coroutine(string url, Action<WWW> callback)
#pragma warning restore 618
        {
#pragma warning disable 618
            var www = new WWW(url);
#pragma warning restore 618

            yield return www;

            Debug.LogFormat("downloaded {0}, www.text = {1}, www.error = {2}", url, CleaunupText(www.text), www.error);

            if (www.error == null)
            {
                OnNetworkReady();
            }

            callback(www);
        }

        private static string CleaunupText(string text)
        {
            return text.Replace("\n", " ").Replace("\t", null);
        }
    }
}