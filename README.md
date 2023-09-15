# API Versioning with the ABP Framework

This project demonstrates how API versioning could be achieved within the ABP framework. The general structure of the codebase was obtained from the [abp-samples](https://github.com/abpframework/abp-samples/tree/master/Api-Versioning) repository, although some major changes were made to eliminate the need for local dependencies and to illustrate how compliance with the semantic versioning standard could be achieved. Documentation of these changes can be found below, along with set-up and testing instructions.

## Set-up & Running
The solution obtained from the abp-samples repository was altered such that no local dependencies are present. NuGet packages may have to be restored with the `dotnet restore` on the terminal, or via the "*Restore NuGet Packages*" option of Visual Studio; depending on the  packages previously installed by the user.

The executable of the solution is the **BookStore.WebApp** project found within the *hosts* directory. Following a successful build, the executable will open a new tab on the user's default web browser. If this fails, type `https://localhost:44331` to get to the web page. The port number can be changed by editing *launchSettings.json* found in `host/BookStore.WebApp/Properties`.

The recommended way of interacting with the API is via Swagger UI, reached thorough either the *Swagger* hyperlink on the main webpage, or through the URL `https://localhost:44331/swagger/index.html`. API testing software such as Postman are also supported.

### Proxy Generation
Proxy generation for the projects *BookStore<nolink>.Web* and *BookStore.HttpApi.Client* were achieved via the commands

 - `abp generate-proxy -t js -u https://localhost:44331/ -m bookStore`
 - `abp generate-proxy -t csharp -u https://localhost:44331/ -m bookStore`

respectively.

If you want to generate new proxies, ensure that you `cd` into the project folders before execution of the commands, and that the *BookStore.WebApp* project is running in the background. Make sure that the structure of the folder *ClientProxies* is identical to the structure provided in this repository following the execution of the second command above (*i.e.* There should be no directories within the ClientProxies directory). The newly generated files excluding *bookStore-generate-proxy.json* and the files ending in *Proxy.cs* and *Proxy.Generated.cs* are unsupported and unnecessary.

## Versioning
The solution both illustrates appropriate SemVer practices and API versioning methodology with the ABP framework.


### Semantic Versioning Conventions

*Chart of supported functionality in regard to API Version*
|    | V1.0 |V2.0| V3.0|V3.1| V4.0 |
|---|---|---|---|---|---|
|/BookStore/Book |❌|❌|❔|❔|✔️|
|/BookStore/Book/{isbn} |🔴|❌|❔|❔|✔️|
|/BookStore/Book/{title} |🔴|🔴|❔|❔|✔️|
|/Orders |❌|✔️|✔️|✔️|✔️|
|/Orders (POST) |🔴|✔️|✔️|✔️|✔️|
|/Orders/{id} |❌|✔️|✔️|✔️|✔️|
|/Orders/{id} (DEL) |🔴|🔴|✔️|✔️|✔️|
|/vX.X/People |🔴|✔️|✔️|✔️|✔️|
|/vX.X/People (POST) |🔴|🔴|✔️|✔️|✔️|
|/vX.X/People/{id} |❌|✔️|✔️|✔️|✔️|
|/vX.X/People/{id} (DEL) |🔴|🔴|🔴|✔️|✔️|

 - ✔️=> Supported 
 - ❌=> Deprecated
 - 🔴 => Not implemented
 - ❔=> Supported for API callers made compatible with older versions.

Following is an explanation of each version and its upgrade:

 - **V1.0**: This version was fully deprecated for demonstration purposes. It allows for the illustration of Swagger UI's complete deprecation detection functionality (*i.e.* "This API version has been deprecated." message displayed on Swagger UI), as well as the display of deprecated versions in HTTP headers of API calls.
 
 - **V2.0**: This is the first (partially) supported version. It lacks the DELETE HTTP request for *Order* objects, as well as the POST and DELETE HTTP requests for *People* objects that are implemented in later versions. Additionally, the *Book* object is fully deprecated when compared with later versions, as this version lacks support for the *Year* property of the Book DTO, which will yield a *null* value when called.
 
 - **V3.0**: This version adds support for DELETE requests for /Orders/{id} calls and POST requests for vX.X/People calls. This alone, however, doesn't necessitate a major version increase (*i.e.* V2.0 -> V3.0) on its own, as adding new HTTP routed calls does not invalidate compatibility with the previous version. The major version increment, therefore, is a result of the changes made in the *BookDto* class, as the addition of a new field (*Year*) makes calls made to the API without regard to this new field potentially erroneous (*i.e.* changing the DTO shared by both versions causes a soft incompatibility, necessitating a major version increase).

- **V3.1**: This version adds support for DELETE requests for /vX.X/People/{id} calls, and nothing more. Since the newly added functionality does not alter any of the previously available functionality, API calls designed for V3.0 are fully compatible with this version, and therefore only a minor version increase from V3.0 is necessary.

- **V4.0**: This version implements a new Book DTO (*BookDtoUpdated*), and implements the calls to /BookStore/Book, /BookStore/Book/{isbn}, /BookStore/Book/{title} routes utilizing this new DTO, whose only difference from the previous DTO is the boolean property of *InStock*. The presence of this new property caused by the newer DTO necessitates a major version increase (V3.1 -> V4.0). It should be noted that previous versions may still be supported for those who implemented their API calls with the initial DTO in mind. The functionality built atop these API calls, however, are mutually incompatible between the versions.

### Methodology
The solution demonstrates two different methods of versioning supported by the ABP framework:

 1. For the *Orders* and *People* objects, the versioning implementation can be found within the *BookStore.WebApp* project. Inside the *Controllers* directory, the models and controllers for each version can be found separated into their respective directories. Each of these directories includes a controller and model for both the *Order* and *Person* objects. This allows for the separation of concerns/methods for each version, avoiding a large, single file in which the behavior for each version is defined. It should be noted that the inclusion of the version number for routing purposes (*i.e.* /api/**v4**/People) is completely optional, and is implemented via the attributes denoted via square brackets above the controller classes (*e.g.* `[Route("api/v{version:apiVersion}/People")]`). Deprecation is achieved via setting the flag `Deprecated = true` within the controller attribute `ApiVersion`.
 
 2. For the *Book* object, the versioning implementation can be found within the projects present inside the *src* directory. This implementation follows ABP's layered implementation conventions. DTOs and the service interface is found within *BookStore.Application.Contracts* and implemented within *BookStore.Application*. The controller (singular) is found within *BookStore.HttpApi*, and the proxies are found in *BookStore.HttpApi.Client*. It should be noted that, unlike the previous implementation, the controllers and service interfaces are found within their respective singular files (*i.e.* the controllers for V1.0 and V4.0 are in the same file). Deprecation is achieved via setting the flag `Deprecated = true` within the controller attribute `ApiVersion`.

## Known Bugs
While starting the solution, the opened terminal displays multiple errors indicating that the program is unable to find certain JavaScript files. It has no known effects on functionality and could be safely ignored for the purposes of this project.

## Acknowledgements
abp-samples: For providing the foundation of this project.
