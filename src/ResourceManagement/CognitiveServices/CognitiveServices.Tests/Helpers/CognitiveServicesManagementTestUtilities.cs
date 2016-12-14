﻿// 
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Xunit;
using System.Runtime.Serialization;

namespace CognitiveServices.Tests.Helpers
{
    public static class CognitiveServicesManagementTestUtilities
    {
        public static bool IsTestTenant = false;
        private static HttpClientHandler Handler = null;

        // These should be filled in only if test tenant is true
#if DNX451
        private static string certName = null;
        private static string certPassword = null;
#endif
        private const string testSubscription = null;
        private static Uri testUri = null;

        // These are used to create default accounts
        public static string DefaultLocation = IsTestTenant ? null : "westus";
        public const SkuName DefaultSkuName = SkuName.S1;
        public const Kind DefaultKind = Kind.TextAnalytics;
        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
            {
                {"key1","value1"},
                {"key2","value2"}
            };

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (IsTestTenant)
            {
                return null;
            }
            else
            {
                handler.IsPassThrough = true;
                ResourceManagementClient resourcesClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
                return resourcesClient;
            }
        }

        public static CognitiveServicesManagementClient GetCognitiveServicesManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            CognitiveServicesManagementClient cognitiveServicesClient;
            if (IsTestTenant)
            {
                cognitiveServicesClient = new CognitiveServicesManagementClient(new TokenCredentials("xyz"), GetHandler());
                cognitiveServicesClient.SubscriptionId = testSubscription;
                cognitiveServicesClient.BaseUri = testUri;
            }
            else
            {
                handler.IsPassThrough = true;
                cognitiveServicesClient = context.GetServiceClient<CognitiveServicesManagementClient>(handlers: handler);
            }
            return cognitiveServicesClient;
        }

        private static HttpClientHandler GetHandler()
        {
#if DNX451
            if (Handler == null)
            {
                //talk to yugangw-msft, if the code doesn't work under dnx451 (same with net451)
                X509Certificate2 cert = new X509Certificate2(certName, certPassword);
                Handler = new System.Net.Http.WebRequestHandler();
                ((WebRequestHandler)Handler).ClientCertificates.Add(cert);
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            }
#endif
            return Handler;
        }

        public static CognitiveServicesAccountCreateParameters GetDefaultCognitiveServicesAccountParameters(Kind kind = DefaultKind, SkuName skuName = DefaultSkuName)
        {
            CognitiveServicesAccountCreateParameters account = new CognitiveServicesAccountCreateParameters
            {
                Location = DefaultLocation,
                Tags = DefaultTags,
                Sku = new Sku { Name = skuName },
                Kind = kind,
                Properties = new object(),
            };

            return account;
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient)
        {
            const string testPrefix = "res";
            var rgname = TestUtilities.GenerateName(testPrefix);

            if (!IsTestTenant)
            {
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup
                    {
                        Location = DefaultLocation
                    });
            }

            return rgname;
        }

        public static string CreateCognitiveServicesAccount(CognitiveServicesManagementClient cognitiveServicesMgmtClient, string rgname, Kind? kind = null)
        {
            string accountName = TestUtilities.GenerateName("csa");
            CognitiveServicesAccountCreateParameters parameters = GetDefaultCognitiveServicesAccountParameters();
            if (kind.HasValue) parameters.Kind = kind.Value;
            var createRequest2 = cognitiveServicesMgmtClient.CognitiveServicesAccounts.Create(rgname, accountName, parameters);

            return accountName;
        }

        public static CognitiveServicesAccount CreateAndValidateAccountWithOnlyRequiredParameters(CognitiveServicesManagementClient cognitiveServicesMgmtClient, string rgName, SkuName skuName, Kind accountType = Kind.Recommendations)
        {
            // Create account with only required params
            var accountName = TestUtilities.GenerateName("csa");
            var parameters = new CognitiveServicesAccountCreateParameters
            {
                Sku = new Sku { Name = skuName },
                Kind = accountType,
                Location = DefaultLocation,
                Properties = new object(),
            };
            var account = cognitiveServicesMgmtClient.CognitiveServicesAccounts.Create(rgName, accountName, parameters);
            VerifyAccountProperties(account, false, accountType, skuName);
            Assert.Equal(skuName, account.Sku.Name);
            Assert.Equal(accountType.ToString(), account.Kind);

            return account;
        }

        public static CognitiveServicesAccount CreateAndValidateAccountWithKindSkuLocation(CognitiveServicesManagementClient cognitiveServicesMgmtClient, string rgName, Kind accountType, SkuName skuName, string location)
        {
            // Create account with only required params
            var accountName = TestUtilities.GenerateName("csa");
            var parameters = new CognitiveServicesAccountCreateParameters
            {
                Sku = new Sku { Name = skuName },
                Kind = accountType,
                Location = location,
                Properties = new object(),
            };
            var account = cognitiveServicesMgmtClient.CognitiveServicesAccounts.Create(rgName, accountName, parameters);
            VerifyAccountProperties(account, false, accountType, skuName, location);

            return account;
        }


        public static void VerifyAccountProperties(CognitiveServicesAccount account, bool useDefaults, Kind kind = DefaultKind, SkuName skuName = DefaultSkuName, string location = "westus")
        {
            Assert.NotNull(account); // verifies that the account is actually created
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Location);
            Assert.NotNull(account.Name);
            Assert.NotNull(account.Etag);
            Assert.NotNull(account.Kind);

            Assert.NotNull(account.Sku);
            Assert.NotNull(account.Sku.Name);

            Assert.NotNull(account.Endpoint);
            Assert.Equal(ProvisioningState.Succeeded, account.ProvisioningState);

            if (useDefaults)
            {
                Assert.Equal(DefaultLocation, account.Location);
                Assert.Equal(DefaultSkuName, account.Sku.Name);
                Assert.Equal(DefaultKind.GetAttributeOfType<EnumMemberAttribute>().Value, account.Kind);

                Assert.NotNull(account.Tags);
                Assert.Equal(2, account.Tags.Count);
                Assert.Equal(account.Tags["key1"], "value1");
                Assert.Equal(account.Tags["key2"], "value2");
            }
            else
            {
                Assert.Equal(skuName, account.Sku.Name);
                Assert.Equal(kind.GetAttributeOfType<EnumMemberAttribute>().Value, account.Kind);
                Assert.Equal(location, account.Location);
            }
        }

        public static void ValidateExpectedException(Action action, string expectedErrorCode)
        {
            try
            {
                action();
                Assert.True(false, "Expected an Exception");
            }
            catch (ErrorException e)
            {
                Assert.Equal(expectedErrorCode, e.Body.ErrorProperty.Code);
            }
        }

        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            if(memInfo != null && memInfo.Count() > 0)
            {
                var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
                if (attributes.Count() > 0)
                {
                    return attributes.First() as T;
                }
            }

            return null;
        }
    }
}