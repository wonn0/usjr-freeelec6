-- Insert multiple authors into the Authors table
INSERT INTO dbo.Authors (FirstName, LastName)
VALUES 
('J.K.', 'Rowling'),
('Jane', 'Austen'),
('Mark', 'Twain');
-- Insert a new book into the Books table
INSERT INTO Books (Name, Description, Image, ISBN, Language, PublishedOn, PageCount, Created, Updated, AuthorId)
VALUES ('1984', 'A dystopian novel', 'image_path_here', 'ISBN123456789', 'English', '1949-06-08', 328, GETDATE(), GETDATE(), 1);
