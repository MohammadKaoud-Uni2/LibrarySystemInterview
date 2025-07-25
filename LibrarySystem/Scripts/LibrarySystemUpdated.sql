USE [Library]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 6/28/2025 4:45:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [uniqueidentifier] NOT NULL,
	[Author] [nvarchar](100) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[ISBN] [nvarchar](13) NULL,
	[ISAvailable] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Borrowings]    Script Date: 6/28/2025 4:45:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borrowings](
	[Borrowing] [uniqueidentifier] NOT NULL,
	[BookId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[BorrowDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Borrowing] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/28/2025 4:45:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'ffff78a8-dac3-4fd9-995f-239a828f0188', N'Agatha Christie', N'Murder on the Orient Express', N'9780062073495', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'001b8fc5-2574-4d04-a8f7-3146f506f1c8', N'Douglas Adams', N'The Hitchhiker''s Guide to the Galaxy', N'9780345391803', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'a611604e-26b3-49e7-9c2d-37a0de3b63f3', N'Jane Austen', N'Pride and Prejudice', N'9780141439518', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'149c5606-119b-4514-9935-421067c4626b', N'Mohammad', N'The Art of Programming', N'9780123456789', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'11056321-cb65-476c-8a5e-48024f1f8141', N'Harper Lee', N'To Kill a Mockingbird', N'9780061120084', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'0e4bb1b4-2210-4b86-955f-51278b390f5b', N'George R.R. Martin', N'A Game of Thrones', N'9780553103540', 0)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'bacb0a0d-b992-4cab-81c5-7c4310fda60f', N'Mohammad', N'Clean Code Practices', N'9785566778899', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'68602c1e-594a-4bb1-954d-94745034d01f', N'Frank Herbert', N'Dune', N'9780441172719', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'd1a6f66e-15fe-4c87-bb6a-951f4b6f9907', N'J.R.R. Tolkien', N'The Lord of the Rings', N'9780544003415', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'c8fae381-b7ee-4a79-8b3f-9bf5e27d2c88', N'Mohammad', N'Database Design Patterns', N'9781122334455', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'212db719-173d-4301-93ab-b9ddad16e91b', N'J.K. Rowling', N'Harry Potter and the Sorcerer''s Stone', N'9780439708180', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'67b1488c-f09e-4624-bb8c-cd06cbf6c248', N'Stephen King', N'The Shining', N'9780307743657', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'cb981d75-6829-4503-8747-d361484f503c', N'Yuval Noah Harari', N'Sapiens', N'9780062316097', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'a4b6f9b9-208a-4e64-bdc3-db973cb2fd6e', N'Mohammad', N'Web Development Cookbook', N'9789876543210', 1)
