﻿// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.SemanticKernel.Memory;

/// <summary>
/// Implementation of <see cref="ISemanticTextMemory"/> that stores nothing.
/// </summary>
public sealed class NullMemory : ISemanticTextMemory
{
    /// <summary>
    /// Singleton instance
    /// </summary>
    public static NullMemory Instance { get; } = new();

    /// <inheritdoc/>
    public Task<string> SaveInformationAsync(
        string collection,
        string text,
        string id,
        string? description = null,
        string? additionalMetadata = null,
        CancellationToken cancel = default)
    {
        return Task.FromResult(string.Empty);
    }

    /// <inheritdoc/>
    public Task<string> SaveReferenceAsync(
        string collection,
        string text,
        string externalId,
        string externalSourceName,
        string? description = null,
        string? additionalMetadata = null,
        CancellationToken cancel = default)
    {
        return Task.FromResult(string.Empty);
    }

    /// <inheritdoc/>
    public Task<MemoryQueryResult?> GetAsync(
        string collection,
        string key,
        bool withEmbedding = false,
        CancellationToken cancel = default)
    {
        return Task.FromResult(null as MemoryQueryResult);
    }

    /// <inheritdoc/>
    public Task RemoveAsync(
        string collection,
        string key,
        CancellationToken cancel = default)
    {
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public IAsyncEnumerable<MemoryQueryResult> SearchAsync(
        string collection,
        string query,
        int limit = 1,
        double minRelevanceScore = 0.7,
        bool withEmbeddings = false,
        CancellationToken cancel = default)
    {
        return AsyncEnumerable.Empty<MemoryQueryResult>();
    }

    /// <inheritdoc/>
    public Task<IList<string>> GetCollectionsAsync(
        CancellationToken cancel = default)
    {
        return Task.FromResult(new List<string>() as IList<string>);
    }

    private NullMemory()
    {
    }
}
