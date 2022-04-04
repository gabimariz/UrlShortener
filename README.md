# Url Shortener

## Installation
 Install the [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) to run the project on your machine.

```bash
# Install dotnet-ef global
$ dotnet tool install --global dotnet-ef

# Use package manager dotnet to restore packages
$ dotnet restore
```

## Usage

```C#
/*
	Open Data/AppDbContext.cs to configure the mariadb database edit USERNAME, PASSWORD 
	data and mariadb o mysql version
*/

options.UseMySql("server=localhost;username=USERNAME;password=PASSWORD;database=url_shortener",
	// Edit Major, Minor and Path version database
	new MariaDbServerVersion(new Version(MAJOR, MINOR, PATH)));
```
```bash
# Manage the database
$ dotnet ef database update

# Run the project
$ dotnet run
```
Open the browser at the url https://localhost:5000/swagger to view endpoint documentation.

## Contributing
 Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

 Please make sure to update tests as appropriate.

## License
 The license used in the project is the [GPLv3](https://www.gnu.org/licenses/gpl-3.0.pt-br.html).