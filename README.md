# Airport flilght administering program

This is a software which provides graphical interface
for administering incoming and outgoing flights, available routes, 
tickets and passenger data for airport administrators. 
This software is a demonstrative lab project of my 2nd course's 2nd semester for 
Methodologies and technologies of software development discipline.

It uses following technologies and techniques:
* .NET Core 3.1 platform using C# language
* WPF GUI
* MVVM pattern
* Entity Framework Core
* Database generation using code-first approach
* Data storage in MSSQL database
* Dependency injection 
* 3-tier architecture with following dedicated assemblies: Data access layer - Entities - Mappers - Model - Services - WPF and console UI
* Repository pattern (which wraps EF's DbSets)

This application provides following features:
* assign new flights
* delay flight takeoff
* stop ticket selling in a given time before takeoff
* show sold tickets for a given flight
* register bought tickets in the system
* in general, convenient interface for manual manipulation of data for each entity type
