﻿using System;
using CyberSource.Api;
using CyberSource.Model;
using NLog;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class RetrieveAllPaymentInstruments
    {
        public static void Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(RetrieveAllPaymentInstruments)}");

            Logger logger = LogManager.GetCurrentClassLogger();
            CyberSource.Client.Configuration clientConfig = null;
            TmsV1InstrumentidentifiersPaymentinstrumentsGet200Response result = null;

            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = CreateInstrumentIdentifier.Run().Id;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new PaymentInstrumentsApi(clientConfig);

                result = apiInstance.TmsV1InstrumentidentifiersTokenIdPaymentinstrumentsGet(profileId, tokenId);

            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException on calling the Sample Code({nameof(RetrieveAllPaymentInstruments)}):{e.Message}");
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

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(RetrieveAllPaymentInstruments)}");
                }
            }
        }
    }
}