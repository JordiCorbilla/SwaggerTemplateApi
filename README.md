# Swagger Template WebApi

Simple Swagger API template for .NET Framework 4.8 and .Net Core 3.1.6

## .NET Framework 4.8

### Usage 4.8

Download or Clone the repo. Build the project and run it. Then, access the following URL: <https://localhost:44334/swagger/ui/index> and you will see the Swagger UI loading up:
![Swagger48](https://github.com/JordiCorbilla/SwaggerTemplateApi/raw/master/Swagger48.png)

## .NET Core 3.1.6

### Usage 3.1.6

Download or Clone the repo. Build the project and run it. Then, access the following URL: <https://localhost:5001/swagger/api/index.html> and you will see the Swagger UI loading up:
![Swagger315](https://github.com/JordiCorbilla/SwaggerTemplateApi/raw/master/Swagger315.png)

Install the following packages:

```json
<PackageReference Include="Serilog" Version="2.9.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="5.5.1" />
<PackageReference Include="Swashbuckle.AspNetCore.Annotations" Version="5.5.1" />
<PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="3.1.6" />
<PackageReference Include="Serilog.AspNetCore" Version="3.2.0" />
<PackageReference Include="Serilog.Sinks.Console" Version="3.1.1" />
<PackageReference Include="Swashbuckle.AspNetCore.Swagger" Version="5.5.1" />
```

