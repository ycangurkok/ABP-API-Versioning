using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace BookStore.Books;

[Area(BookStoreRemoteServiceConsts.ModuleName)]
[RemoteService(Name = BookStoreRemoteServiceConsts.RemoteServiceName)]
[ApiVersion("1.0", Deprecated = true)]
[ApiController]
[ControllerName("Book")]
[Route("api/BookStore/Book")]
public class BookController : BookStoreController, IBookAppService
{
    private readonly IBookAppService _bookAppService;

    public BookController(IBookAppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    [HttpGet]
    public async Task<BookDto> GetAsync()
    {
        return await _bookAppService.GetAsync();
    }
}

[Area(BookStoreRemoteServiceConsts.ModuleName)]
[RemoteService(Name = BookStoreRemoteServiceConsts.RemoteServiceName)]
[ApiVersion("2.0", Deprecated = true)]
[ApiController]
[ControllerName("Book")]
[Route("api/BookStore/Book")]
public class BookV2Controller : BookStoreController, IBookV2AppService
{
    private readonly IBookV2AppService _bookAppService;

    public BookV2Controller(IBookV2AppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    [HttpGet]
    public async Task<BookDto> GetAsync()
    {
        return await _bookAppService.GetAsync();
    }

    [HttpGet]
    [Route("{isbn}")]
    public async Task<BookDto> GetAsync(string isbn)
    {
        return await _bookAppService.GetAsync(isbn);
    }
}

[Area(BookStoreRemoteServiceConsts.ModuleName)]
[RemoteService(Name = BookStoreRemoteServiceConsts.RemoteServiceName)]
[ApiVersion("3.0")]
[ApiController]
[ControllerName("Book")]
[Route("api/BookStore/Book")]
public class BookV3Controller : BookStoreController, IBookV3AppService
{
    private readonly IBookV3AppService _bookAppService;

    public BookV3Controller(IBookV3AppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    [HttpGet]
    public async Task<BookDto> GetAsync()
    {
        return await _bookAppService.GetAsync();
    }

    [HttpGet]
    [Route("{isbn}")]
    public async Task<BookDto> GetAsync(string isbn)
    {
        return await _bookAppService.GetAsync(isbn);
    }

    [HttpPost]
    [Route("{title}")]
    public async Task DeleteAsync(string title)
    {
        await _bookAppService.DeleteAsync(title);
    }
}

[Area(BookStoreRemoteServiceConsts.ModuleName)]
[RemoteService(Name = BookStoreRemoteServiceConsts.RemoteServiceName)]
[ApiVersion("3.1")]
[ApiController]
[ControllerName("Book")]
[Route("api/BookStore/Book")]
public class BookV3p1Controller : BookStoreController, IBookV3p1AppService
{
    private readonly IBookV3p1AppService _bookAppService;

    public BookV3p1Controller(IBookV3p1AppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    [HttpGet]
    public async Task<BookDto> GetAsync()
    {
        return await _bookAppService.GetAsync();
    }

    [HttpGet]
    [Route("{isbn}")]
    public async Task<BookDto> GetAsync(string isbn)
    {
        return await _bookAppService.GetAsync(isbn);
    }

    [HttpPost]
    [Route("{title}")]
    public async Task DeleteAsync(string title)
    {
        await _bookAppService.DeleteAsync(title);
    }
}

[Area(BookStoreRemoteServiceConsts.ModuleName)]
[RemoteService(Name = BookStoreRemoteServiceConsts.RemoteServiceName)]
[ApiVersion("4.0")]
[ApiController]
[ControllerName("Book")]
[Route("api/BookStore/Book")]
public class BookV4Controller : BookStoreController, IBookV4AppService
{
    private readonly IBookV4AppService _bookAppService;

    public BookV4Controller(IBookV4AppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    [HttpGet]
    public async Task<BookDtoUpdated> GetAsync()
    {
        return await _bookAppService.GetAsync();
    }

    [HttpGet]
    [Route("{isbn}")]
    public async Task<BookDtoUpdated> GetAsync(string isbn)
    {
        return await _bookAppService.GetAsync(isbn);
    }

    [HttpPost]
    [Route("{title}")]
    public async Task DeleteAsync(string title)
    {
        await _bookAppService.DeleteAsync(title);
    }
}
