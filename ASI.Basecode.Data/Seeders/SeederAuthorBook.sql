-- Insert multiple authors into the Authors table
INSERT INTO dbo.Authors (FirstName, LastName)
VALUES 
('J.K.', 'Rowling'),
('Jane', 'Austen'),
('Mark', 'Twain');

-- Insert multiple genres into the Genres table
INSERT INTO dbo.Genres (Name)
VALUES 
('Fantasy'),
('Classic Literature'),
('Historical Fiction');

-- Insert multiple books into the Books table
-- Make sure to insert a valid AuthorId from the Authors table if the Books table requires it.
-- Note: Here I'm not including the AuthorId as it's not directly part of the Books table, 
-- assuming the relationship is managed via the AuthorBook table.
INSERT INTO dbo.Books (Name, Description, Image, ISBN, Language, PublishedOn, PageCount, Created, Updated)
VALUES 
('1984', 'A dystopian novel by George Orwell.', '1984_image.jpg', 'ISBN-123-1984', 'English', '1949-06-08', 328, GETDATE(), GETDATE()),
('Pride and Prejudice', 'A novel by Jane Austen.', 'pride_prejudice_image.jpg', 'ISBN-123-PNP', 'English', '1813-01-28', 432, GETDATE(), GETDATE()),
('The Adventures of Tom Sawyer', 'A novel by Mark Twain.', 'tom_sawyer_image.jpg', 'ISBN-123-TS', 'English', '1876-06-09', 274, GETDATE(), GETDATE());

-- Retrieve IDs of inserted authors and books for use in many-to-many relationships
DECLARE @JKRowlingId INT = (SELECT Id FROM dbo.Authors WHERE FirstName = 'J.K.' AND LastName = 'Rowling'),
        @JaneAustenId INT = (SELECT Id FROM dbo.Authors WHERE FirstName = 'Jane' AND LastName = 'Austen'),
        @MarkTwainId INT = (SELECT Id FROM dbo.Authors WHERE FirstName = 'Mark' AND LastName = 'Twain'),
        @Book1984Id INT = (SELECT Id FROM dbo.Books WHERE ISBN = 'ISBN-123-1984'),
        @PridePrejudiceId INT = (SELECT Id FROM dbo.Books WHERE ISBN = 'ISBN-123-PNP'),
        @TomSawyerId INT = (SELECT Id FROM dbo.Books WHERE ISBN = 'ISBN-123-TS');

-- Insert the relationships between Authors and Books into AuthorBook table
INSERT INTO dbo.AuthorBook (AuthorId, BookId)
VALUES 
(@JKRowlingId, @Book1984Id),
(@JaneAustenId, @PridePrejudiceId),
(@MarkTwainId, @TomSawyerId);

-- Insert the relationships between Books and Genres into BookGenre table
-- Assuming each book only has one genre for the sake of this example
DECLARE @FantasyId INT = (SELECT Id FROM dbo.Genres WHERE Name = 'Fantasy'),
        @ClassicLiteratureId INT = (SELECT Id FROM dbo.Genres WHERE Name = 'Classic Literature'),
        @HistoricalFictionId INT = (SELECT Id FROM dbo.Genres WHERE Name = 'Historical Fiction');

INSERT INTO dbo.BookGenre (BookId, GenreId)
VALUES 
(@Book1984Id, @FantasyId),
(@PridePrejudiceId, @ClassicLiteratureId),
(@TomSawyerId, @HistoricalFictionId);
