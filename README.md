# SignalRByExample

This is the SignalRByExample from Part 1 of the 3-part ["SignalR Course"](https://www.youtube.com/watch?v=hGxr1yAb1gk)

## Initial Steps
1) Download this example repository.
2) From the ~\TheCallCenter folder root, run ```dotnet tool restore```
    * **This will install the new [dotnet-ef](https://nuget.org/packages/dotnet-ef) tool, since dotnet cli no longer comes with Entity Framework CLI installed**
    * *If you have this downloaded on an external drive, you may encounter the issue:  ~\TheCallCenter\.config\dotnet-tools.json came from another computer and might be blocked to help protect this computer. For more information, including how to unblock, see https://aka.ms/motw*
        * *One workaround is to download it to your startup drive, not your external drive.*
3) From the ~\TheCallCenter folder root, run ```dotnet ef database update```
    * **This will update the MSSqlLocalDB, a database which comes installed with Visual Studio**