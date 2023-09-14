﻿using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BookStore.Books;

public interface IBookAppService : IApplicationService
{
    Task<BookDto> GetAsync();
}

public interface IBookV2AppService : IApplicationService
{
    Task<BookDto> GetAsync();

    Task<BookDto> GetAsync(string isbn);
}

public interface IBookV3AppService : IApplicationService
{
    Task<BookDto> GetAsync();

    Task<BookDto> GetAsync(string isbn);

    Task DeleteAsync(string title);
}

public interface IBookV3p1AppService : IApplicationService
{
    Task<BookDto> GetAsync();

    Task<BookDto> GetAsync(string isbn);

    Task DeleteAsync(string title);
}

public interface IBookV4AppService : IApplicationService
{
    Task<BookDtoUpdated> GetAsync();

    Task<BookDtoUpdated> GetAsync(string isbn);

    Task DeleteAsync(string title);
}
