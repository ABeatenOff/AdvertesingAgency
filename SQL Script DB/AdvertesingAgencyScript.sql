USE [master]
GO
/****** Object:  Database [AdvertisingAgency]    Script Date: 21.08.2023 14:35:51 ******/
CREATE DATABASE [AdvertisingAgency]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AdvertisingAgency', FILENAME = N'W:\SystemSQL\MSSQL15.SQLEXPRESS\MSSQL\DATA\AdvertisingAgency.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AdvertisingAgency_log', FILENAME = N'W:\SystemSQL\MSSQL15.SQLEXPRESS\MSSQL\DATA\AdvertisingAgency_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AdvertisingAgency] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AdvertisingAgency].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AdvertisingAgency] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET ARITHABORT OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AdvertisingAgency] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AdvertisingAgency] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AdvertisingAgency] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AdvertisingAgency] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AdvertisingAgency] SET  MULTI_USER 
GO
ALTER DATABASE [AdvertisingAgency] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AdvertisingAgency] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AdvertisingAgency] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AdvertisingAgency] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AdvertisingAgency] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AdvertisingAgency] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AdvertisingAgency] SET QUERY_STORE = OFF
GO
USE [AdvertisingAgency]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 21.08.2023 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id_client] [int] IDENTITY(1,1) NOT NULL,
	[surname] [nvarchar](30) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[patronymic] [nvarchar](30) NULL,
	[company_name] [nvarchar](50) NOT NULL,
	[phone_number] [nvarchar](15) NULL,
	[email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 21.08.2023 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[id_contract] [int] IDENTITY(1,1) NOT NULL,
	[id_client] [int] NOT NULL,
	[date_preparation] [nvarchar](50) NOT NULL,
	[date_execution] [nvarchar](50) NOT NULL,
	[id_payment_status] [int] NOT NULL,
	[contract_details] [nvarchar](200) NOT NULL,
	[id_contract_status] [int] NOT NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[id_contract] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract_status]    Script Date: 21.08.2023 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract_status](
	[id_contract_status] [int] IDENTITY(1,1) NOT NULL,
	[contract_status_name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Contract_status] PRIMARY KEY CLUSTERED 
(
	[id_contract_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dept]    Script Date: 21.08.2023 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dept](
	[id_dept] [int] IDENTITY(1,1) NOT NULL,
	[dept_name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Dept] PRIMARY KEY CLUSTERED 
(
	[id_dept] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[list_purpose]    Script Date: 21.08.2023 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[list_purpose](
	[id_purpose] [int] IDENTITY(1,1) NOT NULL,
	[id_contract] [int] NOT NULL,
	[id_service] [int] NOT NULL,
	[id_dept] [int] NOT NULL,
	[id_status_service] [int] NOT NULL,
 CONSTRAINT [PK_list_purpose] PRIMARY KEY CLUSTERED 
(
	[id_purpose] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_status]    Script Date: 21.08.2023 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_status](
	[id_payment_status] [int] IDENTITY(1,1) NOT NULL,
	[name_payment status] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Payment_status] PRIMARY KEY CLUSTERED 
(
	[id_payment_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 21.08.2023 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[id_service] [int] IDENTITY(1,1) NOT NULL,
	[name_service] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[id_service] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status_service]    Script Date: 21.08.2023 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status_service](
	[id_status_service] [int] IDENTITY(1,1) NOT NULL,
	[service_status_name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Status_service] PRIMARY KEY CLUSTERED 
(
	[id_status_service] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21.08.2023 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[login] [nvarchar](14) NOT NULL,
	[password] [nvarchar](16) NOT NULL,
	[id_dept] [int] NOT NULL,
	[surname] [nvarchar](30) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[patronymic] [nvarchar](16) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([id_client], [surname], [name], [patronymic], [company_name], [phone_number], [email]) VALUES (1005, N'Анакентий', N'Альберт', N'Альбертович', N'Цветки счастья', N'8593425235', N'cvetock228@mail.ru')
INSERT [dbo].[Client] ([id_client], [surname], [name], [patronymic], [company_name], [phone_number], [email]) VALUES (1008, N'Гусев', N'Андрей', N'Мальберович', N'Аркада ковров', N'8543530245', N'kovrikovri2@mail.ru')
INSERT [dbo].[Client] ([id_client], [surname], [name], [patronymic], [company_name], [phone_number], [email]) VALUES (1009, N'Кузнецов', N'Егор', N'Олегович', N'Пшено Пшено', N'8753436345', N'IlovePsheno@mail.ru')
INSERT [dbo].[Client] ([id_client], [surname], [name], [patronymic], [company_name], [phone_number], [email]) VALUES (1010, N'Заборов', N'Олег', N'Владимирович', N'СтавимСтавки', N'8854363633', N'Stavka322@mail.ru')
INSERT [dbo].[Client] ([id_client], [surname], [name], [patronymic], [company_name], [phone_number], [email]) VALUES (1011, N'Бушко', N'Валера', N'Аракадионович', N'Музыка для вас', N'8654963536', N'MusicLove@mail.ru')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Contract] ON 

INSERT [dbo].[Contract] ([id_contract], [id_client], [date_preparation], [date_execution], [id_payment_status], [contract_details], [id_contract_status]) VALUES (1008, 1005, N'20/05/2023', N'21/06/2023', 2, N'некое описание', 1)
INSERT [dbo].[Contract] ([id_contract], [id_client], [date_preparation], [date_execution], [id_payment_status], [contract_details], [id_contract_status]) VALUES (1010, 1008, N'26/05/2023', N'27/06/2023', 1, N'Подробности заказа', 1)
INSERT [dbo].[Contract] ([id_contract], [id_client], [date_preparation], [date_execution], [id_payment_status], [contract_details], [id_contract_status]) VALUES (1012, 1009, N'28./07/2023', N'29/08/2023', 1, N'описание', 2)
INSERT [dbo].[Contract] ([id_contract], [id_client], [date_preparation], [date_execution], [id_payment_status], [contract_details], [id_contract_status]) VALUES (1013, 1010, N'12/08/2023', N'15/09/2023', 2, N'описание', 2)
INSERT [dbo].[Contract] ([id_contract], [id_client], [date_preparation], [date_execution], [id_payment_status], [contract_details], [id_contract_status]) VALUES (1014, 1011, N'16/08/2023', N'25/09/2023', 1, N'описание', 2)
SET IDENTITY_INSERT [dbo].[Contract] OFF
GO
SET IDENTITY_INSERT [dbo].[Contract_status] ON 

INSERT [dbo].[Contract_status] ([id_contract_status], [contract_status_name]) VALUES (1, N'Готов')
INSERT [dbo].[Contract_status] ([id_contract_status], [contract_status_name]) VALUES (2, N'Не готов')
SET IDENTITY_INSERT [dbo].[Contract_status] OFF
GO
SET IDENTITY_INSERT [dbo].[Dept] ON 

INSERT [dbo].[Dept] ([id_dept], [dept_name]) VALUES (1, N'Стратегического планирования')
INSERT [dbo].[Dept] ([id_dept], [dept_name]) VALUES (2, N'Креативный отдел')
INSERT [dbo].[Dept] ([id_dept], [dept_name]) VALUES (3, N'Продакшн отдел')
INSERT [dbo].[Dept] ([id_dept], [dept_name]) VALUES (4, N'Аккаунт-Менеджмент')
SET IDENTITY_INSERT [dbo].[Dept] OFF
GO
SET IDENTITY_INSERT [dbo].[list_purpose] ON 

INSERT [dbo].[list_purpose] ([id_purpose], [id_contract], [id_service], [id_dept], [id_status_service]) VALUES (2002, 1008, 2, 3, 1)
INSERT [dbo].[list_purpose] ([id_purpose], [id_contract], [id_service], [id_dept], [id_status_service]) VALUES (2003, 1008, 4, 3, 1)
INSERT [dbo].[list_purpose] ([id_purpose], [id_contract], [id_service], [id_dept], [id_status_service]) VALUES (2007, 1010, 1, 3, 1)
INSERT [dbo].[list_purpose] ([id_purpose], [id_contract], [id_service], [id_dept], [id_status_service]) VALUES (2008, 1012, 5, 3, 2)
INSERT [dbo].[list_purpose] ([id_purpose], [id_contract], [id_service], [id_dept], [id_status_service]) VALUES (2009, 1013, 7, 1, 2)
INSERT [dbo].[list_purpose] ([id_purpose], [id_contract], [id_service], [id_dept], [id_status_service]) VALUES (2010, 1014, 1, 2, 2)
INSERT [dbo].[list_purpose] ([id_purpose], [id_contract], [id_service], [id_dept], [id_status_service]) VALUES (2011, 1014, 3, 1, 2)
INSERT [dbo].[list_purpose] ([id_purpose], [id_contract], [id_service], [id_dept], [id_status_service]) VALUES (2012, 1014, 6, 1, 2)
SET IDENTITY_INSERT [dbo].[list_purpose] OFF
GO
SET IDENTITY_INSERT [dbo].[Payment_status] ON 

INSERT [dbo].[Payment_status] ([id_payment_status], [name_payment status]) VALUES (1, N'Оплачен')
INSERT [dbo].[Payment_status] ([id_payment_status], [name_payment status]) VALUES (2, N'Не оплачен')
SET IDENTITY_INSERT [dbo].[Payment_status] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([id_service], [name_service]) VALUES (1, N'Билборд')
INSERT [dbo].[Service] ([id_service], [name_service]) VALUES (2, N'Радио')
INSERT [dbo].[Service] ([id_service], [name_service]) VALUES (3, N'TV')
INSERT [dbo].[Service] ([id_service], [name_service]) VALUES (4, N'Призматрон')
INSERT [dbo].[Service] ([id_service], [name_service]) VALUES (5, N'Доска объявлений')
INSERT [dbo].[Service] ([id_service], [name_service]) VALUES (6, N'Крышная установка')
INSERT [dbo].[Service] ([id_service], [name_service]) VALUES (7, N'Вывеска')
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[Status_service] ON 

INSERT [dbo].[Status_service] ([id_status_service], [service_status_name]) VALUES (1, N'Готов')
INSERT [dbo].[Status_service] ([id_status_service], [service_status_name]) VALUES (2, N'Не готов')
SET IDENTITY_INSERT [dbo].[Status_service] OFF
GO
INSERT [dbo].[User] ([login], [password], [id_dept], [surname], [name], [patronymic]) VALUES (N'1', N'1', 1, N'q', N'w', N'e')
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Client] FOREIGN KEY([id_client])
REFERENCES [dbo].[Client] ([id_client])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Client]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Contract_status] FOREIGN KEY([id_contract_status])
REFERENCES [dbo].[Contract_status] ([id_contract_status])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Contract_status]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Payment_status] FOREIGN KEY([id_payment_status])
REFERENCES [dbo].[Payment_status] ([id_payment_status])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Payment_status]
GO
ALTER TABLE [dbo].[list_purpose]  WITH CHECK ADD  CONSTRAINT [FK_list_purpose_Contract] FOREIGN KEY([id_contract])
REFERENCES [dbo].[Contract] ([id_contract])
GO
ALTER TABLE [dbo].[list_purpose] CHECK CONSTRAINT [FK_list_purpose_Contract]
GO
ALTER TABLE [dbo].[list_purpose]  WITH CHECK ADD  CONSTRAINT [FK_list_purpose_Dept1] FOREIGN KEY([id_dept])
REFERENCES [dbo].[Dept] ([id_dept])
GO
ALTER TABLE [dbo].[list_purpose] CHECK CONSTRAINT [FK_list_purpose_Dept1]
GO
ALTER TABLE [dbo].[list_purpose]  WITH CHECK ADD  CONSTRAINT [FK_list_purpose_Service] FOREIGN KEY([id_service])
REFERENCES [dbo].[Service] ([id_service])
GO
ALTER TABLE [dbo].[list_purpose] CHECK CONSTRAINT [FK_list_purpose_Service]
GO
ALTER TABLE [dbo].[list_purpose]  WITH CHECK ADD  CONSTRAINT [FK_list_purpose_Status_service] FOREIGN KEY([id_status_service])
REFERENCES [dbo].[Status_service] ([id_status_service])
GO
ALTER TABLE [dbo].[list_purpose] CHECK CONSTRAINT [FK_list_purpose_Status_service]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Dept] FOREIGN KEY([id_dept])
REFERENCES [dbo].[Dept] ([id_dept])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Dept]
GO
USE [master]
GO
ALTER DATABASE [AdvertisingAgency] SET  READ_WRITE 
GO
