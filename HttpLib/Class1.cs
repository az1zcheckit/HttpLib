using System;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace HttpRequestLibrary
{
    // Указываем COM-видимость библиотеки
    [ComVisible(true)]
    [Guid("01234567-89AB-CDEF-0123-456789ABCDEF")] // Уникальный идентификатор GUID
    [ClassInterface(ClassInterfaceType.None)]
    public class HttpHelper : IHttpHelper
    {
        // Метод для выполнения GET-запроса
        public string SendGetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception ex)
                {
                    return string.Format("Error: {0}", ex.Message);
                }
            }
        }

        // Метод для выполнения POST-запроса
        public string SendPostRequest(string url, string jsonData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(url, content).Result;
                    response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception ex)
                {
                    return string.Format("Error: {0}", ex.Message);
                }
            }
        }
    }

    // Интерфейс для реализации COM-взаимодействия
    [ComVisible(true)]
    [Guid("FEDCBA98-7654-3210-FEDC-BA9876543210")]
    public interface IHttpHelper
    {
        string SendGetRequest(string url);
        string SendPostRequest(string url, string jsonData);
    }
}

