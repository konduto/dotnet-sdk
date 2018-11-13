﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using KdtSdk.Models;
using KdtSdk.Exceptions;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace KdtSdk
{
    /// <summary>
    /// Konduto is an HTTP Client for connecting to Konduto's API.
    /// </summary>
    public class Konduto
    {
        public const String VERSION = "1.0.9";

        private String apiKey;
        private String requestBody;
        private String responseBody;
        private Uri endpoint;

        public HttpMessageHandler __MessageHandler = null;

        private bool useProxy = false;
        private String proxyAddress;
        private String proxyUsername;
        private String proxyPassword;

        public Konduto(String apiKey)
        {
            SetApiKey(apiKey);
            endpoint = new Uri("https://api.konduto.com/v1/");
        }

        /// <summary>
        /// Konduto's API endpoint (default is https://api.konduto.com/v1/)
        /// </summary>
        /// <param name="endpoint"></param>
        public void SetEndpoint(Uri endpoint)
        {
            this.endpoint = endpoint;
        }

        /// <summary>
        /// sets the merchant secret API key, which is required for Konduto's API authentication.
        /// </summary>
        /// <param name="apiKey"></param>
        public void SetApiKey(String apiKey)
        {
            if (apiKey == null || apiKey.Length != 21)
            {
                throw new ArgumentOutOfRangeException("Illegal API Key: " + apiKey);
            }
            this.apiKey = apiKey;
        }

        /// <summary>
        /// Helper method to debug requests made to Konduto's API.
        /// </summary>
        /// <returns>a String containing API Key, Konduto's API endpoint, request and response bodies.</returns>
        public String Debug()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("API Key: {0}\n", this.apiKey));
            sb.Append(String.Format("Endpoint: {0}\n", this.endpoint.ToString()));
            if (this.requestBody != null)
            {
                sb.Append(String.Format("Request body: {0}\n", this.requestBody));
            }
            if (this.responseBody != null)
            {
                sb.Append(String.Format("Response body: {0}\n", this.responseBody));
            }
            return sb.ToString();
        }

        /// <summary>
        /// </summary>
        /// <param name="orderId">the order identifier</param>
        /// <returns>[GET] order URI (ENDPOINT/orders/orderId)</returns>
        public Uri KondutoGetOrderUrl(String orderId)
        {
            return new Uri(endpoint.ToString() + KondutoGetOrderSuffix(orderId));
        }

        /// <summary>
        /// </summary>
        /// <param name="orderId">the order identifier</param>
        /// <returns>/orders/orderId</returns>
        public String KondutoGetOrderSuffix(String orderId)
        {
            return "orders/" + orderId;
        }

        /// <summary>
        /// [POST] order URI (ENDPOINT/orders)
        /// </summary>
        /// <returns></returns>
        public Uri KondutoPostOrderUrl()
        {
            return new Uri(endpoint.ToString() + KondutoPostOrderUrlSuffix());
        }

        /// <summary>
        /// [POST] order suffix (/orders)
        /// </summary>
        /// <returns></returns>
        public String KondutoPostOrderUrlSuffix()
        {
            return "orders";
        }

        /// <summary>
        /// </summary>
        /// <param name="orderId">the order identifier</param>
        /// <returns>[PUT] order URI (ENDPOINT/orders/orderId)</returns>
        public Uri KondutoPutOrderUrl(String orderId)
        {
            return new Uri(endpoint.ToString() + KondutoPutOrderUrlSuffix(orderId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>/orders/orderId</returns>
        public String KondutoPutOrderUrlSuffix(String orderId)
        {
            return "orders/" + orderId;
        }

        /// <summary>
        /// Set proxy address, send only the address with http://ip, even for https connections
        /// </summary>
        /// <param name="proxyAddress">Proxy address, even for https connections, use http</param>
        public void SetProxy(String proxyAddress, String proxyUser, String proxyPassword)
        {
            this.proxyUsername = proxyUser;
            this.proxyPassword = proxyPassword;
            this.proxyAddress = proxyAddress;
            this.useProxy = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private HttpClient CreateHttpClient()
        {
            var base64 = Base64Encode(apiKey);
            
            var httpClient = __MessageHandler == null ? new HttpClient() : new HttpClient(__MessageHandler);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + base64);
            httpClient.DefaultRequestHeaders.Add("X-Requested-With", "Konduto SDK .NET " + VERSION);
            httpClient.BaseAddress = this.endpoint;

            return httpClient;
        }

        /// <summary>
        /// Queries an order from Konduto's API.
        /// Syncronous
        /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
        /// </summary>
        /// <param name="orderId">the order identifier</param>
        /// <returns>a {@link KondutoOrder} instance</returns>
        /// <exception cref="KondutoHTTPException"></exception>
        /// <exception cref="KondutoUnexpectedAPIResponseException"></exception>
        public async Task<KondutoOrder> GetOrderAsync(String orderId)
        {
            var client = CreateHttpClient();
            requestBody = orderId;

            var response = await client.GetAsync(KondutoGetOrderSuffix(orderId));
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                var responseString = await responseContent.ReadAsStringAsync();
                responseBody = responseString;
                var getResponse = JsonConvert.DeserializeObject<JObject>(responseString);

                KondutoOrder order = null;
                JToken jt;
                if (getResponse.TryGetValue("order", out jt))
                {
                    order = KondutoModel.FromJson<KondutoOrder>(jt.ToString());
                }
                return order;
            }
            throw KondutoHTTPExceptionFactory.buildException(
                (int)response.StatusCode, 
                await response.Content.ReadAsStringAsync()
                );
        }

        /// <summary>
        /// Queries an order from Konduto's API.
        /// Syncronous
        /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
        /// </summary>
        /// <param name="orderId">the order identifier</param>
        /// <returns>a {@link KondutoOrder} instance</returns>
        /// <exception cref="KondutoHTTPException"></exception>
        /// <exception cref="KondutoUnexpectedAPIResponseException"></exception>
        public KondutoOrder GetOrder(String orderId)
        {
            try
            {
                return GetOrderAsync(orderId).Result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException;
            }
        }

        /// <summary>
        /// Sends an order for Konduto and gets it analyzed
        /// (i.e with recommendation, score, device, geolocation and navigation info).
        /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
        /// </summary>
        /// <param name="order">a {@link KondutoOrder} instance</param>
        /// <exception cref="KondutoInvalidEntityException"></exception>
        /// <exception cref="KondutoHTTPException"></exception>
        /// <exception cref="KondutoUnexpectedAPIResponseException"></exception>
        public async Task<KondutoOrder> AnalyzeAsync(KondutoOrder order)
        {
            var httpClient = CreateHttpClient();
            var response = await httpClient.PostAsync(KondutoPostOrderUrl(),
                new StringContent(order.ToJson(),
                    Encoding.UTF8,
                    "application/json"));

            requestBody = order.ToJson();
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                var responseString = await responseContent.ReadAsStringAsync();

                responseBody = responseString;
                if (order.Analyze)
                    order.MergeKondutoOrderResponse(
                        KondutoAPIFullResponse.FromJson<KondutoAPIFullResponse>(responseString).Order
                        );
                return order;
            }
            else
            {
                var responseContentError = response.Content != null ? 
                    await response.Content.ReadAsStringAsync() : 
                    "Error with response";
                throw KondutoHTTPExceptionFactory.buildException(
                    (int)response.StatusCode, responseContentError);
            }
        }

        /// <summary>
        /// Sends an order for Konduto and gets it analyzed
        /// (i.e with recommendation, score, device, geolocation and navigation info).
        /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
        /// </summary>
        /// <param name="order">a {@link KondutoOrder} instance</param>
        /// <exception cref="KondutoInvalidEntityException"></exception>
        /// <exception cref="KondutoHTTPException"></exception>
        /// <exception cref="KondutoUnexpectedAPIResponseException"></exception>
        public KondutoOrder Analyze(KondutoOrder order)
        {
            try
            {
                return AnalyzeAsync(order).Result;
            }
            catch (AggregateException ae)
            {     
                throw ae.InnerException;
            }
        }

        private class KondutoAPIFullResponse : KondutoModel
        {
            [JsonProperty("status")]
            public string Status { get; set; }
            [JsonProperty("order")]
            public KondutoOrderResponse Order { get; set; }
        }

        /// <summary>
        /// Updates an order status.
        /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
        /// </summary>
        /// <param name="order">the order to update</param>
        /// <param name="newStatus">the new status (APPROVED, DECLINED or FRAUD)</param>
        /// <param name="comments">some comments (an empty String is accepted, although we recommend setting it to at least a timestamp)</param>
        /// <exception cref="KondutoHTTPException"></exception>
        /// <exception cref="KondutoUnexpectedAPIResponseException"></exception>
        public async Task UpdateOrderStatusAsync(string orderId, KondutoOrderStatus newStatus, string comments)
        {
            HashSet<KondutoOrderStatus> allowed = new HashSet<KondutoOrderStatus>
            {
                KondutoOrderStatus.approved,
                KondutoOrderStatus.declined,
                KondutoOrderStatus.fraud,
                KondutoOrderStatus.canceled,
                KondutoOrderStatus.not_authorized
            };

            if (!allowed.Contains(newStatus)) { throw new ArgumentException("Illegal status: " + newStatus); }
            if (comments == null) { throw new NullReferenceException("Comments cannot be null."); }

            JObject requestBody = new JObject();
            requestBody.Add("status", newStatus.ToString().ToLower());
            requestBody.Add("comments", comments);

            var client = CreateHttpClient();
            var response = await client.PutAsync(KondutoPutOrderUrl(orderId),
                new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var responseBody = JsonConvert.DeserializeObject<JObject>(
                    await response.Content.ReadAsStringAsync());

                this.responseBody = responseBody.ToString();

                JToken orderUpdateResponse;
                if (responseBody.TryGetValue("order", out orderUpdateResponse))
                {
                    var updatedOrder = JsonConvert.DeserializeObject<JObject>(orderUpdateResponse.ToString());
                    JToken statusResponse;
                    if (!updatedOrder.TryGetValue("old_status", out statusResponse) ||
                        !updatedOrder.TryGetValue("new_status", out statusResponse))
                    {
                        throw new KondutoUnexpectedAPIResponseException(responseBody.ToString());
                    }
                }
            }
            else
            {
                throw KondutoHTTPExceptionFactory.buildException(
                   (int)response.StatusCode,
                   await response.Content.ReadAsStringAsync());   
            }
        }

        /// <summary>
        /// Updates an order status.
        /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
        /// </summary>
        /// <param name="order">the order to update</param>
        /// <param name="newStatus">the new status (APPROVED, DECLINED or FRAUD)</param>
        /// <param name="comments">some comments (an empty String is accepted, although we recommend setting it to at least a timestamp)</param>
        /// <exception cref="KondutoHTTPException"></exception>
        /// <exception cref="KondutoUnexpectedAPIResponseException"></exception>
        public void UpdateOrderStatus(string orderId, KondutoOrderStatus newStatus, string comments)
        {
            try
            {
                UpdateOrderStatusAsync(orderId, newStatus, comments).Wait();
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException;
            }
            
        }

        /// <summary>
        /// Base64 Encode
        /// </summary>
        /// <param name="plainText">Text to encode</param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Base64 Decode
        /// </summary>
        /// <param name="base64EncodedData">Text to decode</param>
        /// <returns></returns>
        public static string Base64Decode(string base64EncodedData)
        {
            byte[] base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}