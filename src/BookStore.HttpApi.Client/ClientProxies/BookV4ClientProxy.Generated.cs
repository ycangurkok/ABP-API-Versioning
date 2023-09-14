// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using BookStore.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.ClientProxying;
using Volo.Abp.Http.Modeling;

// ReSharper disable once CheckNamespace
namespace BookStore.Books;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IBookV4AppService), typeof(BookV4ClientProxy))]
public partial class BookV4ClientProxy : ClientProxyBase<IBookV4AppService>, IBookV4AppService
{
    public virtual async Task<BookDtoUpdated> GetAsync()
    {
        return await RequestAsync<BookDtoUpdated>(nameof(GetAsync));
    }

    public virtual async Task<BookDtoUpdated> GetAsync(string isbn)
    {
        return await RequestAsync<BookDtoUpdated>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(string), isbn }
        });
    }

    public virtual async Task DeleteAsync(string title)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(string), title }
        });
    }
}
