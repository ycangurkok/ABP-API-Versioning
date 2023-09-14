using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace BookStore.Books;

public class BookAppService : BookStoreAppService, IBookAppService
{
    public Task<BookDto> GetAsync()
    {
        return Task.FromResult(
            new BookDto
            {
                Title = $"Mastering ABP Framework V{RequestedApiVersion.Current}",
                ISBN = "978-1-80107-924-2"
            }
        );
    }
}

public class BookV2AppService : BookStoreAppService, IBookV2AppService
{
    public Task<BookDto> GetAsync()
    {
        return Task.FromResult(
            new BookDto
            {
                Title = $"Mastering ABP Framework V{RequestedApiVersion.Current}",
                ISBN = "978-1-80107-924-2"
            }
        );
    }

    public Task<BookDto> GetAsync(string isbn)
    {
        if (isbn == "978-1-80107-924-2")
        {
            return Task.FromResult(
                new BookDto
                {
                    Title = $"Mastering ABP Framework V{RequestedApiVersion.Current}",
                    ISBN = "978-1-80107-924-2"
                }
            );
        }

        throw new EntityNotFoundException();
    }
}

public class BookV3AppService : BookStoreAppService, IBookV3AppService
{
    public Task<BookDto> GetAsync()
    {
        return Task.FromResult(
            new BookDto
            {
                Title = $"Mastering ABP Framework V{RequestedApiVersion.Current}",
                ISBN = "978-1-80107-924-2",
                Year = "2022"
            }
        );
    }

    public Task<BookDto> GetAsync(string isbn)
    {
        if (isbn == "978-1-80107-924-2")
        {
            return Task.FromResult(
                new BookDto
                {
                    Title = $"Mastering ABP Framework V{RequestedApiVersion.Current}",
                    ISBN = "978-1-80107-924-2",
                    Year = "2022"
                }
            );
        }

        throw new EntityNotFoundException();
    }

    public Task DeleteAsync(string title)
    {
        if (title == "Mastering ABP Framework V3")
        {
            return Task.CompletedTask;
        }

        throw new EntityNotFoundException();
    }
}

public class BookV3p1AppService : BookStoreAppService, IBookV3p1AppService
{
    public Task<BookDto> GetAsync()
    {
        return Task.FromResult(
            new BookDto
            {
                Title = $"Mastering ABP Framework V{RequestedApiVersion.Current}",
                ISBN = "978-1-80107-924-2",
                Year = "2022"
            }
        );
    }

    public Task<BookDto> GetAsync(string isbn)
    {
        if (isbn == "978-1-80107-924-2")
        {
            return Task.FromResult(
                new BookDto
                {
                    Title = $"Mastering ABP Framework V{RequestedApiVersion.Current}",
                    ISBN = "978-1-80107-924-2",
                    Year = "2022"
                }
            );
        }

        throw new EntityNotFoundException();
    }

    public Task DeleteAsync(string title)
    {
        if (title == "Mastering ABP Framework V3.1")
        {
            return Task.CompletedTask;
        }

        throw new EntityNotFoundException();
    }
}

public class BookV4AppService : BookStoreAppService, IBookV4AppService
{
    public Task<BookDtoUpdated> GetAsync()
    {
        return Task.FromResult(
            new BookDtoUpdated
            {
                Title = $"Mastering ABP Framework V{RequestedApiVersion.Current}",
                ISBN = "978-1-80107-924-2",
                Year = "2022",
                InStock = true
            }
        );
    }

    public Task<BookDtoUpdated> GetAsync(string isbn)
    {
        if (isbn == "978-1-80107-924-2")
        {
            return Task.FromResult(
                new BookDtoUpdated
                {
                    Title = $"Mastering ABP Framework V{RequestedApiVersion.Current}",
                    ISBN = "978-1-80107-924-2",
                    Year = "2022",
                    InStock = true
                }
            );
        }

        throw new EntityNotFoundException();
    }

    public Task DeleteAsync(string title)
    {
        if (title == "Mastering ABP Framework V4")
        {
            return Task.CompletedTask;
        }

        throw new EntityNotFoundException();
    }
}
