# Generic data structures
The goal of this project is to provide strongly typed generic result types, with the hope of people using those types instead of having to implement their own or using types which have implicit relations between data, i.e. "If this enum is set to X then property Y is set, otherwise it's null".

## Installation
The GenericDataStructures package can be installed through NuGet package manager
```
Install-Package GenericDataStructures -Version 1.0.3
```
or .NET CLI
```
dotnet add package GenericDataStructures --version 1.0.3
```
or of course through "Manage NuGet Packages" in Visual Studio if you like graphical interfaces like I do

## Provided types
The package provides three variants of more or less specialized discriminating union types:
  - Result, a result type which contains either a success value or the failure value of one of one or more specified types
  - VoidResult, a result type which is either success or the failure value of one of one or more specified types
  - Union, a type which contain the value of one of two or more specified types

All the types provide a Switch method which you can use to access the value, and a Map method which you can use to access the potential values and convert them to another type. Both methods require you to handle all potential value types.

### Result
A Result types first generic parameter is the type for a successful result value, and following generic parameters are types for failure result values. You can use Switch or Map to handle all value types, or use IsSuccess property, TryGetSuccessValue method, or TryMap method if you are only interested in the success value.

#### Example usage case
```csharp
public class MyResourceService
{
    //...//

    public Result<MyResource, CreateMyResourceError, MissingData> CreateMyResource(MyResourceCreationData data)
    {
        if (!_myOtherResourceService.HasResource(data.MyOtherResourceId))
        {
            // Return error enum
            return CreateMyResourceError.LinkedMyOtherResourceDoesNotExist;
        }

        var missingDataFields = GetMissingDataFields(data);
        if (missingDataFields.Any())
        {
            // Return error class with data
            return new MissingData(missingDataFields);
        }

        // Return success type
        return new MyResource();
    }

    //...//
}

[ApiController]
[Route("[controller]")]
public class MyResourceController : ControllerBase
{
    //...//

    [HttpPost]
    public IActionResult Post(MyResourceCreationData data)
    {
        var result = _myResourceService.CreateMyResource(data);
        return result.Map<IActionResult>(
            Ok,
            error =>
            {
                return error switch
                {
                    CreateMyResourceError.LinkedMyOtherResourceDoesNotExist => BadRequest("Couldn't find linked resource MyOtherResource"),
                    _ => BadRequest()
                };
            },
            missingData => BadRequest($"The following fields are missing: {string.Join(", ", missingData)}")
        );
    }

    //...//
}
```

### VoidResult
A VoidResult types generic parameters are types for failure result values. You can use Switch or Map to handle the void success result and all other failure types, or use IsSuccess property if you only are interested if the result is a success result. To construct a successful VoidResult you use the static value VoidResult.Success.

#### Example use case
```csharp
public class MyResourceService
{   
    //...//

    public VoidResult<DeleteMyResourceError> DeleteMyResource(long id)
    {
        var myResource = _myResourceRepository.Get(id);
        if (myResource == null)
        {
            // Return error enum
            return DeleteMyResourceError.NotFound;
        }

        if (myResource.IsDeleted)
        {
            // Return error enum
            return DeleteMyResourceError.AlreadyDeleted;
        }

        // Return empty success result
        return VoidResult.Success; // A typed version, for example VoidResult<DeleteMyResourceError>.Success, is also available, which can be useful when returning from a generic method
    }

    //...//
}

[ApiController]
[Route("[controller]")]
public class MyResourceController : ControllerBase
{    
    //...//

    [HttpDelete]
    public IActionResult Delete(long id)
    {
        var result = _myResourceService.DeleteMyResource(id);
        return result.Map<IActionResult>(
            NoContent,
            error =>
            {
                return error switch
                {
                    DeleteMyResourceError.NotFound => NotFound(),
                    DeleteMyResourceError.AlreadyDeleted => new StatusCodeResult(410),
                    _ => BadRequest()
                };
            }
        );
    }

    //...//
}
```

### Union
The Union types generic parameters define which types it can contain. You can only access the value through either Switch or Map methods.

#### Example use case
```csharp
static Union<Circle, Rectangle, Triangle> CreateRandomShape()
{
    return new Random().Next(3) switch
    {
        0 => new Circle(),
        1 => new Rectangle(),
        2 => new Triangle(),
        _ => throw new ArgumentOutOfRangeException()
    };
}

var shape = CreateRandomShape();
shape.Switch(circle => Console.WriteLine($"You got a circle with {circle.Diameter} in diameter!"),
    rectangle => Console.WriteLine($"You got a {rectangle.Width}x{rectangle.Height} rectangle!"),
    triangle => Console.WriteLine($"You got a triangle with the side {triangle.Length}!"));
```

### Equality
The three variants delegate equality to underlying types, but require the data type to been constructed with same generic parameter. The equality operator has been implemented to use Object.Equals.

#### Equality examples
```csharp
int one = 1;
int two = 2;
long oneLong = 1;
Result<int, long> resultOne = one;
Result<int, long> resultOneAgain = one;
Result<int, long> resultTwo = two;
Result<int, long> resultOneLong = oneLong;

Console.WriteLine(one == oneLong); // True
Console.WriteLine(resultOne == resultOneAgain); // True
Console.WriteLine(resultOne == resultTwo); // False
Console.WriteLine(resultOne == resultOneLong); // False
Console.WriteLine(resultOne != resultTwo); // True
```