INSERT [dbo].[Books] ([BookId], [Author], [Title], [ISBN], [ISAvailable]) VALUES (N'0d41d78b-82c6-4377-9590-de7e6bd16cdd', N'Mohammad', N'Spiderman', N'22112323232', 1)
GO
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'ee7a74bd-3bfe-4a7f-8417-0b17671c081f', N'c8fae381-b7ee-4a79-8b3f-9bf5e27d2c88', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:26:26.473' AS DateTime), CAST(N'2025-06-28T16:26:32.620' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'd773d18a-060a-4525-96ec-0bdf61cedfdd', N'bacb0a0d-b992-4cab-81c5-7c4310fda60f', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T15:48:16.600' AS DateTime), CAST(N'2025-06-28T15:48:21.617' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'798f08ae-d38f-403c-a5ca-10d1b39ce8ba', N'c8fae381-b7ee-4a79-8b3f-9bf5e27d2c88', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:26:41.343' AS DateTime), CAST(N'2025-06-28T16:26:54.320' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'277e5ada-7b10-48f4-99ec-1deb175bd5b8', N'212db719-173d-4301-93ab-b9ddad16e91b', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:27:05.760' AS DateTime), CAST(N'2025-06-28T16:27:44.453' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'44e5ddfa-6bf5-488d-b8ae-21035258829d', N'0e4bb1b4-2210-4b86-955f-51278b390f5b', N'3dce9a93-5f5f-4b33-ba60-9198e02cd57f', CAST(N'2025-06-27T18:56:48.217' AS DateTime), NULL)
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'ea7079ac-0b75-41b8-b404-2df4dd4577ce', N'c8fae381-b7ee-4a79-8b3f-9bf5e27d2c88', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:27:03.987' AS DateTime), CAST(N'2025-06-28T16:27:45.733' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'07db286f-e7dc-4acf-9461-2df4ea1d3664', N'212db719-173d-4301-93ab-b9ddad16e91b', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:32:07.287' AS DateTime), CAST(N'2025-06-28T16:32:13.777' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'6f56351a-1b61-4af7-91d6-32b1dbbab97d', N'c8fae381-b7ee-4a79-8b3f-9bf5e27d2c88', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:32:04.960' AS DateTime), CAST(N'2025-06-28T16:32:14.560' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'ab6a9c60-50b0-4367-b9b2-46695e83a7b6', N'ffff78a8-dac3-4fd9-995f-239a828f0188', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:32:09.043' AS DateTime), CAST(N'2025-06-28T16:32:13.180' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'1729000c-e8c6-49ec-bcaf-4ebfb560c026', N'c8fae381-b7ee-4a79-8b3f-9bf5e27d2c88', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T15:48:17.710' AS DateTime), CAST(N'2025-06-28T15:48:20.900' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'c09bb17b-5d8b-403b-8575-59798849565b', N'68602c1e-594a-4bb1-954d-94745034d01f', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T02:00:31.493' AS DateTime), CAST(N'2025-06-28T02:00:44.340' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'6c843148-459c-4d0a-94ea-5d4e91b4f01b', N'68602c1e-594a-4bb1-954d-94745034d01f', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T15:31:16.490' AS DateTime), CAST(N'2025-06-28T15:31:24.640' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'a52d554a-b161-4c20-9e8f-5fb0d2dc0a34', N'bacb0a0d-b992-4cab-81c5-7c4310fda60f', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:26:40.717' AS DateTime), CAST(N'2025-06-28T16:26:55.347' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'2f86ff5f-23ac-4bef-8ac0-61850438e4d8', N'a611604e-26b3-49e7-9c2d-37a0de3b63f3', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T15:31:19.420' AS DateTime), CAST(N'2025-06-28T15:31:22.340' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'af317ae9-5843-4e16-926c-6224f426a537', N'a611604e-26b3-49e7-9c2d-37a0de3b63f3', N'3dce9a93-5f5f-4b33-ba60-9198e02cd57f', CAST(N'2025-06-28T15:04:34.350' AS DateTime), CAST(N'2025-06-28T15:04:38.603' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'ae5fee16-cb84-49ef-bcec-726e996ea18a', N'c8fae381-b7ee-4a79-8b3f-9bf5e27d2c88', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T15:31:14.553' AS DateTime), CAST(N'2025-06-28T15:31:23.583' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'51b20cd4-def7-41a3-b619-752119bf5599', N'212db719-173d-4301-93ab-b9ddad16e91b', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T15:31:16.810' AS DateTime), CAST(N'2025-06-28T15:31:22.773' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'77d44fdd-0620-487a-977f-81e26b10a9c4', N'cb981d75-6829-4503-8747-d361484f503c', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T15:03:31.490' AS DateTime), CAST(N'2025-06-28T15:03:36.450' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'c67069bf-476e-4293-97d6-871763bd7834', N'c8fae381-b7ee-4a79-8b3f-9bf5e27d2c88', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T15:03:15.930' AS DateTime), CAST(N'2025-06-28T15:03:22.887' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'457048d6-ab3c-4a4d-a964-99f261c1a33e', N'68602c1e-594a-4bb1-954d-94745034d01f', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:26:27.670' AS DateTime), CAST(N'2025-06-28T16:26:31.497' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'bf5d25ea-a477-404f-b492-9b183152d07c', N'bacb0a0d-b992-4cab-81c5-7c4310fda60f', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:26:24.147' AS DateTime), CAST(N'2025-06-28T16:26:33.303' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'e4b53f1f-2e77-4190-a25f-9ea0711894d9', N'ffff78a8-dac3-4fd9-995f-239a828f0188', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T15:31:17.130' AS DateTime), CAST(N'2025-06-28T15:31:23.220' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'39ac1407-a9e1-4d34-8250-a6c1d3cb86f3', N'ffff78a8-dac3-4fd9-995f-239a828f0188', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:27:08.820' AS DateTime), CAST(N'2025-06-28T16:27:42.220' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'3de0b356-1d20-4009-829f-b0267aa2427c', N'bacb0a0d-b992-4cab-81c5-7c4310fda60f', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-27T18:45:09.890' AS DateTime), CAST(N'2025-06-27T18:45:41.390' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'059ff15d-e3e3-4c74-9c20-b0bb76b95717', N'0d41d78b-82c6-4377-9590-de7e6bd16cdd', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T15:03:30.213' AS DateTime), CAST(N'2025-06-28T15:03:37.083' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'fa4476c4-fe35-4de2-a163-c13f6949257e', N'a611604e-26b3-49e7-9c2d-37a0de3b63f3', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:26:45.297' AS DateTime), CAST(N'2025-06-28T16:26:47.237' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'2edcbec0-fa32-4453-a670-c17f5536453a', N'a611604e-26b3-49e7-9c2d-37a0de3b63f3', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T15:48:25.133' AS DateTime), CAST(N'2025-06-28T16:06:36.880' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'9f13221e-843b-4b2e-bd32-cd5439097553', N'c8fae381-b7ee-4a79-8b3f-9bf5e27d2c88', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:06:33.550' AS DateTime), CAST(N'2025-06-28T16:06:35.600' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'8412f58f-50b7-4310-9b75-d1bc8b32a071', N'ffff78a8-dac3-4fd9-995f-239a828f0188', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:26:44.030' AS DateTime), CAST(N'2025-06-28T16:26:50.847' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'b8a9e1e6-d654-40fc-895a-da551b58d797', N'68602c1e-594a-4bb1-954d-94745034d01f', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:26:42.260' AS DateTime), CAST(N'2025-06-28T16:26:53.487' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'17860cf4-e91f-4060-bf8a-dbd784a6763b', N'68602c1e-594a-4bb1-954d-94745034d01f', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:27:04.533' AS DateTime), CAST(N'2025-06-28T16:27:45.210' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'8128c2af-22c5-468d-bae6-e674d016c7d8', N'212db719-173d-4301-93ab-b9ddad16e91b', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:26:43.000' AS DateTime), CAST(N'2025-06-28T16:26:52.540' AS DateTime))
INSERT [dbo].[Borrowings] ([Borrowing], [BookId], [UserId], [BorrowDate], [ReturnDate]) VALUES (N'52cb4e64-005d-4d3c-9ec6-fbdeab8bac4d', N'a611604e-26b3-49e7-9c2d-37a0de3b63f3', N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', CAST(N'2025-06-28T16:27:10.493' AS DateTime), CAST(N'2025-06-28T16:27:14.263' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [Password]) VALUES (N'e8ccc1ec-5ff2-4df3-b918-46ed3aafed4f', N'Mohammadkaoud', N'b.qaoud2017@gmail.com', N'm+mJUQTAxVI3XbIZu5dt8Zq3DnBKjR5u7FuCNcLNyAQ=')
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [Password]) VALUES (N'3dce9a93-5f5f-4b33-ba60-9198e02cd57f', N'RamiYahia', N'RamiYahia@gmail.com', N'm+mJUQTAxVI3XbIZu5dt8Zq3DnBKjR5u7FuCNcLNyAQ=')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Books__447D36EA37A1E13E]    Script Date: 6/28/2025 4:45:32 PM ******/
ALTER TABLE [dbo].[Books] ADD UNIQUE NONCLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT (newid()) FOR [BookId]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT ((1)) FOR [ISAvailable]
GO
ALTER TABLE [dbo].[Borrowings] ADD  DEFAULT (newid()) FOR [Borrowing]
GO
ALTER TABLE [dbo].[Borrowings] ADD  DEFAULT (getdate()) FOR [BorrowDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (newid()) FOR [UserId]
GO
ALTER TABLE [dbo].[Borrowings]  WITH CHECK ADD FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[Borrowings]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
/****** Object:  StoredProcedure [dbo].[BorrowBook]    Script Date: 6/28/2025 4:45:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE PROCEDURE [dbo].[BorrowBook]
    @UserId UNIQUEIDENTIFIER,
    @BookId UNIQUEIDENTIFIER,
    @BorrowDate DATETIME = NULL
AS
BEGIN


    BEGIN TRY
        BEGIN TRANSACTION;

        
        INSERT INTO Borrowings (UserId, BookId, BorrowDate, ReturnDate)
        VALUES (@UserId, @BookId, ISNULL(@BorrowDate, GETDATE()), NULL);

        UPDATE Books
        SET ISAvailable = 0
        WHERE BookId = @BookId;

        COMMIT;
    END TRY
    BEGIN CATCH
      --changes 1
      if @@TRANCOUNT > 0
        ROLLBACK;
        --THROW;
        --changes 2
         DECLARE @Msg NVARCHAR(4000), @Lvl INT, @St INT;
        SELECT
            @Msg = ERROR_MESSAGE(),
            @Lvl = ERROR_SEVERITY(),
            @St = ERROR_STATE();

        RAISERROR (@Msg, @Lvl, @St);
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllBooks]    Script Date: 6/28/2025 4:45:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[GetAllBooks]
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM dbo.Books)
    BEGIN
        SELECT 'No books found.' AS Message;
        RETURN;
    END
    SELECT 
        BookId,
        Title,
        Author,
        ISBN,
		ISAvailable
      
  
    
    FROM 
        dbo.Books
    ORDER BY 
        Title ASC; 
END;
GO
/****** Object:  StoredProcedure [dbo].[GetBooksBorrowedByUser]    Script Date: 6/28/2025 4:45:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetBooksBorrowedByUser]
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
   

    IF NOT EXISTS (SELECT 1 FROM Borrowings WHERE UserId = @UserId)
    BEGIN
        SELECT 
            CAST(NULL AS INT) AS BookId,
            'No books borrowed by you' AS Title,
            '' AS Author,
            '' AS ISBN,
            NULL AS BorrowDate,
            NULL AS ReturnDate,
            CAST(0 AS BIT) AS ISAvailable
        RETURN
    END

    SELECT 
        b.BookId,
        b.Title,
        b.Author,
        b.ISBN,
        br.BorrowDate
    FROM Borrowings br
    INNER JOIN Books b ON br.BookId = b.BookId
    WHERE br.UserId = @UserId
	    AND br.ReturnDate IS NULL
    ORDER BY br.BorrowDate DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[ReturnBook]    Script Date: 6/28/2025 4:45:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ReturnBook]
    @UserId UNIQUEIDENTIFIER,
    @BookId UNIQUEIDENTIFIER,
    @ResultMessage NVARCHAR(100) OUTPUT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1 
        FROM Borrowings 
        WHERE UserId = @UserId AND BookId = @BookId AND ReturnDate IS NULL
    )
    BEGIN
        SET @ResultMessage = 'No active borrowing record found';
        RETURN;
    END

    UPDATE Borrowings
    SET ReturnDate = GETDATE()
    WHERE UserId = @UserId AND BookId = @BookId AND ReturnDate IS NULL;

    UPDATE Books
    SET ISAvailable = 1
    WHERE BookId = @BookId;

    SET @ResultMessage = 'Book returned successfully';
END;
GO
/****** Object:  StoredProcedure [dbo].[SearchBooks]    Script Date: 6/28/2025 4:45:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[SearchBooks]
    @Query NVARCHAR(100)
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM Books
        WHERE Title LIKE '%' + @Query + '%'
           OR Author LIKE '%' + @Query + '%'
		   OR ISBN  LIKE '%'+ @Query +'%'
    )
    BEGIN
        SELECT 
            CAST(NULL AS INT) AS BookId,
            'No matching books found.' AS Title,
            '' AS Author,
            '' AS ISBN,
            CAST(0 AS BIT) AS ISAvailable
        RETURN
    END

    SELECT * FROM Books
    WHERE Title LIKE '%' + @Query + '%'
       OR Author LIKE '%' + @Query + '%'
	   OR ISBN  LIKE '%'+ @Query +'%'
END
GO
/****** Object:  StoredProcedure [dbo].[SeedDummyBooks]    Script Date: 6/28/2025 4:45:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SeedDummyBooks]
AS
BEGIN
  
    IF NOT EXISTS (SELECT 1 FROM Books)
    BEGIN
        
        INSERT INTO Books (Author, Title, ISBN)
        VALUES
            ('J.K. Rowling', 'Harry Potter and the Sorcerer''s Stone', '9780439708180'),
            ('George R.R. Martin', 'A Game of Thrones', '9780553103540'),
            ('Mohammad', 'The Art of Programming', '9780123456789'),
            ('Stephen King', 'The Shining', '9780307743657'),
            ('Agatha Christie', 'Murder on the Orient Express', '9780062073495'),
            ('Mohammad', 'Web Development Cookbook', '9789876543210'),
            ('Yuval Noah Harari', 'Sapiens', '9780062316097'),
            ('Frank Herbert', 'Dune', '9780441172719'),
            ('Mohammad', 'Database Design Patterns', '9781122334455'),
            ('Harper Lee', 'To Kill a Mockingbird', '9780061120084'),
            ('Douglas Adams', 'The Hitchhiker''s Guide to the Galaxy', '9780345391803'),
            ('Mohammad', 'Clean Code Practices', '9785566778899'),
            ('J.R.R. Tolkien', 'The Lord of the Rings', '9780544003415'),
            ('Jane Austen', 'Pride and Prejudice', '9780141439518'),
            ('Mohammad', 'Spiderman', '22112323232');
        
     
        SELECT 'successfully' AS Result;
    END
    ELSE
    BEGIN

        SELECT 'alreadyfull' AS Result;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_LoginUser]    Script Date: 6/28/2025 4:45:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Sp_LoginUser]
@UserName nvarchar(255),
@Password nvarchar(255)
As
Begin
Select UserId,UserName,Email From Users Where (UserName=@UserName and Password=@Password);
End;
GO
/****** Object:  StoredProcedure [dbo].[sp_RegisterUser]    Script Date: 6/28/2025 4:45:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[sp_RegisterUser]
    @Username NVARCHAR(100),
    @Email NVARCHAR(100),
    @Password NVARCHAR(255)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Users WHERE Email = @Email)
    BEGIN
        RAISERROR('Email already exists', 16, 1);
        RETURN;
    END

    INSERT INTO Users (Username, Email, Password)
    VALUES (@Username, @Email, @Password);
END
GO
