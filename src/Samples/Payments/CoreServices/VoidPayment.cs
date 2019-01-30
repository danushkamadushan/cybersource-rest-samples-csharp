﻿using System;
using CyberSource.Api;
using CyberSource.Model;
using Newtonsoft.Json;
using NLog;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class VoidPayment
    {
        public static void Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(VoidPayment)}");

            ProcessPayment.CaptureTrueForProcessPayment = true;

            Logger logger = LogManager.GetCurrentClassLogger();
            CyberSource.Client.Configuration clientConfig = null;
            PtsV2PaymentsVoidsPost201Response result = null;

            var processPaymentId = ProcessPayment.Run().Id;
            var clientReferenceInformationObj = new Ptsv2paymentsidreversalsClientReferenceInformation("test_payment_void");
            var requestObj = new VoidPaymentRequest(clientReferenceInformationObj);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new VoidApi(clientConfig);

                result = apiInstance.VoidPayment(requestObj, processPaymentId);

            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException on calling the Sample Code({nameof(VoidPayment)}):{e.Message}");
            }
            finally
            {
                if (clientConfig != null)
                {
                    // PRINTING REQUEST DETAILS
                    if (clientConfig.ApiClient.Configuration.RequestHeaders != null)
                    {
                        Console.WriteLine("\nAPI REQUEST HEADERS:");
                        foreach (var requestHeader in clientConfig.ApiClient.Configuration.RequestHeaders)
                        {
                            Console.WriteLine(requestHeader);
                        }
                    }

                    Console.WriteLine("\nAPI REQUEST BODY:");
                    Console.WriteLine(JsonConvert.SerializeObject(requestObj));
                    logger.Trace($"\nAPI REQUEST BODY:{JsonConvert.SerializeObject(requestObj)}");

                    // PRINTING RESPONSE DETAILS
                    if (clientConfig.ApiClient.ApiResponse != null)
                    {
                        if (!string.IsNullOrEmpty(clientConfig.ApiClient.ApiResponse.StatusCode.ToString()))
                        {
                            Console.WriteLine($"\nAPI RESPONSE CODE: {clientConfig.ApiClient.ApiResponse.StatusCode}");
                        }

                        Console.WriteLine("\nAPI RESPONSE HEADERS:");

                        foreach (var responseHeader in clientConfig.ApiClient.ApiResponse.HeadersList)
                        {
                            Console.WriteLine(responseHeader);
                        }

                        Console.WriteLine("\nAPI RESPONSE BODY:");
                        Console.WriteLine(clientConfig.ApiClient.ApiResponse.Data);
                    }

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(VoidPayment)}");
                }
            }
        }
    }
}