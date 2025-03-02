USE [db_kinosal]
GO
/****** Object:  Table [dbo].[filmy]    Script Date: 19.02.2025 20:51:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[filmy](
	[id_fi] [int] IDENTITY(1,1) NOT NULL,
	[nazev] [nvarchar](100) NOT NULL,
	[dat_vzniku] [datetime] NOT NULL,
	[je_stale_promitan] [bit] NOT NULL,
	[id_za] [int] NOT NULL,
	[id_rez] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_fi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kinosály]    Script Date: 19.02.2025 20:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kinosály](
	[id_kis] [int] IDENTITY(1,1) NOT NULL,
	[nazev] [nvarchar](100) NOT NULL,
	[cis_sal] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_kis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[představení]    Script Date: 19.02.2025 20:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[představení](
	[id_pred] [int] IDENTITY(1,1) NOT NULL,
	[dat_plan_pred] [datetime] NOT NULL,
	[dat_kon_pred] [datetime] NOT NULL,
	[delka] [decimal](4, 1) NOT NULL,
	[id_kis] [int] NOT NULL,
	[id_fi] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pred] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[režiséři]    Script Date: 19.02.2025 20:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[režiséři](
	[id_rez] [int] IDENTITY(1,1) NOT NULL,
	[jmeno] [nvarchar](40) NOT NULL,
	[prijmeni] [nvarchar](50) NOT NULL,
	[dat_nar] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_rez] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[žánry]    Script Date: 19.02.2025 20:51:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[žánry](
	[id_za] [int] IDENTITY(1,1) NOT NULL,
	[nazev] [nvarchar](100) NOT NULL,
	[kod] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_za] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[filmy] ON 

INSERT [dbo].[filmy] ([id_fi], [nazev], [dat_vzniku], [je_stale_promitan], [id_za], [id_rez]) VALUES (1, N'Monstrum', CAST(N'2020-06-06T00:00:00.000' AS DateTime), 1, 1, 1)
INSERT [dbo].[filmy] ([id_fi], [nazev], [dat_vzniku], [je_stale_promitan], [id_za], [id_rez]) VALUES (2, N'Scary Movie', CAST(N'2015-03-01T00:00:00.000' AS DateTime), 0, 1, 1)
SET IDENTITY_INSERT [dbo].[filmy] OFF
GO
SET IDENTITY_INSERT [dbo].[kinosály] ON 

INSERT [dbo].[kinosály] ([id_kis], [nazev], [cis_sal]) VALUES (1, N'Smíchov', 1548)
INSERT [dbo].[kinosály] ([id_kis], [nazev], [cis_sal]) VALUES (2, N'Flora', 8888)
SET IDENTITY_INSERT [dbo].[kinosály] OFF
GO
SET IDENTITY_INSERT [dbo].[představení] ON 

INSERT [dbo].[představení] ([id_pred], [dat_plan_pred], [dat_kon_pred], [delka], [id_kis], [id_fi]) VALUES (1, CAST(N'2020-09-17T00:00:00.000' AS DateTime), CAST(N'2020-09-17T00:00:00.000' AS DateTime), CAST(2.5 AS Decimal(4, 1)), 2, 1)
INSERT [dbo].[představení] ([id_pred], [dat_plan_pred], [dat_kon_pred], [delka], [id_kis], [id_fi]) VALUES (4, CAST(N'2024-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime), CAST(2.5 AS Decimal(4, 1)), 2, 1)
SET IDENTITY_INSERT [dbo].[představení] OFF
GO
SET IDENTITY_INSERT [dbo].[režiséři] ON 

INSERT [dbo].[režiséři] ([id_rez], [jmeno], [prijmeni], [dat_nar]) VALUES (1, N'Pavel', N'Lopata', CAST(N'1980-02-10T00:00:00.000' AS DateTime))
INSERT [dbo].[režiséři] ([id_rez], [jmeno], [prijmeni], [dat_nar]) VALUES (2, N'Jana', N'Flíglová', CAST(N'1995-02-05T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[režiséři] OFF
GO
SET IDENTITY_INSERT [dbo].[žánry] ON 

INSERT [dbo].[žánry] ([id_za], [nazev], [kod]) VALUES (1, N'horor', 666)
INSERT [dbo].[žánry] ([id_za], [nazev], [kod]) VALUES (2, N'drama', 841)
INSERT [dbo].[žánry] ([id_za], [nazev], [kod]) VALUES (3, N'thriller', 235)
INSERT [dbo].[žánry] ([id_za], [nazev], [kod]) VALUES (7, N'romantická komedie', 657)
INSERT [dbo].[žánry] ([id_za], [nazev], [kod]) VALUES (8, N'thriller', 235)
INSERT [dbo].[žánry] ([id_za], [nazev], [kod]) VALUES (10, N'historické drama', 357)
INSERT [dbo].[žánry] ([id_za], [nazev], [kod]) VALUES (16, N'animák', 111)
INSERT [dbo].[žánry] ([id_za], [nazev], [kod]) VALUES (18, N'western', 574)
SET IDENTITY_INSERT [dbo].[žánry] OFF
GO
ALTER TABLE [dbo].[filmy]  WITH CHECK ADD FOREIGN KEY([id_rez])
REFERENCES [dbo].[režiséři] ([id_rez])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[filmy]  WITH CHECK ADD FOREIGN KEY([id_za])
REFERENCES [dbo].[žánry] ([id_za])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[představení]  WITH CHECK ADD FOREIGN KEY([id_fi])
REFERENCES [dbo].[filmy] ([id_fi])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[představení]  WITH CHECK ADD FOREIGN KEY([id_kis])
REFERENCES [dbo].[kinosály] ([id_kis])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[filmy]  WITH CHECK ADD CHECK  (([dat_vzniku]>'1900-01-01'))
GO
ALTER TABLE [dbo].[filmy]  WITH CHECK ADD CHECK  ((len([nazev])>=(3)))
GO
ALTER TABLE [dbo].[kinosály]  WITH CHECK ADD CHECK  (([cis_sal]>(0)))
GO
ALTER TABLE [dbo].[kinosály]  WITH CHECK ADD CHECK  ((len([nazev])>=(3)))
GO
ALTER TABLE [dbo].[představení]  WITH CHECK ADD CHECK  (([dat_kon_pred]>'1900-01-01'))
GO
ALTER TABLE [dbo].[představení]  WITH CHECK ADD CHECK  (([dat_plan_pred]>'1900-01-01'))
GO
ALTER TABLE [dbo].[představení]  WITH CHECK ADD CHECK  (([delka]>(0)))
GO
ALTER TABLE [dbo].[režiséři]  WITH CHECK ADD CHECK  (([dat_nar]>'1900-01-01'))
GO
ALTER TABLE [dbo].[režiséři]  WITH CHECK ADD CHECK  ((len([jmeno])>=(3)))
GO
ALTER TABLE [dbo].[režiséři]  WITH CHECK ADD CHECK  ((len([prijmeni])>=(3)))
GO
ALTER TABLE [dbo].[žánry]  WITH CHECK ADD CHECK  (([kod]>(0)))
GO
ALTER TABLE [dbo].[žánry]  WITH CHECK ADD CHECK  ((len([nazev])>=(3)))
GO
