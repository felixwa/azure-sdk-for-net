// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.ApiManagement
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ProductPolicyOperations.
    /// </summary>
    public static partial class ProductPolicyOperationsExtensions
    {
            /// <summary>
            /// Get the policy configuration at the Product level.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='serviceName'>
            /// The name of the API Management service.
            /// </param>
            /// <param name='productId'>
            /// Product identifier. Must be unique in the current API Management service
            /// instance.
            /// </param>
            public static PolicyCollection ListByProduct(this IProductPolicyOperations operations, string resourceGroupName, string serviceName, string productId)
            {
                return operations.ListByProductAsync(resourceGroupName, serviceName, productId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get the policy configuration at the Product level.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='serviceName'>
            /// The name of the API Management service.
            /// </param>
            /// <param name='productId'>
            /// Product identifier. Must be unique in the current API Management service
            /// instance.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PolicyCollection> ListByProductAsync(this IProductPolicyOperations operations, string resourceGroupName, string serviceName, string productId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByProductWithHttpMessagesAsync(resourceGroupName, serviceName, productId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get the policy configuration at the Product level.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='serviceName'>
            /// The name of the API Management service.
            /// </param>
            /// <param name='productId'>
            /// Product identifier. Must be unique in the current API Management service
            /// instance.
            /// </param>
            public static PolicyContract Get(this IProductPolicyOperations operations, string resourceGroupName, string serviceName, string productId)
            {
                return operations.GetAsync(resourceGroupName, serviceName, productId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get the policy configuration at the Product level.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='serviceName'>
            /// The name of the API Management service.
            /// </param>
            /// <param name='productId'>
            /// Product identifier. Must be unique in the current API Management service
            /// instance.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PolicyContract> GetAsync(this IProductPolicyOperations operations, string resourceGroupName, string serviceName, string productId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, serviceName, productId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates policy configuration for the Product.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='serviceName'>
            /// The name of the API Management service.
            /// </param>
            /// <param name='productId'>
            /// Product identifier. Must be unique in the current API Management service
            /// instance.
            /// </param>
            /// <param name='parameters'>
            /// The policy contents to apply.
            /// </param>
            public static PolicyContract CreateOrUpdate(this IProductPolicyOperations operations, string resourceGroupName, string serviceName, string productId, PolicyContract parameters)
            {
                return operations.CreateOrUpdateAsync(resourceGroupName, serviceName, productId, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates policy configuration for the Product.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='serviceName'>
            /// The name of the API Management service.
            /// </param>
            /// <param name='productId'>
            /// Product identifier. Must be unique in the current API Management service
            /// instance.
            /// </param>
            /// <param name='parameters'>
            /// The policy contents to apply.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PolicyContract> CreateOrUpdateAsync(this IProductPolicyOperations operations, string resourceGroupName, string serviceName, string productId, PolicyContract parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, serviceName, productId, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the policy configuration at the Product.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='serviceName'>
            /// The name of the API Management service.
            /// </param>
            /// <param name='productId'>
            /// Product identifier. Must be unique in the current API Management service
            /// instance.
            /// </param>
            /// <param name='ifMatch'>
            /// The entity state (Etag) version of the product policy to update. A value of
            /// "*" can be used for If-Match to unconditionally apply the operation.
            /// </param>
            public static void Delete(this IProductPolicyOperations operations, string resourceGroupName, string serviceName, string productId, string ifMatch)
            {
                operations.DeleteAsync(resourceGroupName, serviceName, productId, ifMatch).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the policy configuration at the Product.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='serviceName'>
            /// The name of the API Management service.
            /// </param>
            /// <param name='productId'>
            /// Product identifier. Must be unique in the current API Management service
            /// instance.
            /// </param>
            /// <param name='ifMatch'>
            /// The entity state (Etag) version of the product policy to update. A value of
            /// "*" can be used for If-Match to unconditionally apply the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IProductPolicyOperations operations, string resourceGroupName, string serviceName, string productId, string ifMatch, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, serviceName, productId, ifMatch, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}