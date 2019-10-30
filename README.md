# BlazorCRUDSample
This is Blazor Web Assemble App which can run on Client Machine with Server side functionality. Also used Entity Framework Core, Dependency Injection, Table Relationship and more.


## DB Table Scripts
```sql
CREATE TABLE [dbo].[Department]
(
	[Uid] [BIGINT] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[NAME] [VARCHAR](250) NOT NULL
)

CREATE TABLE [dbo].[Employee]
(
	[Uid] [BIGINT] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[NAME] [VARCHAR](250) NOT NULL,
	[Salary] [DECIMAL](18, 0) NOT NULL,
	[DepartmentUid] [BIGINT] NOT NULL FOREIGN KEY REFERENCES [dbo].[Department] ([Uid]),
)

--Sample Data
SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([Uid], [NAME]) VALUES (1, N'Accounts')
GO
INSERT [dbo].[Department] ([Uid], [NAME]) VALUES (2, N'Digital Tranformation')
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([Uid], [NAME], [Salary], [DepartmentUid]) VALUES (1, N'Sam', CAST(50000 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[Employee] ([Uid], [NAME], [Salary], [DepartmentUid]) VALUES (2, N'Julie', CAST(53000 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[Employee] ([Uid], [NAME], [Salary], [DepartmentUid]) VALUES (3, N'Mike', CAST(40000 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[Employee] ([Uid], [NAME], [Salary], [DepartmentUid]) VALUES (4, N'John', CAST(65000 AS Decimal(18, 0)), 2)
GO
INSERT [dbo].[Employee] ([Uid], [NAME], [Salary], [DepartmentUid]) VALUES (5, N'Bruce', CAST(80000 AS Decimal(18, 0)), 2)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
```

### Resources
Visit [docs.microsoft.com](https://docs.microsoft.com/en-us/aspnet/core/blazor/get-started?view=aspnetcore-3.0&tabs=visual-studio)
